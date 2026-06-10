using Microsoft.Data.Sqlite;
using Dapper;
using System.Data;

public class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
{
    public override void SetValue(IDbDataParameter parameter, DateTime value)
    {
        parameter.Value = value.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public override DateTime Parse(object value)
    {
        return DateTime.Parse(value.ToString()!);
    }
}

public class TicketsAccess
{
    private SqliteConnection _connection = new SqliteConnection(
        $"Data Source={Path.Combine(AppContext.BaseDirectory, "DataSources", "project.db")}");
    private string Table = "Tickets";

    static TicketsAccess()
    {
        SqlMapper.AddTypeHandler(new DateTimeHandler());
    }

    public TicketsAccess() { }


    public void Write(Ticket ticket)
    {
        string sql = $"INSERT INTO {Table} (film_name, hall, date, seats, total_price, email) " +
                    "VALUES (@FilmName, @Hall, @Date, @Seats, @TotalPrice, @Email)";
        _connection.Execute(sql, new
        {
            ticket.FilmName,
            ticket.Hall,
            ticket.Date,
            ticket.Seats,
            ticket.TotalPrice,
            ticket.Email
        });
        ticket.Id = _connection.QuerySingle<int>("SELECT last_insert_rowid()");
    }
    public List<Ticket> GetByAccount(string email)
    {
        string sql = $"SELECT id AS Id, film_name AS FilmName, hall AS Hall, date AS Date, " +
                     $"seats AS Seats, total_price AS TotalPrice, email AS Email " +
                     $"FROM {Table} WHERE email = @Email";
        return _connection.Query<Ticket>(sql, new { Email = email }).ToList();
    }

        public void Delete(int id)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = id });
    }

    public List<Ticket> GetAll()
    {
        string sql = $"SELECT id AS Id, film_name AS FilmName, hall AS Hall, date AS Date, " +
                    $"seats AS Seats, total_price AS TotalPrice, email AS Email " +
                    $"FROM {Table}";
        return _connection.Query<Ticket>(sql).ToList();
    }
    public List<Ticket> GetTickets()
    {
        string sql = $"SELECT film_name AS FilmName, hall AS Hall, date AS Date, seats AS Seats FROM {Table}";
                        
        return _connection.Query<Ticket>(sql).ToList();
    }
}