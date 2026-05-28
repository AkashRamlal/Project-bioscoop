using System.Runtime.CompilerServices;

public static class Menu
{
    public static void Start(AccountModel acc)
{
    FilmAccess filmAccess = new FilmAccess();
    List<FilmModel> films = filmAccess.GetAll();


    TicketsAccess ticketAccess = new TicketsAccess();
    TicketService ticketService = new TicketService();

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
                Movie.Movies.Clear();
                    foreach(var movie in films)
                    {
                        new Movie(movie.Naam, new List<MovieShowing>
                        {
                            new MovieShowing
                            {
                                StartTime = new DateTime(2026, 5, 29, 12, 0, 0),
                                Auditorium = "Auditorium 1",
                                IsDinnerEvent = false
                            },

                            new MovieShowing
                            {
                                StartTime = new DateTime(2026, 5, 30, 20, 0, 0),
                                Auditorium = "Auditorium 1",
                                IsDinnerEvent = true
                            }
                        });
                    }
                    
                    while(true)
                    {
                        Movie gekozenTitel = Movie.ArrowOptions(Movie.Movies);

                        FilmModel chosedMovie = films.First(f => f.Naam == gekozenTitel.Title); 
                        bool goFurther = ViewMovies.PrintMovie(chosedMovie);

                        if(!goFurther) // user drukt op R en kiest opnieuw de movie
                        {
                            continue;
                        }
                        List<MovieShowing> beschikbareTijden = gekozenTitel.Showings;
                        MovieShowing gekozenTijd = Movie.ArrowOptions(beschikbareTijden);
                        Movie.RunAuditorium(gekozenTitel, gekozenTijd, acc);
                        break;
                    }
                    break;

            case "Your tickets":
                ticketService.ShowTickets(acc.Email);
                break;

            case "Edit account information":
                EditAccount.Start(acc);
                break;

            case "Create film":
                CreateFilm.Start();
                break;

            case "Manage films":
                Console.WriteLine("Placeholder");
                break;

            case "Manage tickets":
                ticketService.ShowAllTickets();
                break;

            case "Create employee":
                CreateEmployee.Start();
                break;

            case "Manage employees":
                Console.WriteLine("Placeholder");
                break;

            case "Quit":
                inMenu = false;
                continue;
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
    public static string ShowMenu(AccountModel acc)
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

    // Start for Guest
    public static void Start()
    {

        FilmAccess filmAccess = new FilmAccess();
        List<FilmModel> films = filmAccess.GetAll();

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
                    Movie.Movies.Clear();
                    foreach(var movie in films)
                    {
                        new Movie(movie.Naam, new List<MovieShowing>
                        {
                            new MovieShowing
                            {
                                StartTime = new DateTime(2026, 5, 29, 12, 0, 0),
                                Auditorium = "Auditorium 1",
                                IsDinnerEvent = false
                            },

                            new MovieShowing
                            {
                                StartTime = new DateTime(2026, 5, 30, 20, 0, 0),
                                Auditorium = "Auditorium 1",
                                IsDinnerEvent = true
                            }
                        });
                    }
                    while(true)
                    {
                        Movie gekozenTitel = Movie.ArrowOptions(Movie.Movies);

                        FilmModel chosedMovie = films.First(f => f.Naam == gekozenTitel.Title); 
                        bool goFurther = ViewMovies.PrintMovie(chosedMovie);

                        if(!goFurther) // user drukt op R en kiest opnieuw de movie
                        {
                            continue;
                        }
                        List<MovieShowing> beschikbareTijden = gekozenTitel.Showings;
                        MovieShowing gekozenTijd = Movie.ArrowOptions(beschikbareTijden);
                        Movie.RunAuditorium(gekozenTitel, gekozenTijd, null);
                        break;
                    };
                    break;

                case "Your tickets":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage films":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage tickets":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage employees":
                    Console.WriteLine("Placeholder");
                    break;

                case "Quit":
                    inMenu = false;
                    continue;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }

    public static string ShowMenu()
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
        List<string> options = [];

        // Guest
        options.Add("Movie theatre info");
        options.Add("View movies");

        // Member
        if (role == Roles.Member || role == Roles.Employee || role == Roles.Admin)
        {
            options.Add("Your tickets");
            options.Add("Edit account information");
        }

        // Employee
        if (role == Roles.Employee || role == Roles.Admin)
        {
            options.Add("Create film");
            options.Add("Manage films");
            options.Add("Manage tickets");
        }

        // Admin
        if (role == Roles.Admin)
        {
            options.Add("Create employee");
            options.Add("Manage employees");
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
