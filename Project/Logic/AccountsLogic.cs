

//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic
{

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    public static AccountModel? CurrentAccount { get; private set; }
    private AccountsAccess _access = new();

    public AccountsLogic()
    {
        // Could do something here

    }

    public void Registermember(AccountModel account)
    {

        if(string.IsNullOrWhiteSpace(account.Naam))
        {
            Console.WriteLine("a first name is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Achternaam))
        {
            Console.WriteLine("a last name is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Email))
        {
            Console.WriteLine("an email is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Password) || account.Password.Length < 6)
        {
            Console.WriteLine("a password should be at least 6 characters long");
            return;
        }

        account.Role = Roles.Member;

        // send to logic to write to database
        _access.Write(account);
    }

    public void RegisterEmployee(AccountModel account)
    {

        if (string.IsNullOrWhiteSpace(account.Naam))
        {
            Console.WriteLine("a first name is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Achternaam))
        {
            Console.WriteLine("a last name is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Email))
        {
            Console.WriteLine("an email is required");
            return;
        }
        if (string.IsNullOrWhiteSpace(account.Password) || account.Password.Length < 6)
        {
            Console.WriteLine("a password should be at least 6 characters long");
            return;
        }

        account.Role = Roles.Employee;

        // send to logic to write to database
        _access.Write(account);
    }

    public AccountModel CheckLogin(string email, string password)
    {


        AccountModel acc = _access.GetByEmail(email);
        if (acc != null && acc.Password == password)
        {
            CurrentAccount = acc;
            return acc;
        }
        return null!;
    }
}




