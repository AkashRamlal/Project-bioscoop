public static class Menu
{
    public static void Start(AccountModel acc)
{
    Auditorium hall1 = new Auditorium("Auditorium 1");

    Dictionary<string, Dictionary<string, decimal>> hallData = new Dictionary<string, Dictionary<string, decimal>> {
        { "Hall 1", new Dictionary<string, decimal> { { "A3", 10.00m }, { "B5", 12.50m } } }
    };

    bool inMenu = true;

    while (inMenu)
    {
        string choice = ShowMenu(acc);

        Console.Clear();

        switch (choice)
        {
            case "Movie theatre info":
                TheatreInfo.Print();
                break;

            case "View movies":
                hall1.StartSelection();
                var paymentUI = new PaymentUI(false);
                paymentUI.StartAsMember("filmName", "00:00", hallData, "luna@domain.com");
                break;

            case "Your tickets":
                Console.WriteLine("Placeholder");
                break;

            case "Edit account information":
                EditAccount.Start(acc);
                break;

            case "Create film":
                CreateFilm.Start();
                break;

            case "Manage films":
                Console.WriteLine("Placeholder");
                break;

            case "Manage tickets":
                Console.WriteLine("Placeholder");
                break;

            case "Create employee":
                RegisterUser.Start();
                break;

            case "Manage employees":
                Console.WriteLine("Placeholder");
                break;

            case "Quit":
                inMenu = false;
                continue;
        }

        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
    public static string ShowMenu(AccountModel acc)
    {
        List<string> menuOptions = GetOptions(acc.Role);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex, $"{acc.Naam} {acc.Achternaam}");

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

    // Start for Guest
    public static void Start()
    {
        Auditorium hall1 = new Auditorium("Auditorium 1");

        Dictionary<string, Dictionary<string, decimal>> hallData = new Dictionary<string, Dictionary<string, decimal>> {
            { "Hall 1", new Dictionary<string, decimal> { { "A3", 10.00m }, { "B5", 12.50m } } }
        };

        bool inMenu = true;

        while (inMenu)
        {
            string choice = ShowMenu();

            Console.Clear();

            switch (choice)
            {
                case "Movie theatre info":
                    TheatreInfo.Print();
                    break;

                case "View movies":
                    var paymentUI = new PaymentUI(false);
                    paymentUI.StartAsMember("filmName", "00:00", hallData, "luna@domain.com");
                    hall1.StartSelection();
                    break;

                case "Your tickets":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage films":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage tickets":
                    Console.WriteLine("Placeholder");
                    break;

                case "Manage employees":
                    Console.WriteLine("Placeholder");
                    break;

                case "Quit":
                    inMenu = false;
                    continue;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }

    public static string ShowMenu()
    {
        List<string> menuOptions = GetOptions(null);

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(menuOptions, selectedIndex, "guest");

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

    private static List<string> GetOptions(Roles? role)
    {
        List<string> options = [];

        // Guest
        options.Add("Movie theatre info");
        options.Add("View movies");
        options.Add("Your tickets");

        // Member
        if (role == Roles.Member || role == Roles.Employee || role == Roles.Admin)
        options.Add("Edit account information");
        

        // Employee
        if (role == Roles.Employee || role == Roles.Admin)
        {
            options.Add("Create film");
            options.Add("Manage films");
            options.Add("Manage tickets");
        }

        // Admin
        if (role == Roles.Admin)
        {
            options.Add("Create employee");
            options.Add("Manage employees");
        }

        options.Add("Quit");

        return options;
    }

    private static void DrawMenu(List<string> options, int selectedIndex, string name)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("         Movie theatre Menu");
        Console.WriteLine("=====================================\n");

        Console.WriteLine($"You are logged in as: {name}");

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