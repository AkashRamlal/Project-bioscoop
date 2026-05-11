using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TicketServiceTests
{
    private TextWriter _originalOut = null!;
    private TextReader _originalIn = null!;

    [TestInitialize]
    public void Setup()
    {
        _originalOut = Console.Out;
        _originalIn = Console.In;
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOut);
        Console.SetIn(_originalIn);
    }

    private static Dictionary<string, Dictionary<string, decimal>> OneHallOneSeat(
        string hall = "Hall 1", string seat = "A1", decimal price = 10.00m)
        => new() { { hall, new Dictionary<string, decimal> { { seat, price } } } };

    // --- Payment cancelled paths (no database write occurs) ---

    [TestMethod]
    public void HandleCheckout_InvalidPaymentChoice_DoesNotThrow()
    {
        Console.SetOut(TextWriter.Null);
        Console.SetIn(new StringReader("3\n")); // invalid choice → payment returns false
        new TicketService().HandleCheckout("Inception", "19:00", OneHallOneSeat(), 0);
    }

    [TestMethod]
    public void HandleCheckout_InvalidPaymentChoice_PrintsCancelMessage()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        Console.SetIn(new StringReader("3\n"));

        new TicketService().HandleCheckout("Inception", "19:00", OneHallOneSeat(), 0);

        Assert.IsTrue(output.ToString().Contains("No ticket issued"));
    }

    [TestMethod]
    public void HandleCheckout_IDealInvalidBank_DoesNotThrow()
    {
        Console.SetOut(TextWriter.Null);
        Console.SetIn(new StringReader("1\n9\n")); // iDEAL, bank out of range
        new TicketService().HandleCheckout("Dune", "21:00", OneHallOneSeat(), 1);
    }

    [TestMethod]
    public void HandleCheckout_IDealInvalidBank_PrintsCancelMessage()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        Console.SetIn(new StringReader("1\n9\n"));

        new TicketService().HandleCheckout("Dune", "21:00", OneHallOneSeat(), 1);

        Assert.IsTrue(output.ToString().Contains("No ticket issued"));
    }

    [TestMethod]
    public void HandleCheckout_PayPalInvalidEmail_DoesNotThrow()
    {
        Console.SetOut(TextWriter.Null);
        Console.SetIn(new StringReader("2\nnoemail\n")); // PayPal, no @ sign
        new TicketService().HandleCheckout("Interstellar", "18:00", OneHallOneSeat(), 2);
    }

    [TestMethod]
    public void HandleCheckout_PayPalInvalidEmail_PrintsCancelMessage()
    {
        var output = new StringWriter();
        Console.SetOut(output);
        Console.SetIn(new StringReader("2\nnoemail\n"));

        new TicketService().HandleCheckout("Interstellar", "18:00", OneHallOneSeat(), 2);

        Assert.IsTrue(output.ToString().Contains("No ticket issued"));
    }

    [TestMethod]
    public void HandleCheckout_MultipleHalls_PaymentFailed_DoesNotThrow()
    {
        Console.SetOut(TextWriter.Null);
        Console.SetIn(new StringReader("3\n"));
        var hallData = new Dictionary<string, Dictionary<string, decimal>>
        {
            { "Hall 1", new Dictionary<string, decimal> { { "A1", 10.00m }, { "A2", 12.00m } } },
            { "Hall 2", new Dictionary<string, decimal> { { "B1", 15.00m } } }
        };
        new TicketService().HandleCheckout("Oppenheimer", "20:00", hallData, 3);
    }
}
