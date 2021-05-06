using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzConsoleUI
{
    public static class UserMessage
    {
        public static int GetIntegerFromUser(this string message)
        {
            int output = 0;

            bool IsValidInt = false;

            while (IsValidInt == false)
            {
                Console.WriteLine(message);
                string userInput = Console.ReadLine();

                IsValidInt = int.TryParse(userInput, out output);
            }

            return output;
        }
    }
}
