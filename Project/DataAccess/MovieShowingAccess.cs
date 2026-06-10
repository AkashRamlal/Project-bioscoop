using Microsoft.Data.Sqlite;
using Dapper;

public class MovieShowingsAccess
{
    private SqliteConnection _connection = new SqliteConnection(
        $"Data Source={Path.Combine(AppContext.BaseDirectory, "DataSources", "project.db")}");

    private string Table = "MovieShowings";

    public void Write(MovieShowing movieShowing)
    {
        string sql = $@"
            INSERT INTO {Table}
            (film_id, start_time, auditorium, is_dinner_event)
            VALUES
            (@FilmId, @StartTime, @Auditorium, @IsDinnerEvent)";

        _connection.Execute(sql, new
        {
            movieShowing.FilmId,
            StartTime = movieShowing.StartTime,
            movieShowing.Auditorium,
            IsDinnerEvent = movieShowing.IsDinnerEvent ? 1 : 0
        });
    }

    public MovieShowing? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";

        return _connection.QueryFirstOrDefault<MovieShowing>(sql, new { Id = id });
    }

    public List<MovieShowing> GetAll()
    {
        string sql = $"SELECT * FROM {Table}";

        return _connection.Query<MovieShowing>(sql).ToList();
    }

    public List<MovieShowing> GetByFilmId(int filmId)
    {
        string sql = $"SELECT * FROM {Table} WHERE film_id = @FilmId";

        return _connection.Query<MovieShowing>(sql, new { FilmId = filmId }).ToList();
    }

    public void Update(MovieShowing movieShowing)
    {
        string sql = $@"
            UPDATE {Table}
            SET
                film_id = @FilmId,
                start_time = @StartTime,
                auditorium = @Auditorium,
                is_dinner_event = @IsDinnerEvent
            WHERE id = @Id";

        _connection.Execute(sql, new
        {
            movieShowing.Id,
            movieShowing.FilmId,
            StartTime = movieShowing.StartTime,
            movieShowing.Auditorium,
            IsDinnerEvent = movieShowing.IsDinnerEvent ? 1 : 0
        });
    }

    public void Delete(MovieShowing movieShowing)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";

        _connection.Execute(sql, new { movieShowing.Id });
    }
}