public class SearchFilm
{
    private FilmAccess _filmAccess;
    private FilterSearch _filterSearch;

    public SearchFilm()
    {
        _filmAccess = new FilmAccess();
        _filterSearch = new FilterSearch();
    }

    public void Search()
    {
        List<FilmModel> films = _filmAccess.GetAll();

        string choice = SelectSearchMethod();

        switch (choice)
        {
            case "Search by title":
                Console.Clear();
                Console.Write("Enter title: ");
                string title = Console.ReadLine() ?? "";

                ShowResults(
                    _filterSearch.FilterByTitle(films, title));
                break;

            case "Search by genre":
                Console.Clear();
                Console.Write("Enter genre: ");
                string genre = Console.ReadLine() ?? "";

                ShowResults(
                    _filterSearch.FilterByGenre(films, genre));
                break;

            case "Search by actor":
                Console.Clear();
                Console.Write("Enter actor: ");
                string actor = Console.ReadLine() ?? "";

                ShowResults(
                    _filterSearch.FilterByActor(films, actor));
                break;

            case "Search by director":
                Console.Clear();
                Console.Write("Enter director: ");
                string director = Console.ReadLine() ?? "";

                ShowResults(
                    _filterSearch.FilterByDirector(films, director));
                break;

            case "Search by age restriction":
                Console.Clear();
                Console.Write("Enter age restriction: ");

                if (int.TryParse(Console.ReadLine(), out int ageRestriction))
                {
                    ShowResults(
                        _filterSearch.FilterByAgeRestriction(
                            films,
                            ageRestriction));
                }
                else
                {
                    Console.WriteLine("Invalid age restriction.");
                }
                break;

            case "Back":
                return;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private string SelectSearchMethod()
    {
        List<string> options = new()
        {
            "Search by title",
            "Search by genre",
            "Search by actor",
            "Search by director",
            "Search by age restriction",
            "Back"
        };

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            Console.WriteLine("=====================================");
            Console.WriteLine("            Search Films");
            Console.WriteLine("=====================================\n");

            Console.WriteLine("Select a search method:\n");

            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;

            if (key == ConsoleKey.DownArrow)
                selectedIndex = (selectedIndex + 1) % options.Count;

        } while (key != ConsoleKey.Enter);

        return options[selectedIndex];
    }

    private void ShowResults(List<FilmModel> films)
    {
        Console.Clear();

        if (films.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No films found.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine($"Found {films.Count} film(s)\n");

        Console.WriteLine(
            "{0,-5} {1,-25} {2,-15} {3,-12} {4,-10} {5,-30} {6,-20}",
            "ID",
            "Naam",
            "Genre",
            "Tijdsduur",
            "Leeftijd",
            "Acteurs",
            "Regisseur"
        );

        Console.WriteLine(new string('-', 140));

        foreach (var film in films)
        {
            Console.WriteLine(
                "{0,-5} {1,-25} {2,-15} {3,-12} {4,-10} {5,-30} {6,-20}",
                film.Id,
                film.Naam,
                film.Genre,
                film.Tijdsduur,
                film.Leeftijdsgrens,
                film.Acteurs,
                film.Regiseur
            );
        }

        Console.WriteLine(new string('-', 140));
    }
}