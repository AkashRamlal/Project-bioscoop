public interface IAccount
{
    public Int64 Id { get; set; }

    public string? Naam { get; set; }

    public string? Achternaam { get; set; }

    public DateTime Geboortedatum { get; set; }

    public string? Telefoonnummer { get; set; }
    public string? EmailAddress { get; set; }

    public string Password { get; set; }
}