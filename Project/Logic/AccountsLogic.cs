

//This class is not static so later on we can use inheritance and interfaces



    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself




public class AccountsLogic
{
    public static AccountModel? CurrentAccount { get; private set; }

    private AccountsAccess _access = new();

    public string RegisterMember(AccountModel account)
    {
        string validationMessage = ValidateAccount(account);

        if (validationMessage != "Success")
        {
            return validationMessage;
        }

        account.Role = Roles.Member;
        _access.Write(account);

        return "Account registered successfully";
    }

    public string RegisterEmployee(AccountModel account)
    {
        string validationMessage = ValidateAccount(account);

        if (validationMessage != "Success")
        {
            return validationMessage;
        }

        account.Role = Roles.Employee;
        _access.Write(account);

        return "Employee registered successfully";
    }

    private string ValidateAccount(AccountModel account)
    {
        if (string.IsNullOrWhiteSpace(account.Naam))
            return "A first name is required";

        if (string.IsNullOrWhiteSpace(account.Achternaam))
            return "A last name is required";

        if (string.IsNullOrWhiteSpace(account.Email))
            return "An email is required";

        if (string.IsNullOrWhiteSpace(account.Password) || account.Password.Length < 6)
            return "A password should be at least 6 characters long";

        return "Success";
    }

    public AccountModel? CheckLogin(string email, string password)
    {
        AccountModel? acc = _access.GetByEmail(email);

        if (acc != null && acc.Password == password)
        {
            CurrentAccount = acc;
            return acc;
        }

        return null;
    }
}