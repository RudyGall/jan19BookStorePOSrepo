using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermBookStorePOS
{
	class Checkout
	{
		public List<Book> Cart = new List<Book>();
		
        public int Quantity { get; set; }
        private readonly double taxRate = 0.06;
		public double GrandTotal { get; set; }
	

        public void CalculatingCost()
        {

			
			double subTotal = 0;
			foreach (Book q in Cart)
			{
							
				subTotal += q.Price * q.Quantity;
				Console.WriteLine(q.Title);
				Console.WriteLine(q.Author);
				Console.WriteLine(q.Price);
				Console.WriteLine(q.Quantity);			
			}
			Console.WriteLine($"Your subtotal is {subTotal}");

			double tax = subTotal * taxRate;
			GrandTotal = subTotal + tax;
			
		}

        public void PaymentChoice(double grandTotal)
        {
            
            bool paymentReturn = true;
            while (paymentReturn == true)
            {
                Console.WriteLine("How will you be paying today? cash, card, or check?");
                string paymentChoice = Console.ReadLine().ToLower();
				if (paymentChoice == "cash")
				{
					paymentReturn = false;
					PaymentValidation.Cash(grandTotal);

				}
				else if (paymentChoice == "card")
				{
					PaymentValidation.Credit();
					paymentReturn = false;
				}
				else if (paymentChoice == "check")
				{
					PaymentValidation.Check();
					paymentReturn = false;
					
				}
				else
				{
					Console.WriteLine("Sorry, I didn't understand, please write 'cash' 'card' or 'check'.");
					paymentReturn = true;
				}
            }
        }
	
	}
}