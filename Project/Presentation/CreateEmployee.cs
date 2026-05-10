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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter your first name");
            string? naam = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            string? achternaam = Console.ReadLine();


            // geboortedatum input handling
            DateTime Geboortedatum;
            string? geboortedatumInput;

            Console.WriteLine("Please enter your date of birth (DD-MM-YYYY)");
            geboortedatumInput = Console.ReadLine();
            while(!DateTime.TryParseExact(geboortedatumInput,"dd-MM-yyyy",CultureInfo.InvariantCulture, DateTimeStyles.None, out Geboortedatum))
            {
                Console.WriteLine("Invalid date format. Please enter your date of birth (DD-MM-YYYY)");
                geboortedatumInput = Console.ReadLine();
            }


            // telefoonnummer input handling
            Console.WriteLine("Please enter your phone number");
            string? telefoonnummer = Console.ReadLine();
            Console.WriteLine("Please enter your email address");
            string? email = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string? password = Console.ReadLine();
            

            // create acount here
            AccountModel account = new AccountModel();
            account.Naam = naam ?? "";
            account.Achternaam = achternaam ?? "";
            account.Geboortedatum = Geboortedatum;
            account.Telefoonnummer = telefoonnummer ?? "";
            account.Email = email ?? "";
            account.Password = password ?? "";

            AccountsLogic logic = new AccountsLogic();
            logic.RegisterEmployee(account);

            
        
            
        }
}