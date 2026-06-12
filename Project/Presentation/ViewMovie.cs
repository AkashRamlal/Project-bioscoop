public static class ViewMovies
{
    public static bool PrintMovie(FilmModel movie)
    {
        Console.Clear();
        Console.WriteLine($"Movie Title: {movie.Naam}");
        Console.WriteLine($"Genre: {movie.Genre}");
        Console.WriteLine($"Duration: {movie.Tijdsduur}");
        Console.WriteLine($"Minimum age: {movie.Leeftijdsgrens}");
        Console.WriteLine($"Actors: {movie.Acteurs}");
        Console.WriteLine($"Director: {movie.Regiseur}");

        Console.WriteLine();
        Console.WriteLine("Press Enter to go further.");
        Console.WriteLine("Press R to return to movies");

        while (true)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;

            if (pressedKey == ConsoleKey.R)
            {
                return false;
            }

            if (pressedKey == ConsoleKey.Enter)
            {
                return true;
            }
        }

    }
}
