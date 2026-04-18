

using System;

public class Auditorium
{

    private int[,] _seats;
    private int _cursorVertical;
    private int _cursorHorizontal;
    private bool _chooseSeat;
    public string AuditoriumNumer;

    public Dictionary<string, Dictionary<string, int>> ReservedSeats = new();
    // <Auditorium1, <SeatNumber, Price>>



    public Auditorium(string auditoriumNumber)
    {
        AuditoriumNumer = auditoriumNumber;
        _seats = GenerateLayout(auditoriumNumber);
        _cursorVertical = 9;
        _cursorHorizontal = 19;
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
        int AantalStoelenVerticaal = _seats.GetLength(0);
        int AantalStoelenHorizontaal = _seats.GetLength(1);
        Console.Write("   ");
        for(int i = 1; i <= AantalStoelenHorizontaal; i++) 
        {
            Console.Write($" {i:D2}");
        }
        Console.WriteLine();
        for (int horizontal = 0; horizontal < AantalStoelenVerticaal; horizontal++)
        {
            Console.Write($"{AantalStoelenVerticaal - horizontal:D2} ");

            for (int verticaal = 0; verticaal < AantalStoelenHorizontaal; verticaal++)
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
            //Console.WriteLine($"   {AantalStoelenHorizontaal * 3}");
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
        if (key == ConsoleKey.DownArrow && _cursorVertical < _seats.GetLength(0) - 1) newY++;
        if (key == ConsoleKey.LeftArrow && _cursorHorizontal > 0) newX--;
        if (key == ConsoleKey.RightArrow && _cursorHorizontal < _seats.GetLength(1) - 1) newX++;

        
        if (_seats[newY, newX] != 0 && _seats[newY, newX] != 4)
        {
            _cursorVertical = newY;
            _cursorHorizontal = newX;
        }

    }

    private int[,] GenerateLayout(string auditoriumNumber)// 
    {
        int[,] layout;
        if (auditoriumNumber == "Auditorium 1")
        {
            layout = new int[14, 12]; // verticaal, horizontaal
            // alles blauw maken
            for (int r = 0; r < 14; r++)
                for (int c = 0; c < 12; c++)
                    layout[r, c] = 1; 
            //plek zonder stoel waarde 0 geven
            // links boven
            layout[0, 0] = 0; layout[0, 1] = 0; layout[1, 0] = 0; layout[2, 0] = 0;
            // rechts boven
            layout[0, 11] = 0; layout[0, 10] = 0; layout[1, 11] = 0; layout[2, 11] = 0;
            // links onder
            layout[11, 0] = 0; layout[12, 0] = 0; layout[13, 0] = 0; layout[12, 1] = 0; layout[13, 1] = 0;
            // rechts onde
            layout[13, 11] = 0; layout[13, 10] = 0; layout[12, 10] = 0; layout[11, 11] = 0; layout[12, 11] = 0;

            // gele deel 
            for (int ver = 3; ver < 11; ver++)
        //  for (int verRood = 1; ver < 15 verRood++)
                for(int horizontal = 3; horizontal < 9; horizontal++)
                    layout[ver, horizontal] = 2;
            // hoekjes van gele deel blauw maken
            layout[3, 3] = 1; layout[3, 4] = 1; layout[3, 7] = 1; layout[3, 8] = 1; layout[4, 3] = 1; layout[4, 8] = 1; layout[9, 3] = 1; layout[9, 8] = 1; layout[10, 3] = 1; layout[10, 4] = 1; layout[10, 7] = 1; layout[10, 8] = 1; 
    
            // rode deel
            for (int r = 5; r < 9; r++)
                for (int c = 5; c < 7; c++)
                    layout[r, c] = 3;

            return layout;                
        }
        else if (auditoriumNumber == "Auditorium 2")
        {
            layout = new int[19, 18];
            for(int ver = 0; ver < 19; ver++)
                for(int hor = 0; hor < 18;hor++)
                    layout[ver, hor] = 1;
            
            layout[0, 0] = 0; layout[1, 0] = 0; layout[2, 0] = 0; layout[3, 0] = 0; layout[4, 0] = 0; layout[5, 0] = 0; layout[0, 17] = 0; layout[1, 17] = 0; layout[3, 17] = 0; layout[4, 17] = 0; layout[5, 17] = 0; layout[2, 17] = 0; layout[12, 0] = 0; layout[14, 0] = 0; layout[13, 0] = 0; layout[11, 17] = 0;
            layout[12, 0] = 0; layout[13, 0] = 0; layout[14, 0] = 0; layout[16, 0] = 0; layout[17, 0] = 0; layout[15, 0] = 0; layout[18, 0] = 0; layout[12, 17] = 0; layout[13, 17] = 0; layout[13, 17] = 0; layout[14, 17] = 0; layout[15, 17] = 0; layout[16, 17] = 0; layout[17, 17] = 0; layout[18, 17] = 0; layout[11, 0] = 0;
            layout[14, 1] = 0; layout[15, 1] = 0; layout[16, 1] = 0; layout[17, 2] = 0; layout[18, 1] = 0;  layout[17, 1] = 0;layout[18, 2] = 0; 
            layout[14, 16] = 0; layout[15, 16] = 0; layout[16, 16] = 0; layout[17, 16] = 0;layout[18, 16] = 0; layout[17, 15] = 0; layout[18, 15] = 0;

            for (int verGeel = 1; verGeel < 16; verGeel++)
                for(int horGeel = 2; horGeel < 16; horGeel++)
                    layout[verGeel, horGeel] = 2;
            // horizontaal, verticaal
            layout[1, 2] = 1; layout[2, 2] = 1; layout[3, 2] = 1; layout[4 , 2] = 1; layout[5, 2] = 1;
            layout[1, 3] = 1; layout[2, 3] = 1; layout[3, 3] = 1; 
            layout[1, 4] = 1;
            layout[1, 5] = 1;
            layout[2, 4] = 1;
            layout[1, 5] = 1; 


            layout[1, 15] = 1; layout[2, 15] = 1;  layout[3, 15] = 1;  layout[4, 15] = 1;  layout[5, 15] = 1; layout[6, 15] = 1; layout[1, 14] = 1; layout[2, 14] = 1; layout[3, 14] = 1; layout[4 , 14] = 1; layout[1, 13] = 1; layout[2, 13] = 1; layout[1, 12] = 1; layout[7, 2] = 1; layout[6, 2] = 1; layout[7, 15] = 1;
            layout[11, 2] = 1; layout[12, 2] = 1; layout[13, 2] = 1; layout[14, 2] = 1; layout[12, 3] = 1; layout[13, 3] = 1; layout[14, 3] = 1; layout[13, 4] = 1; layout[14, 4] = 1;
            
            layout[15, 2] = 1; layout[15, 3] = 1; layout[15, 4] = 1; layout[11, 15] = 1; layout[12, 15] = 1; layout[13, 15] = 1; layout[14, 15] = 1; layout[15, 15] = 1; layout[12, 14] = 1; layout[13, 14] = 1; layout[14, 14] = 1; layout[15, 14] = 1;  layout[13, 13] = 1; layout[14, 13] = 1 ;  layout[15, 13] = 1; layout[14, 12] = 1; layout[15, 12] = 1; 

            layout[15, 5] = 1; layout[14, 5] = 1; 

            for(int verRood = 5; verRood < 13; verRood++)
                for(int horRood = 6; horRood < 12; horRood++)
                    layout[verRood, horRood] = 3;
            
            layout[5, 6] = 2; layout[6, 6] = 2; layout[11, 6] = 2; layout[12, 6] = 2; layout[5, 7] = 2; layout[12, 7] = 2;
            layout[5, 10] = 2; layout[5, 11] = 2; layout[6, 11] = 2;
            layout[11, 11] = 2; layout[12, 11] = 2; layout[12, 10] = 2;
        }
        else if(auditoriumNumber == "Auditorium 3")
        {
            layout = new int[20, 30];
            for(int verBlauw = 0; verBlauw < 20; verBlauw++)
                for(int horBlauw = 0; horBlauw < 30; horBlauw++)
                    {
                        layout[verBlauw, horBlauw] = 1;

                    }
            layout[0, 0] = 0; layout[0, 1] = 0; layout[0, 2] = 0; layout[0, 3] = 0;
            layout[1, 0] = 0; layout[1, 1] = 0; layout[1, 2] = 0; 
            layout[2, 0] = 0;  layout[2, 1] = 0;  layout[2, 2] = 0; 
            layout[3, 0] = 0; layout[3, 1] = 0; layout[3, 2] = 0; 
            layout[4, 0] = 0; layout[4, 1] = 0; layout[4, 2] = 0; 
            layout[5, 0] = 0; layout[5, 1] = 0; 
            layout[6, 0] = 0; 

            layout[0, 26] = 0; layout[0, 27] = 0; layout[0, 28] = 0; layout[0, 29] = 0; 
            layout[1, 27] = 0; layout[1, 28] = 0; layout[1, 29] = 0; 
            layout[2, 27] = 0; layout[2, 28] = 0; layout[2, 29] = 0; 
            layout[3, 27] = 0; layout[3, 28] = 0; layout[3, 29] = 0; 
            layout[4, 27] = 0; layout[4, 28] = 0; layout[4, 29] = 0; 
            layout[5, 28] = 0; layout[5, 29] = 0; 
            layout[6, 29] = 0; 

            layout[12, 0] = 0; 
            layout[13, 0] = 0; layout[13, 1] = 0; 
            layout[14, 0] = 0; layout[14, 1] = 0; 
            layout[15, 0] = 0; layout[15, 1] = 0; layout[15, 2] = 0; 
            layout[16, 0] = 0; layout[16, 1] = 0; layout[16, 2] = 0;
            layout[17, 0] = 0; layout[17, 1] = 0; layout[17, 2] = 0; layout[17, 3] = 0; layout[17, 4] = 0; 
            layout[18, 0] = 0; layout[18, 1] = 0; layout[18, 2] = 0; layout[18, 3] = 0; layout[18, 4] = 0; layout[18, 5] = 0; layout[18, 6] = 0; 
            layout[19, 0] = 0; layout[19, 1] = 0; layout[19, 2] = 0; layout[19, 3] = 0; layout[19, 4] = 0; layout[19, 5] = 0; layout[19, 6] = 0; layout[19, 7] = 0; 

            layout[12, 29] = 0; 
            layout[13, 29] = 0; layout[13, 28] = 0; 
            layout[14, 29] = 0; layout[14, 28] = 0; 
            layout[15, 29] = 0; layout[15, 28] = 0; layout[15, 27] = 0; 
            layout[16, 29] = 0; layout[16, 28] = 0; layout[16, 27] = 0;
            layout[17, 29] = 0; layout[17, 28] = 0; layout[17, 27] = 0; layout[17, 26] = 0; layout[17, 25] = 0; 
            layout[18, 29] = 0; layout[18, 28] = 0; layout[18, 27] = 0; layout[18, 26] = 0; layout[18, 25] = 0; layout[18, 24] = 0; layout[18, 23] = 0; 
            layout[19, 29] = 0; layout[19, 28] = 0; layout[19, 27] = 0; layout[19, 26] = 0; layout[19, 25] = 0; layout[19, 24] = 0; layout[19, 23] = 0; layout[19, 22] = 0; 

            for(int verGeel = 1; verGeel < 17; verGeel++)
                for(int horGeel = 5; horGeel < 25; horGeel++)
                    layout[verGeel, horGeel] = 2;
            layout[1, 5] = 1; layout[1, 6] = 1; layout[1, 7] = 1; layout[1, 8] = 1; 
            layout[2, 5] = 1; layout[2, 6] = 1; layout[2, 7] = 1;
            layout[3, 5] = 1; layout[3, 6] = 1; layout[3, 7] = 1;
            layout[4, 5] = 1; layout[4, 6] = 1;
            layout[5, 5] = 1; layout[5, 6] = 1;
            layout[6, 5] = 1;
            layout[7, 5] = 1;

            
            layout[1, 24] = 1; layout[1, 23] = 1; layout[1, 22] = 1; layout[1, 21] = 1; 
            layout[2, 24] = 1; layout[2, 23] = 1; layout[2, 22] = 1;
            layout[3, 24] = 1; layout[3, 23] = 1; layout[3, 22] = 1;
            layout[4, 24] = 1; layout[4, 23] = 1;
            layout[5, 24] = 1; layout[5, 23] = 1;
            layout[6, 24] = 1;
            layout[7, 24] = 1;

            layout[10, 5] = 1;
            layout[11, 5] = 1; layout[11, 6] = 1; 
            layout[12, 5] = 1; layout[12, 6] = 1; layout[12, 7] = 1; 
            layout[13, 5] = 1; layout[13, 6] = 1; layout[13, 7] = 1; 
            layout[14, 5] = 1; layout[14, 6] = 1; layout[14, 7] = 1; layout[14, 8] = 1; 
            layout[15, 5] = 1; layout[15, 6] = 1; layout[15, 7] = 1;  layout[15, 8] = 1; layout[15, 9] = 1; 
            layout[16, 5] = 1; layout[16, 6] = 1; layout[16, 7] = 1;  layout[16, 8] = 1; layout[16, 9] = 1; layout[16, 10] = 1; layout[16, 11] = 1;

            layout[10, 24] = 1;
            layout[11, 24] = 1; layout[11, 23] = 1; 
            layout[12, 24] = 1; layout[12, 23] = 1; layout[12, 22] = 1; 
            layout[13, 24] = 1; layout[13, 23] = 1; layout[13, 22] = 1; 
            layout[14, 24] = 1; layout[14, 23] = 1; layout[14, 22] = 1; layout[14, 21] = 1; 
            layout[15, 24] = 1; layout[15, 23] = 1; layout[15, 22] = 1;  layout[15, 21] = 1; layout[15, 20] = 1; 
            layout[16, 24] = 1; layout[16, 23] = 1; layout[16, 22] = 1;  layout[16, 21] = 1; layout[16, 20] = 1; layout[16, 19] = 1; layout[16, 18] = 1;

            for(int verRood = 4; verRood < 14; verRood++)
                for(int horRood = 11; horRood < 19; horRood++)
                {
                    layout[verRood, horRood] = 3;
                }
            layout[4 , 11] = 2; layout[4 , 12] = 2;
            layout[5 , 11] = 2;

            layout[4 , 18] = 2; layout[4 , 17] = 2;
            layout[5 , 18] = 2;

            layout[13, 11] = 2; layout[13, 12 ] = 2;
            layout[13, 17] = 2; layout[13, 18 ] = 2;
        }
        else
        {
            throw new Exception("Onbekend auditorium nummer!");
        }

        return layout; 


        
        //

    }
}
