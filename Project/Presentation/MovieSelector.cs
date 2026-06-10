public static class MovieSelector
{
    public static Movie SelectMovie(List<Movie> movies)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            for (int i = 0; i < movies.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"> {movies[i].Title}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {movies[i].Title}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + movies.Count) % movies.Count;

            if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % movies.Count;

        } while (key != ConsoleKey.Enter);

        return movies[selectedIndex];
    }

    public static MovieShowing? SelectShowing(List<MovieShowing> showings)
    {
        if (showings == null || showings.Count == 0)
        {
            return null;
        }

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            for (int i = 0; i < showings.Count; i++)
            {
                string text = showings[i].IsDinnerEvent
                    ? $"{showings[i].StartTime} - Dinner (+€50)"
                    : $"{showings[i].StartTime}";

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"> {text}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {text}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + showings.Count) % showings.Count;

            if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % showings.Count;

        } while (key != ConsoleKey.Enter);

        return showings[selectedIndex];
    }
}