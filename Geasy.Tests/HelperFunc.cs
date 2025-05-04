using System;

namespace Geasy.Tests
{
    public static class HelperFunc
    {
        public static bool NearlyEqualFloat(float a, float b, float tolerance = 1e-6f)
        {
            return Math.Abs(a - b) < tolerance;
        }

        public static bool NearlyEqualDouble(double a, double b, double tolerance = 1e-9)
        {
            return Math.Abs(a - b) < tolerance;
        }
    }
}