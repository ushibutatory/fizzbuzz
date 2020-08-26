﻿using System;

namespace FizzBuzz.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var start = 1;
            var end = 100;

            foreach (var result in Converter.CountUp(start, end))
            {
                Console.WriteLine(result);
            }
        }
    }
}
