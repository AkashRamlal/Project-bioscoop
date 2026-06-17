
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
}

