using System;

namespace FizzBuzzProblem
{
	/// <summary>
	/// FizzBuzz問題の回答例
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
			var start = 1;
			var end = 100;

			for (var i = start; i <= end; i++)
			{
				var result = "";

				if (i % 15 == 0)
				{
					result = "FizzBuzz";
				}
				else if (i % 5 == 0)
				{
					result = "Buzz";
				}
				else if (i % 3 == 0)
				{
					result = "Fizz";
				}
				else
				{
					result = i.ToString();
				}

				Console.WriteLine(result);
			}

			Console.WriteLine("-- press enter key");
			Console.ReadLine();
		}
	}
}
