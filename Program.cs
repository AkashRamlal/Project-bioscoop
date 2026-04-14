using System;
public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Dictionary<string, Dictionary<string, decimal>> hallData = new Dictionary<string, Dictionary<string, decimal>> {
            { "Hall 1", new Dictionary<string, decimal> { { "A3", 10.00m }, { "B5", 12.50m } } }
        };
        Console.WriteLine("Welcome to this amazing program");
        Menu.Start();
        PaymentUI.Start("filmName", "00:00", hallData);
    }
}
