using Xunit;
using Geasy;
using System;

namespace Geasy.Tests
{
    public class Point2dImplTests
    {
        [Fact]
        public void TestGetterAndSetter_Int()
        {
            Point2dImpl<int> x = new Point2dImpl<int>(2, 3);
            Assert.True(NearlyEqualInt(2, x.X), $"Expected 2, but got {x.X}");
            Assert.True(NearlyEqualInt(3, x.Y), $"Expected 3, but got {x.Y}");
            x.X = -5;
            x.Y = 7;
            Assert.True(NearlyEqualInt(-5, x.X), $"Expected -5, but got {x.X}");
            Assert.True(NearlyEqualInt(7, x.Y), $"Expected 7, but got {x.Y}");
        }

        [Fact]
        public void TestGetterAndSetter_Double()
        {
            const double epsilon = 1e-9; // Define a small epsilon for floating-point comparison
            Point2dImpl<double> x = new Point2dImpl<double>(2.342, -3.555);
            Assert.True(NearlyEqualDouble(2.342, x.X, epsilon), $"Expected 2.342, but got {x.X}");
            Assert.True(NearlyEqualDouble(-3.555, x.Y, epsilon), $"Expected -3.555, but got {x.Y}");
            x.X = -5.123456789;
            x.Y = 7.987654321;
            Assert.True(NearlyEqualDouble(-5.123456789, x.X, epsilon), $"Expected -5.123456789, but got {x.X}");
            Assert.True(NearlyEqualDouble(7.987654321, x.Y, epsilon), $"Expected 7.987654321, but got {x.Y}");
        }

        private static bool NearlyEqualDouble(double a, double b, double epsilon = 1e-9)
        {
            return Math.Abs(a - b) < epsilon;
        }

        private static bool NearlyEqualInt(int a, int b, double epsilon = 1e-9)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}