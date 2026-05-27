public static class WelcomeScreen
{
    public static string Menu(List<FilmModel> films)
    {
        List<string> menuOptions = [
            "Login",
            "Continue as Guest",
            "register",
        ];

        int selectedIndex = 0;
        ConsoleKey key;

        List<string> previewFilms = WelcomeLogic.PreviewFilms(films);

        do
        {
            DrawMenu(menuOptions, selectedIndex, previewFilms);

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

    private static void DrawMenu(List<string> options, int selectedIndex, List<string> films)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("     Welcome to Theatre Rotterdam");
        Console.WriteLine("=====================================\n");

        Console.WriteLine("Some films currently playing:");
        foreach (var film in films)
        {
            Console.WriteLine($" - {film}");
        }

        Console.WriteLine("\nUse arrow keys to navigate and press Enter to select option:\n");

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