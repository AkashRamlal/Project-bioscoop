using System.Globalization;


static class RegisterUser
{
        public static void Start()
        {
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("║          REGISTER USER               ║");
            Console.WriteLine("║                                      ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            

            // geboortedat

            // password mag niet leeg zijn
            
            

            
            

            // create acount here
            AccountModel account = new AccountModel();
            AccountsLogic logic = new AccountsLogic();
            
            while (true)
            {
                Console.WriteLine("Please enter your first name:");
                string? firstName = Console.ReadLine();

                account.Naam = firstName ?? "";

                string result = logic.ValidateFirstName(account.Naam);

                if (result == "Success")
                    break;

                Console.WriteLine(result);
            }

            while (true)
            {
                Console.WriteLine("Please enter your last name:");
                string? lastName = Console.ReadLine();

                account.Achternaam = lastName ?? "";

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
                string? telefoonnummer = Console.ReadLine();

                account.Telefoonnummer = telefoonnummer ?? "";

                string result = logic.ValidateTelefoonnummer(account.Telefoonnummer);

                if (result == "Success")
                    break;

                Console.WriteLine(result);
            }

            while (true)
        {
            Console.WriteLine("please enter your email address:");
            string? emailInput = Console.ReadLine();
            if (logic.ValidateEmail(emailInput) == "Success")
            {
                account.Email = emailInput;
                break;
            }
            Console.WriteLine("Invalid email address. Please try again.");
        }

            

            

            while (true)
            {
                Console.WriteLine("Please enter your password:");
                string? password = Console.ReadLine();

                account.Password = password ?? "";

                string result = logic.ValidatePassword(account);

                if (result == "Success")
                    break;

                Console.WriteLine(result);
            }

            
            Console.WriteLine(logic.RegisterMember(account));

            logic.RegisterMember(account);
            

            
        
            
        }
}