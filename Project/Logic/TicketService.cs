public class TicketService
{
    private readonly TicketsAccess _ticketsAccess;

    public TicketService()
    {
        _ticketsAccess = new TicketsAccess();
    }

    public List<Ticket> CreateTickets(
        string filmName,
        DateTime time,
        Dictionary<string, Dictionary<string, decimal>> hallData,
        string email)
    {
        List<Ticket> createdTickets = new();

        foreach (var hall in hallData)
        {
            string hallName = hall.Key;
            string seats = string.Join(", ", hall.Value.Select(s => $"{s.Key} (€{s.Value:F2})"));
            decimal total = hall.Value.Values.Sum();

            Ticket ticket = new Ticket(filmName, hallName, time, seats, total, email, hallData.Values.First());
            _ticketsAccess.Write(ticket);
            createdTickets.Add(ticket);
        }

        return createdTickets;
    }

    public List<Ticket> GetTicketsByEmail(string email)
    {
        return _ticketsAccess.GetByAccount(email);
    }

    public List<Ticket> GetAllTickets()
    {
        return _ticketsAccess.GetAll();
    }

    public bool CancelTicket(Ticket ticket)
    {
        if (!CanCancelTicket(ticket))
            return false;

        string showKey = $"{ticket.FilmName}-{ticket.Date:HH:mm}-{ticket.Hall}";
        AuditoriumService auditoriumService = new AuditoriumService(new AuditoriumRepository());
        _ticketsAccess.Delete(ticket.Id);
        Reservation reservation = new Reservation
        {
            AuditoriumNumber = ticket.Hall,
            Seats = ticket.HallData,
            Showkey = showKey
        };
        auditoriumService.Cancelticket(ticket.Hall, reservation, ticket.Seats.Split(", ").Select(s => s.Split(" ")[0]).ToList());
        return true;
    }

    public bool CanCancelTicket(Ticket ticket)
    {
        DateTime filmDateTime = ticket.Date;
        DateTime now = DateTime.Now;

        return filmDateTime > now && (filmDateTime - now).TotalHours >= 2;
    }

    public List<string> ReservedTickets(string filmName, DateTime date, string hall)
    {
        List<Ticket> allTickets = _ticketsAccess.GetTickets();
        List<string> reservedSeats = new();

        foreach (Ticket ticket in allTickets)
        {
            if (ticket.FilmName == filmName && ticket.Hall == hall && ticket.Date == date)
            {
                reservedSeats.AddRange(ticket.Seats.Split(", ").Select(seat => seat.Split(" ")[0]));
            }
        }

        return reservedSeats;
    }

    public bool ChangeTicket(Ticket ticket, AccountModel? acc)
    {
        if (!CanCancelTicket(ticket))
        {
            return false;
        }
        _ticketsAccess.Delete(ticket.Id);
        List<Movie> movies = new();
        FilmAccess filmAccess = new FilmAccess();
        AuditoriumRepository auditoriumRepository = new AuditoriumRepository();
        AuditoriumService auditoriumService = new AuditoriumService(auditoriumRepository);
        AuditoriumConsoleView auditoriumView = new AuditoriumConsoleView(auditoriumService);
        MovieService movieService = new MovieService(auditoriumService, auditoriumView);
        List<FilmModel> films = filmAccess.SearchByTitle(ticket.FilmName);
        foreach (var film in films)
                    {
                        if (film.Naam != ticket.FilmName)
                            continue;
                        movies.Add(new Movie(
                            film.Naam,
                            new List<MovieShowing>
                            {
                                new MovieShowing
                                {
                                    StartTime = new DateTime(2026, 6, 29, 12, 0, 0),
                                    Auditorium = "Auditorium 1",
                                    IsDinnerEvent = false
                                },
                                new MovieShowing
                                {
                                    StartTime = new DateTime(2026, 6, 30, 20, 0, 0),
                                    Auditorium = "Auditorium 1",
                                    IsDinnerEvent = true
                                }
                            }
                        ));
                    }
        while (true)
        {
            Movie selectedMovie = MovieSelector.SelectMovie(movies);

            FilmModel selectedFilm =
                films.First(f => f.Naam == selectedMovie.Title);

            bool continueFlow =
                ViewMovies.PrintMovie(selectedFilm);

            if (!continueFlow)
                continue;

            MovieShowing selectedShowing =
                MovieSelector.SelectShowing(selectedMovie.Showings);

            if (selectedShowing == null)
                continue;

            movieService.RunAuditorium(selectedMovie, selectedShowing, acc);
            break;
        }
        return true;
    }
}