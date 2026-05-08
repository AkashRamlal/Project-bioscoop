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

        Console.Write("Film name: ");
        string? naam = Console.ReadLine()?.Trim();

        Console.Write("Genre: ");
        string? genre = Console.ReadLine()?.Trim();

        Console.Write("Duration (minutes): ");
        int tijdsduur;
        while (!int.TryParse(Console.ReadLine(), out tijdsduur))
        {
            Console.Write("Invalid input. Enter duration: ");
        }

        Console.Write("Age restriction: ");
        int leeftijdsgrens;
        while (!int.TryParse(Console.ReadLine(), out leeftijdsgrens))
        {
            Console.Write("Invalid input. Enter age: ");
        }

        Console.Write("Director: ");
        string? regiseur = Console.ReadLine()?.Trim();

        string acteurs = GetActorsAsString();

        // 👇 explicit types instead of var
        FilmLogic logic = new FilmLogic();
        FilmAccess access = new FilmAccess();

        FilmModel film = logic.CreateFilm(
            naam,
            genre,
            tijdsduur,
            leeftijdsgrens,
            acteurs,
            regiseur
        );

        access.Write(film);

        Console.WriteLine("\n Film saved!");
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