public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        bool running = true;

        FilmAccess filmAccess = new FilmAccess();

        List<FilmModel> films = filmAccess.GetAll();

        while (running)
        {
            string choice = WelcomeScreen.Menu(films);
            Console.Clear();

            if (choice == "Login")
            {
                var user = UserLogin.Start();

                if (user != null)
                {
                    Menu.Start(user);
                }
            }
            else if (choice == "Continue as Guest")
            {
                Menu.Start();
            }
            else if (choice == "register")
            {
                RegisterUser.Start();
            }
        

            Console.WriteLine("\nPress ESC to quit or any other key to return to menu...");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                running = false;
        }
    }
}