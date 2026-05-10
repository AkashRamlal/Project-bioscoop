// LAYER: Presentation
// Shows all selected seats, lets user navigate with arrow keys,
// select a seat to cancel it or apply a discount (65+ = 20%, under 18 = 50%)

public class SeatReviewUI
{
    private class SeatEntry
    {
        public string Hall { get; set; } = "";
        public string SeatNumber { get; set; } = "";
        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public string Discount { get; set; } = "none"; // "none" | "senior" | "youth"
        public bool Cancelled { get; set; } = false;
    }

    public static Dictionary<string, Dictionary<string, decimal>> Show(
        Dictionary<string, Dictionary<string, decimal>> hallData)
    {
        var seats = new List<SeatEntry>();
        foreach (var hall in hallData)
            foreach (var seat in hall.Value)
                seats.Add(new SeatEntry
                {
                    Hall          = hall.Key,
                    SeatNumber    = seat.Key,
                    OriginalPrice = seat.Value,
                    FinalPrice    = seat.Value
                });

        int selected = 0;

        while (true)
        {
            DrawScreen(seats, selected);

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
                selected = (selected - 1 + seats.Count) % seats.Count;

            else if (key == ConsoleKey.DownArrow)
                selected = (selected + 1) % seats.Count;

            else if (key == ConsoleKey.Enter)
                HandleSeatAction(seats, selected);

            else if (key == ConsoleKey.P)
            {
                var result = new Dictionary<string, Dictionary<string, decimal>>();
                foreach (var seat in seats.Where(s => !s.Cancelled))
                {
                    if (!result.ContainsKey(seat.Hall))
                        result[seat.Hall] = new Dictionary<string, decimal>();
                    result[seat.Hall][seat.SeatNumber] = seat.FinalPrice;
                }

                if (result.Count == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No seats selected. Returning to seat selection...");
                    Console.ResetColor();
                    Console.ReadKey();
                    return result;
                }

                return result;
            }
        }
    }

    private static void DrawScreen(List<SeatEntry> seats, int selected)
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   YOUR SEATS                         ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.WriteLine();

        for (int i = 0; i < seats.Count; i++)
        {
            var seat  = seats[i];
            string arrow  = i == selected ? " > " : "   ";
            string status = seat.Cancelled ? "[CANCELLED]" : GetDiscountLabel(seat.Discount);
            string price  = seat.Cancelled ? "      " : $"€{seat.FinalPrice:F2}";

            if (seat.Cancelled)
                Console.ForegroundColor = ConsoleColor.White;
            else if (i == selected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (seat.Discount != "none")
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"{arrow}{seat.Hall} - {seat.SeatNumber,-6}  {price,-10} {status}");
            Console.ResetColor();
        }

        // Total
        decimal total = seats.Where(s => !s.Cancelled).Sum(s => s.FinalPrice);
        Console.WriteLine();
        Console.WriteLine("──────────────────────────────────────────────────────");
        Console.Write("  Total: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"€{total:F2}");
        Console.ResetColor();
        Console.WriteLine("──────────────────────────────────────────────────────");
        Console.WriteLine(" ↑↓ Navigate   ENTER Select seat   P Proceed to payment");
    }

    private static string GetDiscountLabel(string discount) => discount switch
    {
        "senior" => "[20% senior discount]",
        "youth"  => "[50% youth discount]",
        _        => "[no discount]"
    };

    private static void HandleSeatAction(List<SeatEntry> seats, int selected)
    {
        var seat = seats[selected];

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Selected: {seat.Hall} - {seat.SeatNumber}  €{seat.FinalPrice:F2}");
        Console.ResetColor();
        Console.WriteLine();

        if (seat.Cancelled)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("This seat is already cancelled.");
            Console.ResetColor();
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("What do you want to do?");
        WriteOption("1", "Cancel this seat",   ConsoleColor.Red);
        WriteOption("2", "Apply discount",      ConsoleColor.Green);
        WriteOption("3", "Remove discount",     ConsoleColor.Yellow);
        WriteOption("4", "Go back",             ConsoleColor.Gray);
        Console.Write("\nYour choice: ");

        var choice = Console.ReadKey(true).KeyChar;
        Console.WriteLine();

        switch (choice)
        {
            case '1':
                seat.Cancelled  = true;
                seat.FinalPrice = seat.OriginalPrice;
                seat.Discount   = "none";
                PrintFeedback("Seat cancelled.", ConsoleColor.Red);
                break;

            case '2':
                ApplyDiscount(seat);
                break;

            case '3':
                seat.Discount   = "none";
                seat.FinalPrice = seat.OriginalPrice;
                PrintFeedback("Discount removed.", ConsoleColor.Yellow);
                break;

            case '4':
                break;

            default:
                PrintFeedback("Invalid choice.", ConsoleColor.Red);
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void ApplyDiscount(SeatEntry seat)
    {
        if (seat.Discount != "none")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"This seat already has a discount ({GetDiscountLabel(seat.Discount)}).");
            Console.WriteLine("Remove it first before applying a new one.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine("Select discount:");
        WriteOption("1", "Senior (65+)     — 20% off", ConsoleColor.Green);
        WriteOption("2", "Youth (under 18) — 50% off", ConsoleColor.Green);
        Console.Write("\nYour choice: ");

        var key = Console.ReadKey(true).KeyChar;
        Console.WriteLine();

        switch (key)
        {
            case '1':
                seat.Discount   = "senior";
                seat.FinalPrice = seat.OriginalPrice * 0.80m;
                PrintFeedback($"Senior discount applied! New price: €{seat.FinalPrice:F2}", ConsoleColor.Green);
                break;

            case '2':
                seat.Discount   = "youth";
                seat.FinalPrice = seat.OriginalPrice * 0.50m;
                PrintFeedback($"Youth discount applied! New price: €{seat.FinalPrice:F2}", ConsoleColor.Green);
                break;

            default:
                PrintFeedback("Invalid choice. No discount applied.", ConsoleColor.Red);
                break;
        }
    }

    private static void WriteOption(string key, string label, ConsoleColor color)
    {
        Console.Write($"  {key}. ");
        Console.ForegroundColor = color;
        Console.WriteLine(label);
        Console.ResetColor();
    }

    private static void PrintFeedback(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

