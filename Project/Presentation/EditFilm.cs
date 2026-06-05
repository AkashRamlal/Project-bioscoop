public static class EditFilm
{
    public static void Start()
    {
        var filmAccess = new FilmAccess();
        var films = filmAccess.GetAll();

        Console.WriteLine("Select a film to edit:");
        Console.WriteLine();

        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}",
            "ID", "Naam", "Genre", "Tijdsduur", "Leeftijdsgrens", "Acteurs");

        Console.WriteLine(new string('-', 110));

        foreach (var film in films)
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

        var selectedFilm = films.FirstOrDefault(f => f.Id == filmId);

        if (selectedFilm == null)
        {
            Console.WriteLine("Film not found.");
            return;
        }

        Console.WriteLine();

        UpdateField($"Naam ({selectedFilm.Naam}): ", v => selectedFilm.Naam = v);
        UpdateField($"Genre ({selectedFilm.Genre}): ", v => selectedFilm.Genre = v);
        UpdateField($"Tijdsduur ({selectedFilm.Tijdsduur}): ", v => selectedFilm.Tijdsduur = v);


        UpdateIntField(
            $"Leeftijdsgrens ({selectedFilm.Leeftijdsgrens}): ",
            v => selectedFilm.Leeftijdsgrens = v
        );

        Console.WriteLine($"Acteurs (current: {selectedFilm.Acteurs})");
        Console.Write("Do you want to edit actors? (y/n): ");

        if (Console.ReadLine()?.Trim().ToLower() == "y")
        {
            var newActors = GetActorsAsString();

            if (!string.IsNullOrWhiteSpace(newActors))
                selectedFilm.Acteurs = newActors;
        }

        UpdateField($"Regiseur ({selectedFilm.Regiseur}): ", v => selectedFilm.Regiseur = v);

        filmAccess.Update(selectedFilm);

        Console.WriteLine();
        Console.WriteLine($"Film '{selectedFilm.Naam}' has been updated.");
    }

    // string fields
    private static void UpdateField(string prompt, Action<string> setter)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
            setter(input);
    }

    // int fields (NEW)
    private static void UpdateIntField(string prompt, Action<int> setter)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

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
        string? input;

        while (true)
        {
            Console.Write("Actor (type 'done' to stop): ");
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                continue;

            if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                break;

            input = input.Replace(";", "");

            if (!actors.Contains(input, StringComparer.OrdinalIgnoreCase))
                actors.Add(input);
            else
                Console.WriteLine("Actor already added.");
        }

        return string.Join(";", actors);
    }
}