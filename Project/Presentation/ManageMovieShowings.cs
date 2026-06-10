public static class ManageMovieShowings
{
    private static List<string> Options = ["Create a movie showing", "Delete a movie showing"];
    private static FilmAccess filmAccess = new();
    private static MovieShowingsAccess showingsAccess = new();

    public static void Start()
    {
        var allFilms = filmAccess.GetAll();
        string choice = SelectOption();

        switch (choice)
        {
            case "Create a movie showing":
                MovieShowingCreator.CreateShowing(allFilms);
                break;
            
            case "Delete a movie showing":
                var selectedFilm = MovieSelector.SelectFilm(allFilms);
                var availableShowings = showingsAccess.GetByFilmId(selectedFilm.Id);
                MovieShowing selectedShowing = MovieSelector.SelectShowing(availableShowings);

                if (selectedShowing == null)
                {
                    Console.Clear();
                    Console.WriteLine("There are currently no screenings for this movie.");
                    break;
                }

                Console.Clear();
                Console.WriteLine($"Movie: {selectedFilm.Naam}");
                Console.WriteLine($"Auditorium: {selectedShowing.Auditorium}");
                Console.WriteLine($"Time and date: {selectedShowing.StartTime}");
                Console.WriteLine($"Dinner event: {selectedShowing.IsDinnerEvent}");

                while (true)
                {
                    Console.Write("\nAre you sure you want to delete this showing? (y/n): ");

                    string? input = Console.ReadLine().Trim().ToLower();

                    if (input == "y")
                    {
                        showingsAccess.Delete(selectedShowing);
                        Console.WriteLine("\nShowing deleted succesfully.");
                        break;
                    }

                    if (input == "n")
                    {
                        break;
                    }

                    Console.WriteLine("Please enter y or n.");
                }
                break;
        }
    }

    private static string SelectOption()
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            Console.WriteLine("Please select an option:\n");

            for (int i = 0; i < Options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"> {Options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {Options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + Options.Count) % Options.Count;

            if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % Options.Count;

        } while (key != ConsoleKey.Enter);

        return Options[selectedIndex];
    }
}