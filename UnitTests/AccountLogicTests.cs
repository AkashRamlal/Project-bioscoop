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

    public void RegisterMember_withoutLastName_ReturnsError()
    {
        var Logic = new AccountsLogic();

        var account = new AccountModel
        {
            Naam = "John",
            Achternaam = "",
            Email = " ",
            Password = "password123"
        };
        string result = Logic.RegisterMember(account);
        Assert.AreEqual("A last name is required", result);
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