using System.Runtime.CompilerServices;

public static class Menu
{

        public static FilmAccess filmAccess = new FilmAccess();
        public static List<FilmModel> films = filmAccess.GetAll();

        public static MovieShowingsAccess showingsAccess = new MovieShowingsAccess();

        public static TicketUI ticketUI = new TicketUI();
        public static AuditoriumRepository auditoriumRepository = new AuditoriumRepository();
        public static AuditoriumService auditoriumService = new AuditoriumService(auditoriumRepository);
        public static AuditoriumConsoleView auditoriumView = new AuditoriumConsoleView(auditoriumService);

        public static MovieService movieService = new MovieService(auditoriumService, auditoriumView);

    // Start for logged in user
    public static void Start(AccountModel acc)
    {
        bool inMenu = true;

        while (inMenu)
        {
            string choice = ShowMenu(acc);

            Console.Clear();

            switch (choice)
            {
                case "Movie theatre info":
                    TheatreInfo.Print();
                    break;

                case "View movies":
                    List<Movie> movies = new();

                    foreach (var film in films)
                    {
                        List<MovieShowing> showings = showingsAccess.GetByFilmId(film.Id);

                        movies.Add(new Movie(film.Naam, showings));
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
                            MovieSelector.SelectShowing(selectedMovie.Showings
                                    .Where(s => s.StartTime > DateTime.Now)
                                    .ToList())!;
                        
                        if (selectedShowing == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry! There are currently no screenings for this movie.");
                            break;
                        }

                        movieService.RunAuditorium(
                            selectedMovie,
                            selectedShowing,
                            acc);

                        break;
                    }

                    break;

                case "Your tickets":
                    ticketUI.ShowTickets(acc);
                    break;

                case "Edit account information":
                    EditAccount.Start(acc);
                    break;

                case "Manage films":
                    ManageFilms.Show();
                    break;

                case "Manage movie showings":
                    ManageMovieShowings.Start();
                    break;

                case "Search movies":
                    SearchFilm searchFilm = new SearchFilm();
                    searchFilm.Search();
                    break;

                case "Manage tickets":
                    ticketUI.ShowAllTickets();
                    break;

                case "Manage employees":
                    ManageEmployee.Display();
                    break;
                case "Manage members":
                    ManageMembers.Start();
                    break;

                case "Quit":
                    inMenu = false;
                    continue;
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }
    }

    // Start for Guest
    public static void Start()
    {
        bool inMenu = true;

        while (inMenu)
        {
            string choice = ShowMenu();

            Console.Clear();

            switch (choice)
            {
                case "Movie theatre info":
                    TheatreInfo.Print();
                    break;

                case "View movies":
                    List<Movie> movies = new();

                    foreach (var film in films)
                    {
                        List<MovieShowing> showings = showingsAccess.GetByFilmId(film.Id);

                        movies.Add(new Movie(film.Naam, showings));
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
                            MovieSelector.SelectShowing(selectedMovie.Showings
                                    .Where(s => s.StartTime > DateTime.Now)
                                    .ToList())!;
                        
                        if (selectedShowing == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry! There are currently no screenings for this movie.");
                            break;
                        }

                        movieService.RunAuditorium(
                            selectedMovie,
                            selectedShowing,
                            null);

                        break;
                    }

                    break;
                case "Search movies":
                    SearchFilm searchFilm = new SearchFilm();
                    searchFilm.Search();
                    break;

                case "Quit":
                    inMenu = false;
                    continue;
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }
    }

    private static string ShowMenu(AccountModel acc)
    {
        List<string> menuOptions = GetOptions(acc.Role);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex, $"{acc.Naam} {acc.Achternaam}");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuOptions.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= menuOptions.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return menuOptions[selectedIndex];
    }

    private static string ShowMenu()
    {
        List<string> menuOptions = GetOptions(null);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex, "guest");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuOptions.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= menuOptions.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return menuOptions[selectedIndex];
    }

    public static List<string> GetOptions(Roles? role)
    {
        List<string> options = new();

        options.Add("Movie theatre info");
        options.Add("View movies");
        options.Add("Search movies");

        if (role == Roles.Member || role == Roles.Employee || role == Roles.Admin)
        {
            options.Add("Your tickets");
            options.Add("Edit account information");
        }

        if (role == Roles.Employee || role == Roles.Admin)
        {
            options.Add("Manage films");
            options.Add("Manage movie showings");
            options.Add("Manage tickets");
        }

        if (role == Roles.Admin)
        {
            options.Add("Manage employees");
            options.Add("Manage members");
        }

        options.Add("Quit");

        return options;
    }

    private static void DrawMenu(List<string> options, int selectedIndex, string name)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("         Movie theatre Menu");
        Console.WriteLine("=====================================\n");

        Console.WriteLine($"You are logged in as: {name}");

        Console.WriteLine("Use arrow keys to navigate and press Enter to select option:\n");

        for (int i = 0; i < options.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
    }
}