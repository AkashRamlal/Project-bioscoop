public static class EditAccountLogic
{
    private static AccountsAccess _access = new();

    public static void EditName(AccountModel acc, string newFirstName, string newLastName)
    {
        acc.Naam = newFirstName;
        acc.Achternaam = newLastName;

        _access.Update(acc);
    }

    public static void EditPhoneNumber(AccountModel acc, string newPhoneNumber)
    {
        acc.Telefoonnummer = newPhoneNumber;

        _access.Update(acc);
    }

    public static void EditEmail(AccountModel acc, string newEmail)
    {
        acc.Email = newEmail;

        _access.Update(acc);
    }

    public static void EditPassword(AccountModel acc, string newPassword)
    {
        acc.Password = newPassword;

        _access.Update(acc);
    }

    public static void EditDiet(AccountModel acc, string? allergies, string? dietaryNeeds, string? comments)
    {
        acc.Allergie = allergies;
        acc.Dieet = dietaryNeeds;
        acc.Opmerkingen = comments;

        _access.Update(acc);
    }

    public static void ForgotPassword(string email)
    {
        AccountModel acc = _access.GetByEmail(email);

        if (acc == null)
        {
            Console.WriteLine("No account found with that email.");
            return;
        }

        Console.WriteLine("Enter your new password:");
        string newPassword = Console.ReadLine()!;

        acc.Password = newPassword;
        _access.Update(acc);

        Console.WriteLine("Password has been changed successfully.");
    }
}