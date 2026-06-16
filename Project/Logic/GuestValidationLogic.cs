public static class GuestValidationLogic
{
    public static bool IsValidName(string input)
        => !string.IsNullOrEmpty(input);

    public static bool IsValidEmail(string input)
        => input.Contains("@") && input.Contains(".") && input.Length > 5;

    public static bool IsValidPhone(string input)
        => input.All(char.IsDigit) && input.Length >= 8;

    public static bool IsValidAge(string input)
        => int.TryParse(input, out int age) && age >= 5 && age <= 120;
}