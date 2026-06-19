static class ManageEmployee
{
    public static void Display()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("║           Manage Employees           ║");
        Console.WriteLine("║                                      ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        var Employees = new AccountsAccess().GetAllEmployees();


        Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-30}","ID", "Naam", "Achternaam", "Email");

        Console.WriteLine(new string('-', 80));

        foreach (var employee in Employees)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-20} {3,-30}",
                employee.Id,
                employee.Naam,
                employee.Achternaam,
                employee.Email);

            Console.WriteLine(new string('-', 80));
        }
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Edit Employee");
        Console.WriteLine("3. Delete Employee");

        if (int.TryParse(Console.ReadLine(), out int option))
        {
            switch (option)
            {
                case 1:
                    CreateEmployee.Start();
                    break;
                case 2:
                    EditEmployees.Start();
                    break;
                case 3:
                    RemoveEmployee.Start();
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