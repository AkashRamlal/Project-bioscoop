public class PaymentService
{
    public bool ProcessIDeal(string bank)
    {
        string[] banks =
        {
            "ABN AMRO",
            "ING",
            "Rabobank",
            "SNS Bank"
        };

        return banks.Contains(bank);
    }

    public bool ProcessPayPal(string email)
    {
        return GuestValidationLogic.IsValidEmail(email);
    }
}