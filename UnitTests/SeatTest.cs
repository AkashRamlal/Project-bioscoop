namespace UnitTests;

[TestClass]
public class SeatLogicTests
{
    [TestMethod]
    public void ApplySeniorDiscount_Returns80Percent()
    {
        decimal result = SeatLogic.ApplySeniorDiscount(15.00m);
        Assert.AreEqual(12.00m, result);
    }

    [TestMethod]
    public void ApplyYouthDiscount_Returns50Percent()
    {
        decimal result = SeatLogic.ApplyYouthDiscount(10.00m);
        Assert.AreEqual(5.00m, result);
    }

    [TestMethod]
    public void RemoveDiscount_ReturnsOriginalPrice()
    {
        decimal result = SeatLogic.RemoveDiscount(10.00m);
        Assert.AreEqual(10.00m, result);
    }
}