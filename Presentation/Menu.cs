public static class Menu
{
    public static void Start(string role)
{
    Auditorium hall1 = new Auditorium();

    Dictionary<string, Dictionary<string, decimal>> hallData = new Dictionary<string, Dictionary<string, decimal>> {
        { "Hall 1", new Dictionary<string, decimal> { { "A3", 10.00m }, { "B5", 12.50m } } }
    };

    bool inMenu = true;

    while (inMenu)
    {
        string choice = ShowMenu(role);

        Console.Clear();

        switch (choice)
        {
            case "Movie theatre info":
                Console.WriteLine("pizza");
                break;

            case "View movies":
                hall1.StartSelection();
                PaymentUI.Start("filmName", "00:00", hallData);
                break;

            case "Your tickets":
                Console.WriteLine("pizza");
                break;

            case "Manage films":
                Console.WriteLine("pizza");
                break;

            case "Manage tickets":
                Console.WriteLine("pizza");
                break;

            case "Manage employees":
                Console.WriteLine("pizza");
                break;

            case "Quit":
                inMenu = false;
                continue;
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
    public static string ShowMenu(string role)
    {
        List<string> menuOptions = GetOptions(role);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex, role);

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

    private static List<string> GetOptions(string role)
    {
        List<string> options = [];

        // Member
        options.Add("Movie theatre info");
        options.Add("View movies");
        options.Add("Your tickets");
        

        // Employee
        if (role == "employee" || role == "admin")
        {
            options.Add("Manage films");
            options.Add("Manage tickets");
        }

        // Admin
        if (role == "admin")
        {
            options.Add("Manage employees");
        }

        options.Add("Quit");

        return options;
    }

    private static void DrawMenu(List<string> options, int selectedIndex, string role)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("         Movie theatre Menu");
        Console.WriteLine("=====================================\n");

        Console.WriteLine($"You are logged in as: {role}");

        Console.WriteLine("Use arrow keys to navigate and press Enter to select option:\n");

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