static class ManageFilms
{
    public static void Show()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║           Manage Movies              ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        
        var films = new FilmAccess().GetAll();

        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}","ID", "Naam", "Genre", "Tijdsduur", "Leeftijdsgrens", "Acteurs");
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

            Console.WriteLine(new string('-', 110));
            
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("1. Add Movie");
        Console.WriteLine("2. Edit Movie");
        Console.WriteLine("3. Delete Movie");

        if (int.TryParse(Console.ReadLine(), out int option))
        {
            switch (option)
            {
                case 1:
                    CreateFilm.Start();
                    break;

                case 2:
                    EditFilm.Start();
                    break;
                
                case 3:
                    RemoveFilm.Start();
                    break;
                
                default:
                    Console.WriteLine("Invalid option. Returning to main menu.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to main menu.");
        }
        
    }
}
    