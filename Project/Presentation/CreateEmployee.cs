using System.Globalization;

static class CreateEmployee
{
    public static void Start()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║          CREATE EMPLOYEE             ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();

        AccountModel account = new AccountModel();
        AccountsLogic logic = new AccountsLogic();

        while (true)
        {
            Console.WriteLine("Please enter your first name:");
            account.Naam = Console.ReadLine() ?? "";

            string result = logic.ValidateFirstName(account.Naam);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        while (true)
        {
            Console.WriteLine("Please enter your last name:");
            account.Achternaam = Console.ReadLine() ?? "";

            string result = logic.ValidateLastName(account.Achternaam);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        while (true)
        {
            Console.WriteLine("Please enter your date of birth (DD-MM-YYYY):");
            string? geboortedatumInput = Console.ReadLine();

            bool validDate = DateTime.TryParseExact(
                geboortedatumInput,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime geboortedatum
            );

            if (!validDate)
            {
                Console.WriteLine("Invalid date format. Use DD-MM-YYYY.");
                continue;
            }

            account.Geboortedatum = geboortedatum;

            string result = logic.ValidateGeboortedatum(account.Geboortedatum);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        while (true)
        {
            Console.WriteLine("Please enter your phone number:");
            account.Telefoonnummer = Console.ReadLine() ?? "";

            string result = logic.ValidateTelefoonnummer(account.Telefoonnummer);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        while (true)
        {
            Console.WriteLine("Please enter your email address:");
            account.Email = Console.ReadLine() ?? "";

            string result = logic.ValidateEmail(account.Email);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        while (true)
        {
            Console.WriteLine("Please enter your password:");
            account.Password = Console.ReadLine() ?? "";

            string result = logic.ValidatePassword(account);

            if (result == "Success")
                break;

            Console.WriteLine(result);
        }

        Console.WriteLine(logic.RegisterEmployee(account));
    }
}