using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzLibrary
{
    public static class FizzBuzz
    {
        public static List<string> RunBasicFizzBuzz()
        {
            List<string> output = new List<string>();

            for (int i = 1; i <=100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output.Add($" FizzBuzz ({i})");
                }
                else if (i % 3 == 0)
                {
                    output.Add($"Fizz ({i})");
                }
                else if (i % 5 == 0)
                {
                    output.Add($"Buzz ({i})");
                }
                else
                {
                    output.Add(i.ToString());
                }
            }

            return output;
        }

        public static void PrintFizzBuzz(this List<string> fizzBuzz)
        {
            foreach (var item in fizzBuzz)
            {
                Console.WriteLine(item);
            }
        }
    }
}
