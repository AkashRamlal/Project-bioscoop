public static class EditFilm
{
    public static void Start()
    {
        FilmLogic filmLogic = new FilmLogic();

        List<FilmModel> films = filmLogic.GetAllFilms();

        Console.WriteLine("Select a film to edit:");
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
        Console.Write("Enter film ID: ");

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

        Console.WriteLine();

        UpdateField($"Naam ({selectedFilm.Naam}): ",
            value => selectedFilm.Naam = value);

        UpdateField($"Genre ({selectedFilm.Genre}): ",
            value => selectedFilm.Genre = value);

        UpdateField($"Tijdsduur ({selectedFilm.Tijdsduur}): ",
            value => selectedFilm.Tijdsduur = value);

        UpdateIntField($"Leeftijdsgrens ({selectedFilm.Leeftijdsgrens}): ",
            value => selectedFilm.Leeftijdsgrens = value);

        Console.WriteLine($"Acteurs (current: {selectedFilm.Acteurs})");
        Console.Write("Do you want to edit actors? (y/n): ");

        if (Console.ReadLine()?.Trim().ToLower() == "y")
        {
            string newActors = GetActorsAsString();

            if (!string.IsNullOrWhiteSpace(newActors))
                selectedFilm.Acteurs = newActors;
        }

        UpdateField($"Regiseur ({selectedFilm.Regiseur}): ",
            value => selectedFilm.Regiseur = value);

        try
        {
            filmLogic.UpdateFilm(selectedFilm);

            Console.WriteLine();
            Console.WriteLine($"Film '{selectedFilm.Naam}' has been updated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void UpdateField(string prompt, Action<string> setter)
    {
        Console.Write(prompt);

        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
            setter(input.Trim());
    }

    private static void UpdateIntField(string prompt, Action<int> setter)
    {
        Console.Write(prompt);

        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return;

        if (int.TryParse(input, out int value))
        {
            setter(value);
        }
        else
        {
            Console.WriteLine("Invalid number, keeping old value.");
        }
    }

    private static string GetActorsAsString()
    {
        List<string> actors = new List<string>();

        while (true)
        {
            Console.Write("Actor (type 'done' to stop): ");

            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                continue;

            if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                break;

            input = input.Replace(";", "").Replace(",", "");

            if (!actors.Contains(input, StringComparer.OrdinalIgnoreCase))
                actors.Add(input);
            else
                Console.WriteLine("Actor already added.");
        }

        return string.Join(", ", actors);
    }
}