using System.Collections.Generic;

namespace UnitTests;

[TestClass]
public class FilterSearchTests
{
    private List<FilmModel> GetTestFilms()
    {
        return new List<FilmModel>
        {
            new FilmModel
            {
                Id = 1,
                Naam = "Inception",
                Genre = "Sci-Fi",
                Tijdsduur = "148",
                Leeftijdsgrens = 12,
                Acteurs = "Leonardo DiCaprio;Tom Hardy",
                Regiseur = "Christopher Nolan"
            },
            new FilmModel
            {
                Id = 2,
                Naam = "The Dark Knight",
                Genre = "Action",
                Tijdsduur = "152",
                Leeftijdsgrens = 16,
                Acteurs = "Christian Bale;Heath Ledger",
                Regiseur = "Christopher Nolan"
            },
            new FilmModel
            {
                Id = 3,
                Naam = "Titanic",
                Genre = "Romance",
                Tijdsduur = "195",
                Leeftijdsgrens = 12,
                Acteurs = "Leonardo DiCaprio;Kate Winslet",
                Regiseur = "James Cameron"
            }
        };
    }

    [TestMethod]
    public void FilterByTitle_WithExistingTitle_ReturnsMatchingFilm()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByTitle(films, "inception");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Inception", result[0].Naam);
    }

    [TestMethod]
    public void FilterByTitle_WithEmptyTitle_ReturnsAllFilms()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByTitle(films, "");

        Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void FilterByGenre_WithExistingGenre_ReturnsMatchingFilm()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByGenre(films, "action");

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("The Dark Knight", result[0].Naam);
    }

    [TestMethod]
    public void FilterByActor_WithExistingActor_ReturnsMatchingFilms()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByActor(films, "leonardo");

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void FilterByActor_WithEmptyActor_ReturnsAllFilms()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByActor(films, "");

        Assert.AreEqual(3, result.Count);
    }

    [TestMethod]
    public void FilterByDirector_WithExistingDirector_ReturnsMatchingFilms()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByDirector(films, "nolan");

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void FilterByAgeRestriction_WithAge12_ReturnsTwoFilms()
    {
        var filter = new FilterSearch();
        var films = GetTestFilms();

        var result = filter.FilterByAgeRestriction(films, 12);

        Assert.AreEqual(2, result.Count);
    }

    [TestMethod]
    public void HasActor_WhenFilmHasNoActors_ReturnsFalse()
    {
        var filter = new FilterSearch();

        var film = new FilmModel
        {
            Naam = "Unknown Movie",
            Genre = "Drama",
            Tijdsduur = "100",
            Leeftijdsgrens = 12,
            Acteurs = "",
            Regiseur = "Unknown Director"
        };

        bool result = filter.HasActor(film, "Leonardo");

        Assert.IsFalse(result);
    }
}