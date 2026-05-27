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

    public static string? AskForDietaryNeeds()
    {
        Console.WriteLine("Enter dietary needs (press ENTER to submit entry, leave field empty when finished):");

        List<string> dietaryNeeds = new List<string>();

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
                dietaryNeeds.Add(input.Trim());
            }
        }

        return dietaryNeeds.Count > 0 ? string.Join(";", dietaryNeeds) : null;
    }

    public static string? AskForAdditionalComments()
    {
        Console.WriteLine("Enter additional comments:");
        Console.Write("> ");

        string? input = Console.ReadLine();

        return string.IsNullOrWhiteSpace(input) ? null : input.Trim();
    }
}