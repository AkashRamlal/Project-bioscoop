<<<<<<< HEAD
﻿public class Program
=======
﻿using System;
public class Program
>>>>>>> Payment
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
<<<<<<< HEAD
        bool running = true;

        while (running)
        {
            string choice = WelcomeScreen.Menu();
            Console.Clear();

            if (choice == "Login")
            {
                var user = UserLogin.Start();

                if (user != null)
                {
                    Menu.Start($"{user.Naam} {user.Achternaam}");
                }
            }
            else if (choice == "Continue as Guest")
            {
                Menu.Start("guest");
            }

            Console.WriteLine("\nPress ESC to quit or any other key to return...");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                running = false;
        }
    }
}
=======
        Console.WriteLine("Welcome to this amazing program");
        Dictionary<string, Dictionary<string, decimal>> hallData = new Dictionary<string, Dictionary<string, decimal>> {
            { "Hall 1", new Dictionary<string, decimal> { { "A3", 10.00m }, { "B5", 12.50m } } }
        };
        Console.WriteLine("Welcome to this amazing program");
        Menu.Start();
        var paymentUI = new PaymentUI(false);
        paymentUI.StartAsMember("filmName", "00:00", hallData, 1);
    }
}
>>>>>>> Payment
