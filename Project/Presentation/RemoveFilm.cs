public static class RemoveFilm
{
    public static void Start()
    {
        var films = new FilmAccess().GetAll();
        Console.WriteLine("Select a film to delete:");

        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}","ID", "Naam", "Genre", "Tijdsduur", "Leeftijdsgrens", "Acteurs");
        Console.WriteLine(new string('-', 110));
        for (int i = 0; i < films.Count; i++)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-15} {4,-15} {5,-30}",
                films[i].Id,
                films[i].Naam,
                films[i].Genre,
                films[i].Tijdsduur,
                films[i].Leeftijdsgrens,
                films[i].Acteurs);
        }
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= films.Count)
        {
            var selectedFilm = films[choice - 1];
            new FilmAccess().Delete(selectedFilm);
            Console.WriteLine($"Film '{selectedFilm.Naam}' has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection. No film deleted.");
        }
        
    }
       
}