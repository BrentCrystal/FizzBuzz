using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FizzBuzzLibrary.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        [InlineData("Fizz (3)")]
        [InlineData("4")]
        [InlineData("Buzz (5)")]
        [InlineData("Fizz (6)")]
        [InlineData("7")]
        [InlineData("8")]
        [InlineData("Fizz (9)")]
        [InlineData("Buzz (10)")]
        [InlineData("11")]
        [InlineData("Fizz (12)")]
        [InlineData("13")]
        [InlineData("14")]
        [InlineData("FizzBuzz (15)")]
        public void RunBasicFizzBuzzShouldReturnExpectedValue(string expected)
        {
            //Arrange
            List<string> fizzBuzz = new List<string>();

            //Act
            fizzBuzz = FizzBuzz.RunBasicFizzBuzz();
            
            //Assert
            Assert.Contains(fizzBuzz, value => value == expected);
        }

        [Fact]
        public void RunElaborateFizzBuzzShouldReturnExpectedValue()
        {
            //Arrange
            var expected = new List<string>();
            expected.AddRange(new[]
            {"1", "2", "Fizz", "4", "Buzz", "Fizz", "Jazz", "8", "Fizz", "Buzz", "11", "Fizz", "13", "Jazz", "FizzBuzz"});

            //Act
            var actual = FizzBuzz.RunElaborateFizzBuzz(1, 15);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
