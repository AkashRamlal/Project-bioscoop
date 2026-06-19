

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

    
    public string ValidateAccount(AccountModel account)
    {
        string firstNameValidation = ValidateFirstName(account.Naam);
        if (firstNameValidation != "Success")
            return firstNameValidation;

        string lastNameValidation = ValidateLastName(account.Achternaam);
        if (lastNameValidation != "Success")
            return lastNameValidation;

        string birthDateValidation = ValidateGeboortedatum(account.Geboortedatum);
        if (birthDateValidation != "Success")
            return birthDateValidation;

        string phoneValidation = ValidateTelefoonnummer(account.Telefoonnummer);
        if (phoneValidation != "Success")
            return phoneValidation;

        string emailValidation = ValidateEmail(account.Email);
        if (emailValidation != "Success")
            return emailValidation;

        string passwordValidation = ValidatePassword(account);
        if (passwordValidation != "Success")
            return passwordValidation;

        return "Success";
    }
    public string ValidateFirstName(string firstName)
    {
        string specialChars = @"!@#$%^&*()_+{}|:<>?`~\[];',./""-=";
        if (string.IsNullOrWhiteSpace(firstName))
            return "A first name is required";

        if (firstName.Any(char.IsDigit))
            return "A first name cannot contain numbers";
        
        if (firstName.Any(c => specialChars.Contains(c)))
            return "A first name cannot contain special characters";

        if (firstName.Length < 2)
            return "A first name should be at least 2 characters long";

        return "Success";
    }

    public string ValidateLastName(string lastName)
    {

        string specialChars = @"!@#$%^&*()_+{}|:<>?`~\[];',./""-=";
        if (string.IsNullOrWhiteSpace(lastName))
            return "A last name is required";

        if (lastName.Any(char.IsDigit))
            return "A last name cannot contain numbers";

        if (lastName.Any(c => specialChars.Contains(c)))
            return "A last name cannot contain special characters";

        if (lastName.Length < 2)
            return "A last name should be at least 2 characters long";

        return "Success";
    }

    public string ValidateGeboortedatum(DateTime dateOfBirth)
    {
        if (dateOfBirth == default)
            return "A date of birth is required";

        if (dateOfBirth > DateTime.Now)
            return "Date of birth cannot be in the future";

        int age = DateTime.Now.Year - dateOfBirth.Year;
        if (dateOfBirth > DateTime.Now.AddYears(-age)) age--;

        if (age < 0)
            return "Invalid date of birth";

        return "Success";
    }

    public string ValidateTelefoonnummer(string telefoonnummer)
    {
        if (string.IsNullOrWhiteSpace(telefoonnummer))
            return "A phone number is required";

        if (!telefoonnummer.All(char.IsDigit))
            return "A phone number can only contain numbers";

        if (telefoonnummer.Length < 10 || telefoonnummer.Length > 15)
            return "A phone number should be between 10 and 15 digits long";

        return "Success";
    }

    public string ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return "An email is required";

        if (!email.Contains("@") || !email.Contains("."))
            return "An email should contain an @ and a .";

        return "Success";
    }

    public string ValidatePassword(AccountModel account)
    {

        
        

        if (string.IsNullOrWhiteSpace(account.Password))
            return "A password is required";

        if (account.Password.Length < 6)
            return "A password should be at least 6 characters long";
        
        if (account.Password.Any(char.IsWhiteSpace))
            return "A password cannot contain whitespace";

        

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