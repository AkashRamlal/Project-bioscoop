namespace UnitTests;

[TestClass]
public sealed class TestMenu
{
    [DataTestMethod]
    public void GetOptionsForGuest()
    {
        Roles? role = null;

        List<string> options = Menu.GetOptions(role);

        Assert.IsNotNull(options);
        Assert.AreEqual(options.Count, 4);
        CollectionAssert.Contains(options, "Movie theatre info");
        CollectionAssert.Contains(options, "View movies");
        CollectionAssert.Contains(options, "Quit");
    }

    [TestMethod]
    public void GetOptionsForMember()
    {
        Roles role = Roles.Member;

        List<string> options = Menu.GetOptions(role);

        Assert.AreEqual(options.Count, 6);
        CollectionAssert.Contains(options, "Your tickets");
        CollectionAssert.Contains(options, "Edit account information");
    }

    [TestMethod]
    public void GetOptionsForEmployee()
    {
        Roles role = Roles.Employee;

        List<string> options = Menu.GetOptions(role);

        CollectionAssert.Contains(options, "Manage films");
        CollectionAssert.Contains(options, "Manage tickets");
    }

    [TestMethod]
    public void GetOptionsForAdmin()
    {
        Roles role = Roles.Admin;

        List<string> options = Menu.GetOptions(role);

        CollectionAssert.Contains(options, "Manage employees");
    }
}