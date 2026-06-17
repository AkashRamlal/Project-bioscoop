namespace UnitTests;

[TestClass]
public class EditAccountTests
{
    [DataTestMethod]
    [DataRow("Cheese", true)]
    [DataRow("Cheese Junior", true)]
    [DataRow("Selena", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("John123", false)]
    [DataRow("John@@Doe", false)]
    public void IsValidName_ReturnsExpectedResult(string name, bool expected)
    {
        bool result = EditAccountLogic.IsValidName(name);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("0612345678", true)]
    [DataRow("1234567890", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("123-456", false)]
    [DataRow("123abc", false)]
    public void IsValidPhoneNumber_ReturnsExpectedResult(string phoneNumber, bool expected)
    {
        bool result = EditAccountLogic.IsValidPhoneNumber(phoneNumber);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("test@test.com", true)]
    [DataRow("cheese@cheese.nl", true)]
    [DataRow(" ", false)]
    [DataRow("invalid-email@", false)]
    [DataRow("@cheese.com", false)]
    public void IsValidEmail_ReturnsExpectedResult(string email, bool expected)
    {
        bool result = EditAccountLogic.IsValidEmail(email);

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("Password123", true)]
    [DataRow("Cheese!#", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("pass word", false)]
    [DataRow(" password", false)]
    [DataRow("password ", false)]
    public void IsValidPassword_ReturnsExpectedResult(string password, bool expected)
    {
        bool result = EditAccountLogic.IsValidPassword(password);

        Assert.AreEqual(expected, result);
    }
}