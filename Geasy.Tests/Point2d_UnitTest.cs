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
            Point2dFloat point = new Point2dFloat(1.0f, 2.0f);
            Assert.True(NearlyEqualFloat(point.X, 1.0f), "X coordinate should be 1.0f");
            Assert.True(NearlyEqualFloat(point.Y, 2.0f), "Y coordinate should be 2.0f");

            point.X = 3.0f;
            point.Y = 4.0f;

            Assert.True(NearlyEqualFloat(point.X, 3.0f), "X coordinate should be 3.0f");
            Assert.True(NearlyEqualFloat(point.Y, 4.0f), "Y coordinate should be 4.0f");
        }

        [Fact]
        public void TestDistanceTo_Float()
        {
            Point2dFloat pointA = new Point2dFloat(1.0f, 2.0f);
            Point2dFloat pointB = new Point2dFloat(4.0f, 6.0f);

            double expectedDistance = Math.Sqrt(3 * 3 + 4 * 4); // 5.0
            double actualDistance = pointA.DistanceTo(pointB);

            Assert.True(NearlyEqualDouble(actualDistance, expectedDistance), "Distance should be approximately 5.0");
        }

        private static bool NearlyEqualFloat(float a, float b, float epsilon = 1e-6f)
        {
            return Math.Abs(a - b) < epsilon;
        }

        private static bool NearlyEqualDouble(double a, double b, double epsilon = 1e-9)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}