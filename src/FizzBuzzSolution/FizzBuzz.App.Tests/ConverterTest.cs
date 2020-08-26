using System.Linq;
using Xunit;

namespace FizzBuzz.App.Tests
{
    public class ConverterTest
    {
        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(3, "Fizz")]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(6, "Fizz")]
        [InlineData(7, "7")]
        [InlineData(8, "8")]
        [InlineData(9, "Fizz")]
        [InlineData(10, "Buzz")]
        [InlineData(11, "11")]
        [InlineData(12, "Fizz")]
        [InlineData(13, "13")]
        [InlineData(14, "14")]
        [InlineData(15, "FizzBuzz")]
        public void FizzBuzz(int number, string result)
        {
            var results = Converter.CountUp(number, number);
            Assert.Single(results);
            Assert.Equal(result, results.First());
        }
    }
}
