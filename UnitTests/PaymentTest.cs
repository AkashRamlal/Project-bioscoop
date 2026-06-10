namespace UnitTests;

[TestClass]
public class PaymentTests
{
    PaymentService service = new PaymentService();
    
    [TestMethod]
    public void PaymentService_ProcessIDeal_ReturnsTrueIfValidBank()
    {
        // Arrange
        string ValidBank = "ING";
        // Act
        bool result = service.ProcessIDeal(ValidBank);
        // Assert
        Assert.IsTrue(result);
    }


    [TestMethod]
    public void PaymentService_ProcessIDeal_ReturnsFalseIfInvalidBank()
    {
        // Arrange
        string invalidBank = "Unknown Bank";
        // Act
        bool result = service.ProcessIDeal(invalidBank);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void PaymentService_ProcessPayPal_ReturnsTrueIfValidEmail()
    {
        // Arrange
        string validEmail = "test@example.com";
        // Act
        bool result = service.ProcessPayPal(validEmail);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void PaymentService_ProcessPayPal_ReturnsFalseIfInvalidEmail()
    {
        // Arrange
        string invalidEmail = "invalid-email";
        // Act
        bool result = service.ProcessPayPal(invalidEmail);
        // Assert
        Assert.IsFalse(result);
    }
}