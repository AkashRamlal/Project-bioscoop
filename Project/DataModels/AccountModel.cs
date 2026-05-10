public class AccountModel : IAccount
{

    public Int64 Id { get; set; }
    public string? Naam { get; set; }

    public string? Achternaam { get; set; }

    public DateTime Geboortedatum { get; set; }

    public string? Telefoonnummer { get; set; }

    public Roles Role { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; }

    

    public AccountModel( Int64 id, string naam, string achternaam, DateTime geboortedatum, string telefoonnummer, Roles role, string email, string password)
    {
 
        Naam = naam;
        Achternaam = achternaam;
        Geboortedatum = geboortedatum;
        Telefoonnummer = telefoonnummer;
        Role = role;
        Email = email;
        Password = password;
        
    }

    public AccountModel() { } 


}



