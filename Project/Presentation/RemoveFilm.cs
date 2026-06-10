public static class RemoveFilm
{
    public static void Start()
    {
        FilmLogic filmLogic = new FilmLogic();

        List<FilmModel> films = filmLogic.GetAllFilms();

        Console.WriteLine("Select a film to delete:");
        Console.WriteLine();

        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}",
            "ID", "Naam", "Genre", "Tijdsduur", "Leeftijdsgrens", "Acteurs");

        Console.WriteLine(new string('-', 110));

        foreach (FilmModel film in films)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}",
                film.Id,
                film.Naam,
                film.Genre,
                film.Tijdsduur,
                film.Leeftijdsgrens,
                film.Acteurs);
        }

        Console.WriteLine();
        Console.Write("Enter film ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int filmId))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        FilmModel? selectedFilm = filmLogic.GetFilmById(filmId);

        if (selectedFilm == null)
        {
            Console.WriteLine("Film not found.");
            return;
        }

        Console.Write($"Are you sure you want to delete '{selectedFilm.Naam}'? (y/n): ");
        string? confirm = Console.ReadLine()?.Trim().ToLower();

        if (confirm != "y")
        {
            Console.WriteLine("Delete cancelled.");
            return;
        }

        try
        {
            filmLogic.DeleteFilm(filmId);
            Console.WriteLine($"Film '{selectedFilm.Naam}' has been deleted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}