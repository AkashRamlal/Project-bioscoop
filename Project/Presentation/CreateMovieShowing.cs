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

            if (startTime.Hour < 9 || startTime.Hour > 21)
            {
                Console.WriteLine("Movie showings can only be scheduled between 09:00 and 21:00.");
                continue;
            }
            
            break;
        }

        string auditorium;

        while (true)
        {
            Console.Write("Auditorium (1-3): ");
            string? auditoriumInput = Console.ReadLine();

            if (auditoriumInput == "1" || auditoriumInput == "2" || auditoriumInput == "3")
            {
                auditorium = $"Auditorium {auditoriumInput}";
                break;
            }

            Console.WriteLine("Invalid auditorium. Please enter 1, 2 or 3.");
        }

        bool isDinnerEvent = false;

        bool isDinnerEligible =
            (startTime.DayOfWeek == DayOfWeek.Friday ||
            startTime.DayOfWeek == DayOfWeek.Saturday)
            && startTime.Hour >= 18 && auditorium == "Auditorium 1";

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