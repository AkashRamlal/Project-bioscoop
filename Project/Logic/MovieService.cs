public class MovieService
{

    private readonly AuditoriumService _auditoriumService;
    private readonly AuditoriumConsoleView _auditoriumView;

    public MovieService(
        AuditoriumService auditoriumService,
        AuditoriumConsoleView auditoriumView)
    {
        _auditoriumService = auditoriumService;
        _auditoriumView = auditoriumView;
    }
    public void RunAuditorium(
        Movie selectedMovie,
        MovieShowing selectedShowing,
        AccountModel? account)
    {
        HandleDinnerEventInfo(selectedShowing, account);

        TicketService ticketService = new TicketService();

        List<string> reservedSeats =
            ticketService.ReservedTickets(
                selectedShowing.Auditorium,
                selectedShowing.StartTime.ToString("dddd dd MMMM - HH:mm"));

        AuditoriumRepository auditoriumRepository = new AuditoriumRepository();
        AuditoriumService auditoriumService = new AuditoriumService(auditoriumRepository);
        AuditoriumConsoleView auditoriumView = new AuditoriumConsoleView(auditoriumService);

        AuditoriumModel auditorium =
            auditoriumService.LoadAuditorium(selectedShowing.Auditorium);

        auditoriumService.SetReservedSeats(auditorium, reservedSeats);

        Reservation reservation =
            auditoriumView.StartSelection(
                auditorium,
                selectedMovie.Title,
                selectedShowing.StartTime.ToString("dddd dd MMMM - HH:mm"));

        Dictionary<string, Dictionary<string, decimal>> selectedSeats =
            new Dictionary<string, Dictionary<string, decimal>>
            {
                { selectedShowing.Auditorium, reservation.Seats }
            };

        ApplyDinnerEventPricing(selectedShowing, selectedSeats);

        ProcessPayment(selectedMovie, selectedShowing, selectedSeats, account);
    }

    private void HandleDinnerEventInfo(
        MovieShowing showing,
        AccountModel? account)
    {
        if (!showing.IsDinnerEvent)
            return;

        bool shouldAskInfo =
            account == null ||
            (account.Allergie == null &&
             account.Dieet == null &&
             account.Opmerkingen == null);

        if (!shouldAskInfo)
            return;

        string? allergies = Diet.AskForAllergies();
        string? diet = Diet.AskForDietaryPreferences();
        string? comments = Diet.AskForAdditionalComments();

        if (account != null)
        {
            EditAccountLogic.EditDiet(account, allergies, diet, comments);
        }
    }

    private void ApplyDinnerEventPricing(
        MovieShowing showing,
        Dictionary<string, Dictionary<string, decimal>> selectedSeats)
    {
        if (!showing.IsDinnerEvent)
            return;

        foreach (var innerDict in selectedSeats.Values)
        {
            foreach (var key in innerDict.Keys.ToList())
            {
                innerDict[key] += 50m;
            }
        }
    }

    private void ProcessPayment(
        Movie movie,
        MovieShowing showing,
        Dictionary<string, Dictionary<string, decimal>> selectedSeats,
        AccountModel? account)
    {
        PaymentUI paymentUI = new PaymentUI(account != null);

        paymentUI.Start(
            movie.Title,
            showing.StartTime.ToString("dddd dd MMMM - HH:mm"),
            selectedSeats,
            account?.Email);
    }
}