

using System;

public class Auditorium
{

    private int[,] _seats;
    private int _cursorVertical;
    private int _cursorHorizontal;
    private bool _chooseSeat;

    public Dictionary<string, Dictionary<string, int>> ReservedSeats = new();
    // <Auditorium1, <SeatNumber, Price>>



    public Auditorium()// string auditoriumName
    {
        _seats = GenerateLayout();//_seats = GenerateLayout(auditoriumName)
        _cursorVertical = 0;
        _cursorHorizontal = 2;
        _chooseSeat = true;
        ReservedSeats["Auditorium 1"] = new Dictionary<string, int>();
        
    }


    public void StartSelection()
    {
        while (_chooseSeat)
        {
            Display();
            HandleInput();
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.Write("   ");
        for(int i = 1; i <= 12; i++) 
        {
            Console.Write($" {i:D2}"); // print 1 tot 12 horizontaal
        }
        Console.WriteLine();
        for (int horizontal = 0; horizontal < 14; horizontal++)
        {
            Console.Write($"{14 - horizontal:D2} ");// print 14 tot 1 verticaal

            for (int verticaal = 0; verticaal < 12; verticaal++)
            {
                if (_seats[horizontal, verticaal] == 0) 
                {
                    Console.Write("   ");
                    continue;
                }

                if (horizontal == _cursorVertical && verticaal == _cursorHorizontal) // start
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    ConsoleColor chosenColor;

                    switch (_seats[horizontal, verticaal])
                    {
                        case 1:
                            chosenColor = ConsoleColor.Blue; // buitenste
                            break;

                        case 2:
                            chosenColor = ConsoleColor.DarkYellow; // middelste
                            break;

                        case 3:
                            chosenColor = ConsoleColor.Red; // binnenste
                            break;
                            
                        case 4:
                            chosenColor = ConsoleColor.DarkGray; // gereserveert
                            break;

                        default:
                            chosenColor = ConsoleColor.Gray;
                            break;
                    
                    }
                    Console.ForegroundColor = chosenColor;
                }   
                Console.Write("[#]");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
            Console.WriteLine();
            Console.WriteLine("                  SCREEN          ");
            Console.WriteLine("   ------------------------------------");
            Console.WriteLine("   Blue = Basic(€11)  Yellow = Comfort(€12)  Red = Premium(€14) Grey = Reserved");         

    }

    private void HandleInput()
    {
        var key = Console.ReadKey(true).Key;
        int ChosenSeat = 0;
        if (key == ConsoleKey.Enter)// gebruiker heeft seat gekozen
        {
            if(ReservedSeats["Auditorium 1"].Count >= 10)
            {

                _chooseSeat = false;
                Console.Clear();
                Console.WriteLine("You can't book more then 10 seats call the cinema");
                Console.Write("You booked these seats: ");
                foreach(var seat in ReservedSeats["Auditorium 1"])
                {
                    Console.WriteLine($" {seat.Key} ");
                }
                //Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                _chooseSeat = false;
                return;
            }


            int rijNummer = _cursorHorizontal + 1;
            char kolomLetter = (char)('A' + _cursorVertical);
            string seatKey = $"{kolomLetter}{rijNummer}";

            ChosenSeat = _seats[_cursorVertical, _cursorHorizontal];
            // toevoegen aan dict met key value en key prijs
            if(ChosenSeat == 1)ReservedSeats["Auditorium 1"][seatKey] = 11;
            else if (ChosenSeat == 2) ReservedSeats["Auditorium 1"][seatKey] = 12;
            else if (ChosenSeat == 3) ReservedSeats["Auditorium 1"][seatKey] = 14;
            //  gekozen seat veranderen naar gereserveert
            _seats[_cursorVertical, _cursorHorizontal] = 4;
        
            Console.WriteLine("Do you want to book more seats? y/n");
            string Book = Console.ReadLine()?.ToUpper() ?? "";
            if (Book.StartsWith("N")) // gebruiker heeft genoeg plek(ken) besteld
            {
                _chooseSeat = false;
                Console.Clear();
                Console.WriteLine($"You bought the seat(s): ");
                foreach(var Seat in ReservedSeats["Auditorium 1"])
                {
                    Console.WriteLine($" {Seat.Key} ${Seat.Value}");
                }

                //Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();      

            }

            
        }
        int newY = _cursorVertical;
        int newX = _cursorHorizontal;
        if (key == ConsoleKey.UpArrow && _cursorVertical > 0) newY--;
        if (key == ConsoleKey.DownArrow && _cursorVertical < 13) newY++;
        if (key == ConsoleKey.LeftArrow && _cursorHorizontal > 0) newX--;
        if (key == ConsoleKey.RightArrow && _cursorHorizontal < 11) newX++;

        
        if (_seats[newY, newX] != 0 && _seats[newY, newX] != 4)
        {
            _cursorVertical = newY;
            _cursorHorizontal = newX;
        }

    }

    private int[,] GenerateLayout()// string auditoriumName
    {
    //  if (auditoriumName == "Auditorium 1)
        int[,] layout = new int[14, 12]; // verticaal, horizontaal
        // alles blauw maken
        for (int r = 0; r < 14; r++)
            for (int c = 0; c < 12; c++)
                layout[r, c] = 1; 
        //plek zonder stoel waarde 0 geven
        // links boven
        layout[0, 0] = 0;
        layout[0, 1] = 0;
        layout[1, 0] = 0;
        layout[2, 0] = 0;
        // rechts boven
        layout[0, 11] = 0;
        layout[0, 10] = 0;
        layout[1, 11] = 0;
        layout[2, 11] = 0;
        // links onder
        layout[11, 0] = 0;
        layout[12, 0] = 0;
        layout[13, 0] = 0;
        layout[12, 1] = 0;
        layout[13, 1] = 0;
        // rechts onder
        layout[13, 11] = 0;
        layout[13, 10] = 0;
        layout[12, 10] = 0;
        layout[11, 11] = 0;
        layout[12, 11] = 0;

        // gele deel 
        for (int ver = 3; ver < 11; ver++)
            for(int horizontal = 3; horizontal < 9; horizontal++)
                layout[ver, horizontal] = 2;
        // hoekjes van gele deel blauw maken
        layout[3, 3] = 1;
        layout[3, 4] = 1;
        layout[3, 7] = 1;
        layout[3, 8] = 1;
        layout[4, 3] = 1;
        layout[4, 8] = 1;
        layout[9, 3] = 1;
        layout[9, 8] = 1;
        layout[10, 3] = 1;
        layout[10, 4] = 1;
        layout[10, 7] = 1;
        layout[10, 8] = 1; 

        
        // rode deel
        for (int r = 5; r < 9; r++)
            for (int c = 5; c < 7; c++)
                layout[r, c] = 3;

        return layout;
    
    }
}
