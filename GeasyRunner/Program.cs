using Geasy;
using System;
using System.Collections.Generic;

namespace GeasyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> arr = new List<float> { 1.0f, 2.0f, 3.0f };
            float sum = Class1.TestSumCpp(arr);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
