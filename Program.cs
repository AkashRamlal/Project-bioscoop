
public class Program
{
    public static void Main()
    {
        /*
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool running = true;

        while (running)
        {
            string choice = WelcomeScreen.Menu();
            Console.Clear();

            if (choice == "Login")
            {
                var user = UserLogin.Start();

                if (user != null)
                {
                    Menu.Start($"{user.Naam} {user.Achternaam}");
                }
            }
            else if (choice == "Continue as Guest")
            {
                Menu.Start("guest");
            }

            Console.WriteLine("\nPress ESC to quit or any other key to return...");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                running = false;
        }
        */

        new Movie("Lion Queen", new List<string> {"12:00 Auditorium 1", "15:00 Auditorium 2 ", "20:00 Auditorium 3"});
        new Movie("Lilo & Boots", new List<string> {"11:00 Auditorium 2", "14:00 Auditorium 3", "17:00 Auditorium 2"});
        new Movie("101 Monkeys", new List<string> {"13:00 Auditorium 2", "15:00 Auditorium 1", "19:00 Auditorium 2"});
        new Movie("The Conjurings", new List<string> {"22:00 Auditorium 3", "00:00 Auditorium 2", "18:00 Auditorium 1"});

        string gekozenTitel = Movie.ArrowOptions(Movie.Movies);
        List<string> beschikbareTijden = Movie.MoviesDict[gekozenTitel];
        string gekozenTijd = Movie.ArrowOptions(beschikbareTijden);

        Movie.RunAuditorium( gekozenTitel, gekozenTijd);

    }
}