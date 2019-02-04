using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermBookStorePOS
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentValidation payValidation = new PaymentValidation();
            Checkout checkout = new Checkout();
            bool finalAnswer = true;
            while (finalAnswer == true)
            {
                checkout = DisplayMenu(checkout);
                checkout.PaymentChoice(checkout.GrandTotal);
                PrintReceipt(checkout);
                bool isValid = true;
                while (isValid == true)
                {

                    Console.WriteLine("Would you like to make another transaction? y/n");
                    string inputYorN = Console.ReadLine().ToLower();
                    if (inputYorN == "y")
                    {
                        finalAnswer = true;
                        isValid = false;
                    }
                    else if (inputYorN == "n")
                    {
                        Console.WriteLine("Have a great day!");
                        finalAnswer = false;
                        isValid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid try again");
                        isValid = true;
                    }
                }
            }
        }
        public static Checkout DisplayMenu(Checkout c)
        {
            List<Book> Books = new List<Book>();
            Book b = new Book();
            int num = 1;

            Book InSearchofLostTime = new Book("In Search of Lost Time", "Marcel Proust", 22.75, 0);
            Books.Add(InSearchofLostTime);
            Book DonQuixote = new Book("Don Quixote", "Miguel de Cervantes", 29.99, 0);
            Books.Add(DonQuixote);
            Book Ulysses = new Book("Ulysses", "James Joyce", 15.95, 0);
            Books.Add(Ulysses);
            Book TheGreatGatsby = new Book("The Great Gatsby", "F.Scott Fitzgerald", 10.82, 0);
            Books.Add(TheGreatGatsby);
            Book MobyDick = new Book("Moby Dick", "Herman Melville", 9.56, 0);
            Books.Add(MobyDick);
            Book Hamlet = new Book("Hamlet", "William Shakespeare", 12.95, 0);
            Books.Add(Hamlet);
            Book WarandPeace = new Book("War and Peace", "Leo Tolstoy", 11.16, 0);
            Books.Add(WarandPeace);
            Book TheOdyssey = new Book("The Odyssey", "Homer", 14.39, 0);
            Books.Add(TheOdyssey);
            Book Lolita = new Book("Lolita", "Vladimir Nabokov", 17.00, 0);
            Books.Add(Lolita);
            Book OntheRoad = new Book("On the Road", "Jack Kerouac", 14.45, 0);
            Books.Add(OntheRoad);
            Book Breakfastofchampions = new Book("Breakfast of champions", "Kurt Vonnegut", 15.35, 0);
            Books.Add(Breakfastofchampions);
            Book TheAlchemist = new Book("The Alchemist", "Paulo Coelho", 13.89, 0);
            Books.Add(TheAlchemist);

            Console.WriteLine("Please choose a number of the following options:\n");

            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine(num + ". " + Books[i].Title);
                num++;
            }
            bool toMenu = true;
            while (toMenu == true)
            {
                Console.WriteLine("\nPlease enter a menu number");
                int.TryParse(Console.ReadLine(), out int userNumSelectMenu);
                if (userNumSelectMenu > 0 && userNumSelectMenu <= Books.Count)
                {
                    Console.WriteLine("Title: " + Books[userNumSelectMenu - 1].Title);
                    Console.WriteLine("Author: " + Books[userNumSelectMenu - 1].Author);
                    Console.WriteLine("$" + Books[userNumSelectMenu - 1].Price);
                    Console.WriteLine("Please input the amount of books you'd like to order.");
                    c.Cart.Add(Books[userNumSelectMenu - 1]);
                    c.Cart[c.Cart.Count - 1].Quantity = int.Parse(Console.ReadLine());

                    c.CalculatingCost();
                }
                else
                {
                    Console.WriteLine("That's not between 1-12. Try Again.");
                }
                toMenu = backToMenu(Books, num);

            }
            return c;
        }
        public static void PrintReceipt(Checkout c)
        {
            foreach (Book b in c.Cart)
            {
                Console.WriteLine(b.Title + " " + b.Author + " " + b.Price + " " + b.Quantity);
            }

        }
        public static bool backToMenu(List<Book> Books, int num)
        {
            Console.WriteLine("\nWould you like to return to the Menu or proceed to Checkout?(Menu or Checkout)");
            string input = Console.ReadLine().ToLower();
            input = input.ToLower();
            bool goOn;
            if (input == "menu")
            {
                goOn = true;
                for (int i = 0; i < Books.Count; i++)
                {
                    Console.WriteLine(num - 12 + ". " + Books[i].Title);
                    num++;
                }
            }
            else if (input == "checkout")
            {
                goOn = false;
            }
            else
            {
                Console.WriteLine("I don't understand that, let's try again");
                goOn = backToMenu(Books, num);
            }
            return goOn;
        }
    }
}
