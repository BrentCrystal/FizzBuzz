using FizzBuzzLibrary;
using System;
using System.Collections.Generic;

/*
- Create a Console app that prints out Fizz when a number is divisible by 3, 
    Buzz when divisible by 5, and FizzBuzz when divisible by 3 and 5. Create it as simply as possible.
- Refactor to only perform each division once.
- Refactor to add in Jazz (7) and to accept any bounds (handle special number(s) correctly). 
- Write it so that it can add more checks without adding more code. 
- Create a reusable system that can apply rules in a specified order.*/

namespace FizzBuzzConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = UserMessage.GetIntegerFromUser("Enter a valid start index integer: i.e., 1 or -1");
            Console.WriteLine();

            int endIndex = UserMessage.GetIntegerFromUser("Enter a valid end index integer: i.e., 100 or -100");
            Console.WriteLine();

            //List<string> fizzBuzz = FizzBuzz.RunBasicFizzBuzz(); 

            List<string> fizzBuzz = FizzBuzz.RunElaborateFizzBuzz(startIndex, endIndex);

            fizzBuzz.PrintFizzBuzzValues();

            Console.ReadLine();
        }
    }
}
