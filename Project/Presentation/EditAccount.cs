using System.ComponentModel.DataAnnotations;

public static class EditAccount
{
    private static List<String> Options = [
        "Edit name",
        "Change phone number",
        "Change Email",
        "Change password",
        "Change dietary preferences",
        "Return to menu"
    ];

    public static void Start(AccountModel acc)
    {
        bool inMenu = true;

        while (inMenu)
        {
            string choice = ShowMenu($"{acc.Naam} {acc.Achternaam}");

            Console.Clear();

            switch (choice)
            {
                case "Edit name":
                    string firstName;
                    string lastName;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your first name:");
                        firstName = Console.ReadLine();
                    }
                    while (!EditAccountLogic.IsValidName(firstName));

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your last name:");
                        lastName = Console.ReadLine();
                    }
                    while (!EditAccountLogic.IsValidName(lastName));

                    EditAccountLogic.EditName(acc, firstName, lastName);
                    Console.WriteLine("Name updated successfully.");
                    break;

                case "Change phone number":
                    string phoneNumber;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your new phone number (numbers only):");
                        phoneNumber = Console.ReadLine();
                    }
                    while (!EditAccountLogic.IsValidPhoneNumber(phoneNumber));

                    EditAccountLogic.EditPhoneNumber(acc, phoneNumber);
                    Console.WriteLine("Phone number updated successfully.");
                    break;

                case "Change Email":
                    string email;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your new email:");
                        email = Console.ReadLine();
                    }
                    while (!EditAccountLogic.IsValidEmail(email));

                    EditAccountLogic.EditEmail(acc, email);
                    Console.WriteLine("Email updated successfully.");
                    break;

                case "Change password":
                    string password;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter your new password:");
                        password = Console.ReadLine();
                    }
                    while (!EditAccountLogic.IsValidPassword(password));

                    EditAccountLogic.EditPassword(acc, password);
                    Console.WriteLine("Password updated successfully.");
                    break;
                
                case "Change dietary preferences":
                    Console.WriteLine("Your current information:");
                    string? allergie = acc.Allergie is null ? "No allergies" : acc.Allergie;
                    Console.WriteLine($"Allergies: {allergie}");
                    string? diets = acc.Dieet is null ? "No preferences" : acc.Dieet;
                    Console.WriteLine($"Dietary preferences: {diets}");
                    string? comment = acc.Opmerkingen is null ? "No additional comments" : acc.Opmerkingen;
                    Console.WriteLine($"Additional comments: {comment}");
                    Console.WriteLine();

                    string? allergies = Diet.AskForAllergies();
                    string? diet = Diet.AskForDietaryPreferences();
                    string? comments = Diet.AskForAdditionalComments();
                    EditAccountLogic.EditDiet(acc, allergies, diet, comments);
                    break;
                
                case "Return to menu":
                    inMenu = false;
                    break;
                
                default:
                    inMenu = false;
                    break;
            }
            
            if (inMenu)
            {
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }

    private static string ShowMenu(string name)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            DrawMenu(Options, selectedIndex, name);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = Options.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= Options.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return Options[selectedIndex];
    }

    private static void DrawMenu(List<string> options, int selectedIndex, string name)
    {
        Console.Clear();

        Console.WriteLine("=====================================");
        Console.WriteLine("      Edit account information");
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