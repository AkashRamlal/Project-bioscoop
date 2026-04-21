public class Movie
{
    public string Title;
    public string AuditoriumNumber;

    public string Time;

    public Movie(string title, string auditoriumNumber, string time)
    {
        Title = title;
        AuditoriumNumber = auditoriumNumber;
        Time = time;
    }

    public void RunAuditorium()
    {
        Auditorium BookAuditorium = new(AuditoriumNumber);
        BookAuditorium.StartSelection(Title, Time);
    }
}