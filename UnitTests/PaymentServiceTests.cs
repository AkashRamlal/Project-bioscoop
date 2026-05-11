using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PaymentServiceTests
{
    private TextWriter _originalOut = null!;
    private TextReader _originalIn = null!;

    [TestInitialize]
    public void Setup()
    {
        _originalOut = Console.Out;
        _originalIn = Console.In;
        Console.SetOut(TextWriter.Null);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOut);
        Console.SetIn(_originalIn);
    }

    // --- Invalid top-level choice ---

    [TestMethod]
    public void ProcessPayment_InvalidChoice_ReturnsFalse()
    {
        Console.SetIn(new StringReader("3\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_EmptyChoice_ReturnsFalse()
    {
        Console.SetIn(new StringReader("\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    // --- iDEAL: all valid banks ---

    [TestMethod]
    public void ProcessPayment_IDeal_Bank1_AbnAmro_ReturnsTrue()
    {
        Console.SetIn(new StringReader("1\n1\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_Bank2_Ing_ReturnsTrue()
    {
        Console.SetIn(new StringReader("1\n2\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_Bank3_Rabobank_ReturnsTrue()
    {
        Console.SetIn(new StringReader("1\n3\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_Bank4_SnsBank_ReturnsTrue()
    {
        Console.SetIn(new StringReader("1\n4\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    // --- iDEAL: invalid bank selections ---

    [TestMethod]
    public void ProcessPayment_IDeal_BankZero_ReturnsFalse()
    {
        Console.SetIn(new StringReader("1\n0\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_BankOutOfRange_ReturnsFalse()
    {
        Console.SetIn(new StringReader("1\n9\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_NonNumericBank_ReturnsFalse()
    {
        Console.SetIn(new StringReader("1\nabc\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_IDeal_EmptyBank_ReturnsFalse()
    {
        Console.SetIn(new StringReader("1\n\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    // --- PayPal: valid emails ---

    [TestMethod]
    public void ProcessPayment_PayPal_ValidEmail_ReturnsTrue()
    {
        Console.SetIn(new StringReader("2\nuser@example.com\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_PayPal_ValidEmailAtOnly_ReturnsTrue()
    {
        Console.SetIn(new StringReader("2\na@b\n"));
        Assert.IsTrue(new PaymentService().ProcessPayment());
    }

    // --- PayPal: invalid emails ---

    [TestMethod]
    public void ProcessPayment_PayPal_NoAtSign_ReturnsFalse()
    {
        Console.SetIn(new StringReader("2\ninvalidemail\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_PayPal_EmptyEmail_ReturnsFalse()
    {
        Console.SetIn(new StringReader("2\n\n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }

    [TestMethod]
    public void ProcessPayment_PayPal_WhitespaceEmail_ReturnsFalse()
    {
        Console.SetIn(new StringReader("2\n   \n"));
        Assert.IsFalse(new PaymentService().ProcessPayment());
    }
}
