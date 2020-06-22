using System.Collections.Generic;

namespace FizzBuzz.App
{
    public class Counter
    {
        public static IEnumerable<string> Count(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                if (i % 15 == 0)
                {
                    yield return "FizzBuzz";
                }
                else if (i % 5 == 0)
                {
                    yield return "Buzz";
                }
                else if (i % 3 == 0)
                {
                    yield return "Fizz";
                }
                else
                {
                    yield return i.ToString();
                }
            }
        }
    }
}
