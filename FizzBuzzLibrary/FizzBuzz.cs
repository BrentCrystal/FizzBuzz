using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzLibrary
{
    public static class FizzBuzz
    {
        public static List<string> RunBasicFizzBuzz()
        {
            List<string> output = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output.Add($"FizzBuzz ({i})");
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

        public static List<string> RunElaborateFizzBuzz(int startIndex, int endIndex)
        {
            List<string> output = new List<string>();

            if (startIndex < endIndex)
            {
                output = IncrementFizzBuzz(startIndex, endIndex);
            }
            else
            {
                output = DecrementFizzBuzz(startIndex, endIndex);
                
            }

            return output;
        }

        private static List<string> IncrementFizzBuzz(int startIndex, int endIndex)
        {
            List<string> output = new List<string>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                var checks = RunFizzBuzzRuleChecks(i);

                output = CreateFizzBuzzList(i, checks, output);
            }

            return output;
        }

        private static List<string> DecrementFizzBuzz(int startIndex, int endIndex)
        {
            List<string> output = new List<string>();

            for (int i = startIndex; i >= endIndex; i--)
            {
                var ruleChecks = RunFizzBuzzRuleChecks(i);

                output = CreateFizzBuzzList(i, ruleChecks, output);
            }

            return output;
        }

        public static List<(int index, string value)> FizzBuzzRules = new List<(int index, string value)>
        {
            (index: 3, value: "Fizz"),
            (index: 5, value: "Buzz"),
            (index: 7, value: "Jazz")
        };

        private static List<(int index, string value)> RunFizzBuzzRuleChecks(int index)
        {
            var ruleChecks = FizzBuzzRules.Where(x => index % x.index == 0).ToList();
            
            return ruleChecks;
        }

        private static List<string> CreateFizzBuzzList(int index, List<(int index, string value)> ruleChecks, List<string> output)
        {
            if (index == 0)
            {
                output.Add(index.ToString());
            }
            else if (ruleChecks.Count() == 0)
            {
                output.Add(index.ToString());
            }
            else
            {
                output.Add(string.Join("", ruleChecks.Select(x => x.value)) + $" ({index})");
            }

            return output;
        }

        public static void PrintFizzBuzzValues(this List<string> fizzBuzz)
        {
            foreach (var value in fizzBuzz)
            {
                Console.WriteLine(value);
            }
        }
    }
}
