using System.Collections.Generic;

namespace FizzBuzz.App
{
    public static class Converter
    {
        public static bool IsFizz(int n) => n != 0 && n % 3 == 0;

        public static bool IsBuzz(int n) => n != 0 && n % 5 == 0;

        public static bool IsFizzBuzz(int n) => IsFizz(n) && IsBuzz(n);

        public static string Convert(int n)
        {
            if (IsFizzBuzz(n))
                return "FizzBuzz";
            if (IsBuzz(n))
                return "Buzz";
            if (IsFizz(n))
                return "Fizz";

            return n.ToString();
        }

        public static IEnumerable<string> CountUp(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                yield return Convert(i);
            }
        }
    }
}
