static class CreateFilm
{
    public static void Start()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║              CREATE FILM             ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();

        string? naam;
        do
        {
            Console.Write("Film name: ");
            naam = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(naam))
                Console.WriteLine("Film name is required.");
        }
        while (string.IsNullOrWhiteSpace(naam));

        string? genre;
        do
        {
            Console.Write("Genre: ");
            genre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(genre))
                Console.WriteLine("Genre is required.");
        }
        while (string.IsNullOrWhiteSpace(genre));

        int tijdsduur;
        do
        {
            Console.Write("Duration (minutes): ");

            if (int.TryParse(Console.ReadLine(), out tijdsduur) && tijdsduur > 0)
                break;

            Console.WriteLine("Duration must be greater than 0.");
        }
        while (true);

        int leeftijdsgrens;
        do
        {
            Console.Write("Age restriction: ");

            if (int.TryParse(Console.ReadLine(), out leeftijdsgrens) && leeftijdsgrens >= 0)
                break;

            Console.WriteLine("Age restriction cannot be negative.");
        }
        while (true);

        string? regiseur;
        do
        {
            Console.Write("Director: ");
            regiseur = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(regiseur))
                Console.WriteLine("Director is required.");
        }
        while (string.IsNullOrWhiteSpace(regiseur));

        string acteurs = GetActorsAsString();

        FilmLogic filmLogic = new FilmLogic();

        try
        {
            FilmModel film = filmLogic.CreateFilm(
                naam,
                genre,
                tijdsduur,
                leeftijdsgrens,
                acteurs,
                regiseur);

            filmLogic.AddFilm(film);

            Console.WriteLine();
            Console.WriteLine("Film saved!");
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static string GetActorsAsString()
    {
        List<string> actors = new List<string>();
        string? input;

        while (true)
        {
            Console.Write("Actor (done to stop): ");
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                continue;

            if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                if (actors.Count == 0)
                {
                    Console.WriteLine("You must add at least one actor.");
                    continue;
                }

                break;
            }

            input = input.Replace(";", "").Replace(",", "");

            if (!actors.Contains(input, StringComparer.OrdinalIgnoreCase))
                actors.Add(input);
            else
                Console.WriteLine("Actor already added.");
        }

        return string.Join(", ", actors);
    }
}