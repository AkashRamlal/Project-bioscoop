using Microsoft.Data.Sqlite;

using Dapper;


public class AccountsAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Accounts";

    public void Write(AccountModel account)
    {
        string sql = $"INSERT INTO {Table} (naam, achternaam,geboortedatum, telefoonnummer,role, email, password) VALUES (@Naam, @Achternaam, @Geboortedatum, @Telefoonnummer, @Role, @Email, @Password)";
        _connection.Execute(sql, new {
        Naam = account.Naam,
        Achternaam = account.Achternaam,
        Geboortedatum = account.Geboortedatum,
        Telefoonnummer = account.Telefoonnummer,
        Role = account.Role.ToString(),
        Email = account.Email,
        Password = account.Password
    });
    }

    public AccountModel GetByEmail(string email)
    {
        string sql = $"SELECT * FROM {Table} WHERE email = @Email";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new { Email = email })!;
    }

    public void Update(AccountModel account)
    {
        string sql = $"UPDATE {Table} SET email = @Email, password = @Password, naam = @Naam, achternaam = @Achternaam, geboortedatum = @Geboortedatum, telefoonnummer = @Telefoonnummer, role = @Role WHERE id = @Id";

        _connection.Execute(sql, new
        {
            account.Email,
            account.Password,
            account.Naam,
            account.Achternaam,
            account.Geboortedatum,
            account.Telefoonnummer,
            Role = account.Role.ToString(),
            account.Id
        });
    }

    public void Delete(AccountModel account)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = account.Id });
    }
}