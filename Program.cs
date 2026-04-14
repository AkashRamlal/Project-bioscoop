class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            string choice = WelcomeScreen.Menu();

            Console.Clear();

            if (choice == "Login")
            {
                UserLogin.Start();
            }
            else if (choice == "Continue as Guest")
            {
                Menu.Start("Guest");
            }

            Console.WriteLine("\nPress ESC to quit or any other key to return...");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                running = false;
        }
    }
}