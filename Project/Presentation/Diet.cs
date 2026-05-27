public static class Diet
{
    public static string? AskForAllergies()
    {
        Console.WriteLine("Enter allergies (press ENTER to submit entry, leave field empty when finished):");

        List<string> allergies = new List<string>();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(input))
            {
                allergies.Add(input.Trim());
            }
        }

        return allergies.Count > 0 ? string.Join(";", allergies) : null;
    }

    public static string? AskForDietaryPreferences()
    {
        Console.WriteLine("Enter dietary preferences (press ENTER to submit entry, leave field empty when finished):");

        List<string> dietaryPreferences = new List<string>();

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(input))
            {
                dietaryPreferences.Add(input.Trim());
            }
        }

        return dietaryPreferences.Count > 0 ? string.Join(";", dietaryPreferences) : null;
    }

    public static string? AskForAdditionalComments()
    {
        Console.WriteLine("Enter additional comments:");
        Console.Write("> ");

        string? input = Console.ReadLine();

        return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
    }
}