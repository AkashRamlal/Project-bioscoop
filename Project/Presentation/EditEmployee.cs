public static class EditEmployees
{
    private static AccountsAccess _access = new();

    public static void Start()
    {
        List<AccountModel> employees = _access.GetAllEmployees();

        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("Select an employee to edit:");
        Console.WriteLine();

        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15} {5,-25}",
            "ID", "Naam", "Achternaam", "Geboortedatum", "Telefoon", "Email");
        Console.WriteLine(new string('-', 80));

        foreach (AccountModel emp in employees)
        {
            Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15} {5,-25}",
                emp.Id,
                emp.Naam,
                emp.Achternaam,
                emp.Geboortedatum.ToString("dd-MM-yyyy"),
                emp.Telefoonnummer,
                emp.Email);
                Console.WriteLine(new string('-', 80));
        }

        Console.WriteLine();
        Console.Write("Enter employee ID: ");

        if (!long.TryParse(Console.ReadLine(), out long id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        AccountModel? selectedEmployee = employees.FirstOrDefault(e => e.Id == id);

        if (selectedEmployee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("What do you want to edit?");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Phone number");
        Console.WriteLine("3. Email");
        Console.WriteLine("4. Password");
        Console.WriteLine("5. Diet / allergies / comments");
        Console.WriteLine("0. Cancel");

        Console.Write("Choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("New first name: ");
                string newFirstName = Console.ReadLine()!;

                Console.Write("New last name: ");
                string newLastName = Console.ReadLine()!;

                EditAccountLogic.EditName(selectedEmployee, newFirstName, newLastName);
                Console.WriteLine("Name updated.");
                break;

            case "2":
                Console.Write("New phone number: ");
                string newPhoneNumber = Console.ReadLine()!;

                EditAccountLogic.EditPhoneNumber(selectedEmployee, newPhoneNumber);
                Console.WriteLine("Phone number updated.");
                break;

            case "3":
                Console.Write("New email: ");
                string newEmail = Console.ReadLine()!;

                EditAccountLogic.EditEmail(selectedEmployee, newEmail);
                Console.WriteLine("Email updated.");
                break;

            case "4":
                Console.Write("New password: ");
                string newPassword = Console.ReadLine()!;

                EditAccountLogic.EditPassword(selectedEmployee, newPassword);
                Console.WriteLine("Password updated.");
                break;

            case "5":
                Console.Write("Allergies: ");
                string? allergies = Console.ReadLine();

                Console.Write("Dietary needs: ");
                string? dietaryNeeds = Console.ReadLine();

                Console.Write("Comments: ");
                string? comments = Console.ReadLine();

                EditAccountLogic.EditDiet(selectedEmployee, allergies, dietaryNeeds, comments);
                Console.WriteLine("Diet information updated.");
                break;

            case "0":
                Console.WriteLine("Cancelled.");
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}