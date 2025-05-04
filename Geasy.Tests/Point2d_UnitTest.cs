using Xunit;
using Geasy;
using System;

namespace Geasy.Tests
{
    public class Point2dImplTests
    {
        [Fact]
        public void TestGetterAndSetter_Float()
        {
            const double epsilon = 1e-9; // Define a small epsilon for floating-point comparison
            Point2dFloat point = new Point2dFloat(1.0f, 2.0f);
            Assert.True(NearlyEqualFloat(point.X, 1.0f, epsilon), "X coordinate should be 1.0f");
            Assert.True(NearlyEqualFloat(point.Y, 2.0f, epsilon), "Y coordinate should be 2.0f");

            point.X = 3.0f;
            point.Y = 4.0f;

            Assert.True(NearlyEqualFloat(point.X, 3.0f, epsilon), "X coordinate should be 3.0f");
            Assert.True(NearlyEqualFloat(point.Y, 4.0f, epsilon), "Y coordinate should be 4.0f");
        }

        private static bool NearlyEqualFloat(float a, float b, double epsilon)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}