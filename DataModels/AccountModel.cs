public class AccountModel
{

    public Int64 Id { get; set; }

    public string? Naam { get; set; }

    public string? Achternaam { get; set; }

    public DateTime Geboortedatum { get; set; }

    public string? Telefoonnummer { get; set; }
    public string? EmailAddress { get; set; }

    public string Password { get; set; }

    

    public AccountModel(Int64 id, string naam, string achternaam, DateTime geboortedatum, string telefoonnummer, string email, string password)
    {
        Id = id;
        Naam = naam;
        Achternaam = achternaam;
        Geboortedatum = geboortedatum;
        Telefoonnummer = telefoonnummer;
        EmailAddress = email;
        Password = password;
        
    }

    public AccountModel() { } 


}



