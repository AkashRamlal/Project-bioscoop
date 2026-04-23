using Microsoft.Data.Sqlite;
using Dapper;

public class TicketsAccess
{
    private SqliteConnection _connection = new SqliteConnection("Data Source=DataSources/project.db");
    private string Table = "Tickets";

    public TicketsAccess() { }


    public void Write(Ticket ticket)
    {
        Console.WriteLine(_connection.DataSource);
        string sql = $"INSERT INTO {Table} (film_name, hall, time, seats, total_price, account_id) " +
                    "VALUES (@FilmName, @Hall, @Time, @Seats, @TotalPrice, @AccountId)";
        _connection.Execute(sql, new
        {
            ticket.FilmName,
            ticket.Hall,
            ticket.Time,
            ticket.Seats,
            ticket.TotalPrice,
            AccountId = ticket.AccountId == 0 ? (int?)null : ticket.AccountId
        });
        ticket.Id = _connection.QuerySingle<int>("SELECT last_insert_rowid()");
    }
    public List<Ticket> GetByAccount(int accountId)
    {
        string sql = $"SELECT id AS Id, film_name AS FilmName, hall AS Hall, time AS Time, " +
                     $"seats AS Seats, total_price AS TotalPrice, account_id AS AccountId " +
                     $"FROM {Table} WHERE account_id = @AccountId";
        return _connection.Query<Ticket>(sql, new { AccountId = accountId }).ToList();
    }
}