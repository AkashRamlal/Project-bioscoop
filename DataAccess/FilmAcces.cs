using Dapper;
using Microsoft.Data.Sqlite;

public class FilmAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Film";

    public void Write(FilmModel film)
{
    string sql = $"INSERT INTO {Table} " +"(naam, genre, tijdsduur, leeftijdsgrens, acteurs, regiseur) " + "VALUES (@Naam, @Genre, @Tijdsduur, @Leeftijdsgrens, @Acteurs, @Regiseur)";

    _connection.Execute(sql, new
    {
        Naam = film.Naam,
        Genre = film.Genre,
        Tijdsduur = film.Tijdsduur,
        Leeftijdsgrens = film.Leeftijdsgrens,
        Acteurs = film.Acteurs,
        Regiseur = film.Regiseur
    });
}

    public FilmModel GetById(Int64 id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<FilmModel>(sql, new { Id = id })!;
    }

    public void Update(FilmModel film)
    {
        string sql = $"UPDATE {Table} SET naam = @Naam, genre = @Genre, tijdsduur = @Tijdsduur, leeftijdsgrens = @Leeftijdsgrens, acteurs = @Acteurs, regiseur = @Regiseur WHERE id = @Id";
        _connection.Execute(sql, film);
    }

    public void Delete(FilmModel film)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = film.Id });
    }
}