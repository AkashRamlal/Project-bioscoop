public class Program
{
    public static void Main()
    {
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
                    Menu.Start(user.FullName);
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
    }
}