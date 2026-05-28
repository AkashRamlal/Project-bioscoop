public static class RemoveEmployee
{
    public static void Start()
    {
        var employees = new AccountsAccess().GetAllEmployees();
        Console.WriteLine("Select an employee to delete:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {employees[i].Naam} {employees[i].Achternaam}");
        }
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= employees.Count)
        {
            var selectedEmployee = employees[choice - 1];
            new AccountsAccess().Delete(selectedEmployee);
            Console.WriteLine($"Employee {selectedEmployee.Naam} {selectedEmployee.Achternaam} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid selection. No employee deleted.");
        }
        
    }
       
}