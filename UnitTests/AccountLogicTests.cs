
namespace UnitTests;

[TestClass]
public class AccountLogicTests
{
    [TestMethod]
    public void RegisterMember_withoutFirstName_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A first name is required", result);
    }

    [TestMethod]
    public void RegisterMember_withFirstNameContainingNumbers_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John123",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A first name cannot contain numbers", result);
    }

    [TestMethod]
    public void RegisterMember_withFirstNameContainingSpecialCharacters_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John!",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A first name cannot contain special characters", result);
    }

    [TestMethod]
    public void RegisterMember_withShortFirstName_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "J",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A first name should be at least 2 characters long", result);
    }

    [TestMethod]
    public void RegisterMember_withoutLastName_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A last name is required", result);
    }

    [TestMethod]
    public void RegisterMember_withLastNameContainingNumbers_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe123",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A last name cannot contain numbers", result);
    }

    [TestMethod]
    public void RegisterMember_withLastNameContainingSpecialCharacters_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe!",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A last name cannot contain special characters", result);
    }

    [TestMethod]
    public void RegisterMember_withShortLastName_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "D",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A last name should be at least 2 characters long", result);
    }

    [TestMethod]
    public void RegisterMember_withoutEmail_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("An email is required", result);
    }

    [TestMethod]
    public void RegisterMember_withInvalidEmail_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "johndoe",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("An email should contain an @ and a .", result);
    }

    [TestMethod]
    public void RegisterMember_withShortPassword_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A password should be at least 6 characters long", result);
    }

    [TestMethod]
    public void RegisterMember_withPasswordWithWhitespace_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = " password123 "
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A password cannot contain whitespace", result);
    }

    [TestMethod]
    public void RegisterMember_withNoPassword_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = ""
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("A password is required", result);
    }

    [TestMethod]
    public void RegisterMember_withValidData_ReturnsSuccess()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "Doe",
            Email = "john.doe@example.com",
            Password = "password123"
        };

        string result = Logic.RegisterMember(account);

        Assert.AreEqual("Account registered successfully", result);
    }

    [TestMethod]
    public void ValidateTelefoonnummer_EmptyPhoneNumber_ReturnsRequiredMessage()
    {
        var Logic = new AccountsLogic();

        string result = Logic.ValidateTelefoonnummer("");

        Assert.AreEqual("A phone number is required", result);
    }

    [TestMethod]
    public void ValidateTelefoonnummer_WithLetters_ReturnsNumbersOnlyMessage()
    {
        var Logic = new AccountsLogic();

        string result = Logic.ValidateTelefoonnummer("06123abc45");

        Assert.AreEqual("A phone number can only contain numbers", result);
    }

    [TestMethod]
    public void ValidateTelefoonnummer_WithSpecialCharacters_ReturnsNumbersOnlyMessage()
    {
        var Logic = new AccountsLogic();

        string result = Logic.ValidateTelefoonnummer("06-12345678");

        Assert.AreEqual("A phone number can only contain numbers", result);
    }

    [TestMethod]
    public void ValidateTelefoonnummer_TooShort_ReturnsLengthMessage()
    {
        var Logic = new AccountsLogic();

        string result = Logic.ValidateTelefoonnummer("123456789");

        Assert.AreEqual("A phone number should be between 10 and 15 digits long", result);
    }

    

    [TestMethod]
    public void ValidateTelefoonnummer_ValidPhoneNumber_ReturnsSuccess()
    {
        var Logic = new AccountsLogic();

        string result = Logic.ValidateTelefoonnummer("0612345678");

        Assert.AreEqual("Success", result);
    }
}

