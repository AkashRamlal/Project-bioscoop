using Microsoft.Data.Sqlite;
using Dapper;

public class TicketsAccess
{
    private SqliteConnection _connection = new SqliteConnection("Data Source=DataSources/project.db");
    private string Table = "Tickets";

    public TicketsAccess() { }


    public void Write(Ticket ticket)
    {
        string sql = $"INSERT INTO {Table} (film_name, hall, time, seats, total_price, email) " +
                    "VALUES (@FilmName, @Hall, @Time, @Seats, @TotalPrice, @Email)";
        _connection.Execute(sql, new
        {
            ticket.FilmName,
            ticket.Hall,
            ticket.Time,
            ticket.Seats,
            ticket.TotalPrice,
            ticket.Email
        });
        ticket.Id = _connection.QuerySingle<int>("SELECT last_insert_rowid()");
    }
    public List<Ticket> GetByAccount(string email)
    {
        string sql = $"SELECT id AS Id, film_name AS FilmName, hall AS Hall, time AS Time, " +
                     $"seats AS Seats, total_price AS TotalPrice, email AS Email " +
                     $"FROM {Table} WHERE email = @Email";
        return _connection.Query<Ticket>(sql, new { Email = email }).ToList();
    }
}