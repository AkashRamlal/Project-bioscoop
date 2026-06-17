namespace UnitTests;

[TestClass]
public class GuestValidationLogicTests
{
    // Name
    [TestMethod]
    public void IsValidName_ValidName_ReturnsTrue()
        => Assert.IsTrue(GuestValidationLogic.IsValidName("John"));

    [TestMethod]
    public void IsValidName_EmptyName_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidName(""));

    // Email
    [TestMethod]
    public void IsValidEmail_ValidEmail_ReturnsTrue()
        => Assert.IsTrue(GuestValidationLogic.IsValidEmail("guest@example.com"));

    [TestMethod]
    public void IsValidEmail_NoAtSign_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidEmail("guestexample.com"));

    [TestMethod]
    public void IsValidEmail_NoDot_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidEmail("guest@examplecom"));

    // Phone
    [TestMethod]
    public void IsValidPhone_ValidPhone_ReturnsTrue()
        => Assert.IsTrue(GuestValidationLogic.IsValidPhone("0612345678"));

    [TestMethod]
    public void IsValidPhone_TooShort_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidPhone("123"));

    [TestMethod]
    public void IsValidPhone_ContainsLetters_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidPhone("061234abcd"));

    // Age
    [TestMethod]
    public void IsValidAge_ValidAge_ReturnsTrue()
        => Assert.IsTrue(GuestValidationLogic.IsValidAge("25"));

    [TestMethod]
    public void IsValidAge_TooYoung_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidAge("3"));

    [TestMethod]
    public void IsValidAge_TooOld_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidAge("121"));

    [TestMethod]
    public void IsValidAge_NotANumber_ReturnsFalse()
        => Assert.IsFalse(GuestValidationLogic.IsValidAge("abc"));
}