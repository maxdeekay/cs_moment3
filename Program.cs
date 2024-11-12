using System;
using System.ComponentModel;

namespace reviews
{
    class Program
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook();
            int i = 0;

            while (true) {
                Console.Clear();
                Console.CursorVisible = false;

                Console.WriteLine("\nGÄSTBOK\n\n");
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                // läs in sparade reviews
                i = 0;
                foreach(Review review in guestbook.getReviews()) {
                    Console.WriteLine("[" + i++ + "] " + review.Name + " - " + review.Message);
                }

                Console.WriteLine(""); // whitespace efter inlästa reviews

                int input = (int) Console.ReadKey(true).Key;

                switch (input) {
                    case '1':
                        Console.CursorVisible = true;
                        Console.Write("Skriv din recension: ");
                        string? message = Console.ReadLine();
                        Console.Write("Skriv ditt namn: ");
                        string? name = Console.ReadLine();

                        if (!String.IsNullOrEmpty(message) && !String.IsNullOrEmpty(name)) {
                            guestbook.addReview(message, name);
                        } else {
                            Console.WriteLine("\nInget av fälten får vara tomma.\n\nKlicka på en knapp för att gå vidare.");
                            Console.ReadKey();
                        }

                        break;
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange index på det inlägg du vill ta bort: ");
                        string? index = Console.ReadLine();

                        if (!String.IsNullOrEmpty(index))
                        try {
                            guestbook.deleteReview(Convert.ToInt32(index));
                        }
                        catch (Exception) {
                            Console.WriteLine("\nHittar ingen recension för det index du har angivit.\n\nKlicka på en knapp för att gå vidare.");
                            Console.ReadKey();
                        }

                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}