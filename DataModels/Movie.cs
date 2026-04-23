using System;
using System.Collections.Generic;

public class Movie
{

    
    public string Title { get; set; }
    public static Dictionary<string, List<string>> MoviesDict = new();
    public static List<string> Movies = new();
    public List<string> Times { get; set; }


    public Movie(string title, List<string> times)
    {
        Title = title;

        Times = times;
        MoviesDict[title] = times;
        Movies.Add(title);
    }

    public static  void RunAuditorium(string ChoosedMovie , string ChoosedTime)
    {
        
        string AuditoriumNumber;
        if(ChoosedTime.EndsWith("3")) AuditoriumNumber = "Auditorium 3";
        else if (ChoosedTime.EndsWith("2")) AuditoriumNumber = "Auditorium 2";
        else if (ChoosedTime.EndsWith("1")) AuditoriumNumber = "Auditorium 1";
        else 
        {
            Console.WriteLine("Bestaat niet");
            return;
        }


        Auditorium BookAuditorium = new(AuditoriumNumber);
        BookAuditorium.StartSelection(ChoosedMovie, ChoosedTime);
    }

    public static string ArrowOptions(List<string> info)
    {

        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();
            PrintOptions( info, selectedIndex);

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0)
                    selectedIndex = info.Count - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= info.Count)
                    selectedIndex = 0;
            }

        } while (key != ConsoleKey.Enter);

        return info[selectedIndex];
    }
    public static void  PrintOptions(List<string> info, int selectedIndex)
    {
        for (int i = 0; i < info.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"> {info[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {info[i]}");
            }
        }        
    }

}