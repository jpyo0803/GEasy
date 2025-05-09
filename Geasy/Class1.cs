using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Geasy
{
    public class Class1
    {
        public static void PrintHelloWorld()
        {
            Console.WriteLine("Hello, World!");
        }

        public static int TestAdd(int a, int b)
        {
            return a + b;
        }

        [DllImport("geasy_cpp.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern float TestSum(float[] arr, int size);

        public static float TestSumCpp(List<float> list)
        {
            return TestSum(list.ToArray(), list.Count);
        }
    }
}
