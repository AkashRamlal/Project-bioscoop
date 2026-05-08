public static class EditAccountLogic
{

    private static AccountsAccess _access = new();
    public static void EditName(AccountModel acc, string newFirstName, string newLastName)
    {
        acc.Naam = newFirstName;
        acc.Achternaam = newLastName;

        _access.Update(acc);
    }
}