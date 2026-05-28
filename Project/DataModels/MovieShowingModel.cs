public class MovieShowing
{
    public int Id { get; set; }

    public int FilmId { get; set; }

    public DateTime StartTime { get; set; }

    public string Auditorium { get; set; }

    public bool IsDinnerEvent { get; set; }
}