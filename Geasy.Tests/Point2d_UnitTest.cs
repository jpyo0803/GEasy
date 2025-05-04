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
            Assert.True(HelperFunc.NearlyEqualFloat(point.X, 1.0f), "X coordinate should be 1.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(point.Y, 2.0f), "Y coordinate should be 2.0f");

            point.X = 3.0f;
            point.Y = 4.0f;

            Assert.True(HelperFunc.NearlyEqualFloat(point.X, 3.0f), "X coordinate should be 3.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(point.Y, 4.0f), "Y coordinate should be 4.0f");
        }

        [Fact]
        public void TestDistance_Float()
        {
            Point2dFloat pointA = new Point2dFloat(1.0f, 2.0f);
            Point2dFloat pointB = new Point2dFloat(4.0f, 6.0f);

            double expectedDistance = Math.Sqrt(3 * 3 + 4 * 4); // 5.0
            double actualDistance = Point2dFloat.Distance(pointA, pointB);

            Assert.True(HelperFunc.NearlyEqualDouble(actualDistance, expectedDistance), "Distance should be approximately 5.0");
        }

        [Fact]
        public void TestEquals_Float()
        {
            Point2dFloat pointA = new Point2dFloat(1.0f, 2.0f);
            Point2dFloat pointB = new Point2dFloat(1.0f, 2.0f);
            Point2dFloat pointC = new Point2dFloat(3.0f, 4.0f);

            Assert.True(pointA.Equals(pointB), "Point A should be equal to Point B");
            Assert.False(pointA.Equals(pointC), "Point A should not be equal to Point C");

            Assert.False(pointA.Equals(null), "Point A should not be equal to null");
            int x = 5;
            Assert.False(pointA.Equals(x), "Point A should not be equal to an integer");
        }

        [Fact]
        public void TestIsCCW_Float()
        {
            Point2dFloat pointA = new Point2dFloat(0.0f, 0.0f);
            Point2dFloat pointB = new Point2dFloat(1.0f, 0.0f);
            Point2dFloat pointC = new Point2dFloat(1.0f, 1.0f);

            Assert.True(Point2dFloat.IsCCW(pointA, pointB, pointC) == 1, "Points should be in counter-clockwise order");

            pointC.Y = -1.0f;
            Assert.True(Point2dFloat.IsCCW(pointA, pointB, pointC) == -1, "Points should be in clockwise order");

            pointC.X = 2.0f;
            pointC.Y = 0.0f;
            Assert.True(Point2dFloat.IsCCW(pointA, pointB, pointC) == 0, "Points should be collinear");
        }
    }
}