using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermBookStorePOS
{
    class Validation
    {
        public static int SelectNum()
        {
            bool temp;
			while (true)
			{
				string userNum = Console.ReadLine();
				if (temp = int.TryParse(userNum, out int numTemp))
				{
					if (numTemp > 0 && numTemp <= 12)
					{
						return numTemp;
					}
					else
					{
						Console.Write("Invalid input, enter a number between 1 and 12: ");
						continue;
						//loops to top
					}
				}
				else
				{
					Console.Write("Invalid input, enter a number between 1 and 12: ");
					continue;
					//loops to top
				}
			}
		}
    }
}
