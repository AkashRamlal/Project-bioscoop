public static class WelcomeScreen
{
    public static string Menu()
    {
        List<string> menuOptions = [
            "Login",
            "Continue as Guest"
        ];

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = menuOptions.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= menuOptions.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return menuOptions[selectedIndex];
    }

    private static void DrawMenu(List<string> options, int selectedIndex)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("      Welcome to Pathé from Temu");
        Console.WriteLine("=====================================\n");

        Console.WriteLine("Films currently playing:\n");
        Console.WriteLine("- Super Mario Galaxy Movie");
        Console.WriteLine("- Oppenheimer");
        Console.WriteLine("- Spoderman");
        Console.WriteLine("- Zootropia 2\n");

        Console.WriteLine("Use arrow keys to navigate and press Enter to select option:\n");

        // Menu
        for (int i = 0; i < options.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
    }
}