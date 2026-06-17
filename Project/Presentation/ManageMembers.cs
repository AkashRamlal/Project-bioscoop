static class ManageMembers
{
    public static void Start()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║           Manage Members             ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        var Members = new AccountsAccess().GetAllMembers();
        
        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-30}","ID", "Naam", "Achternaam", "Email");
        Console.WriteLine(new string('-', 80));

        foreach (var member in Members)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-30}",
                member.Id,
                member.Naam,
                member.Achternaam,
                member.Email);

            Console.WriteLine(new string('-', 80));
        }
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("1. Add Member");
        Console.WriteLine("2. Edit Member");
        Console.WriteLine("3. Delete Member");

        if (int.TryParse(Console.ReadLine(), out int option))
        {
            switch (option)
            {
                case 1:
                    CreateMember.Start();
                    break;
                case 2:
                    EditMembers.Start();
                    break;
                case 3:
                    RemoveMember.Start();
                    break;
                
                default:
                    Console.WriteLine("Invalid option. Returning to main menu.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to main menu.");
        }
    }
}