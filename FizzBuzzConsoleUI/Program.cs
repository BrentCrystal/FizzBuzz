using FizzBuzzLibrary;
using System;
using System.Collections.Generic;

namespace FizzBuzzConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fizzBuzz = FizzBuzz.RunBasicFizzBuzz();

            fizzBuzz.PrintFizzBuzz();

            Console.ReadLine();
        }
    }
}
