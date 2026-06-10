public static class MovieShowingCreator
{
    public static void CreateShowing(List<FilmModel> films)
    {
        Console.Clear();
        Console.WriteLine("Select a movie:");
        Console.WriteLine();

        FilmModel selectedFilm = MovieSelector.SelectFilm(films);

        Console.Clear();
        Console.WriteLine($"Creating showing for: {selectedFilm.Naam}");
        Console.WriteLine();

        DateTime startTime;

        while (true)
        {
            Console.Write("Start date and time (yyyy-MM-dd HH:mm): ");

            if (!DateTime.TryParse(Console.ReadLine(), out startTime))
            {
                Console.WriteLine("Invalid date/time format.");
                continue;
            }

            if (startTime <= DateTime.Now.AddHours(24))
            {
                Console.WriteLine("A movie showing must be scheduled at least 24 hours in advance.");
                continue;
            }
            break;
        }

        Console.Write("Auditorium: ");
        string auditoriumInput = Console.ReadLine();
        string auditorium = "Auditorium " + auditoriumInput;

        bool isDinnerEvent = false;

        bool isDinnerEligible =
            (startTime.DayOfWeek == DayOfWeek.Friday ||
            startTime.DayOfWeek == DayOfWeek.Saturday)
            && startTime.Hour >= 18;

        if (isDinnerEligible)
        {
            while (true)
            {
                Console.Write("Make this a dinner event? (y/n): ");

                string? input = Console.ReadLine().Trim().ToLower();

                if (input == "y")
                {
                    isDinnerEvent = true;
                    break;
                }

                if (input == "n")
                {
                    isDinnerEvent = false;
                    break;
                }

                Console.WriteLine("Please enter y or n.");
            }
        }

        bool successfullyCreated = CreateMovieShowingLogic.AddMovieShowing(selectedFilm, startTime, auditorium, isDinnerEvent);

        if (successfullyCreated)
        {
            Console.WriteLine();
            Console.WriteLine("Movie showing created successfully.");
        }

        else
        {
            Console.WriteLine("Could not create movie showing due to overlapping time and date with an already existing showing.");
        }
    }
}