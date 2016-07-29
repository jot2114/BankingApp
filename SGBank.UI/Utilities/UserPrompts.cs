using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Utilities
{
    public static class UserPrompts
    {
        public static int GetIntFromUser(string message)
        {
            
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input,out value))
                    return value;

                Console.WriteLine("That was not a valid number.");
                PressKeyForContinue();

            } while (true);
        }

        public static decimal GetDecimalFromUser(string message)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                var input = Console.ReadLine();
                decimal value;

                if (decimal.TryParse(input, out value))
                    return value;

                Console.WriteLine("That was not a valid decimal value.");
                PressKeyForContinue();
            } while (true);
        }

        public static void PressKeyForContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static string GetStringFromUser(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
