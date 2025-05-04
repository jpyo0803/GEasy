using Xunit;
using Geasy;
using System;

namespace Geasy.Tests
{
    public class LineSegment2d_Tests
    {
        [Fact]
        public void TestGetterAndSetter_Float()
        {
            ILineSegment2d<float> lineSegment = new LineSegment2dFloat(new Point2dFloat(1.0f, 2.0f), new Point2dFloat(3.0f, 4.0f));
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.Start.X, 1.0f), "Start X coordinate should be 1.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.Start.Y, 2.0f), "Start Y coordinate should be 2.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.End.X, 3.0f), "End X coordinate should be 3.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.End.Y, 4.0f), "End Y coordinate should be 4.0f");

            lineSegment.Start = new Point2dFloat(5.0f, 6.0f);
            lineSegment.End = new Point2dFloat(7.0f, 8.0f);

            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.Start.X, 5.0f), "Start X coordinate should be 5.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.Start.Y, 6.0f), "Start Y coordinate should be 6.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.End.X, 7.0f), "End X coordinate should be 7.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(lineSegment.End.Y, 8.0f), "End Y coordinate should be 8.0f");
        }

        [Fact]
        public void TestLength_Float()
        {
            ILineSegment2d<float> lineSegment = new LineSegment2dFloat(new Point2dFloat(1.0f, 2.0f), new Point2dFloat(4.0f, 6.0f));
            double expectedLength = Math.Sqrt(3 * 3 + 4 * 4); // 5.0
            double actualLength = lineSegment.Length();

            Assert.True(HelperFunc.NearlyEqualDouble(actualLength, expectedLength), "Length should be approximately 5.0");
        }

        [Fact]
        public void TestToVector_Float()
        {
            ILineSegment2d<float> lineSegment = new LineSegment2dFloat(new Point2dFloat(1.0f, 2.0f), new Point2dFloat(4.0f, 6.0f));
            IVector2d<float> vector = lineSegment.ToVector();

            Assert.True(HelperFunc.NearlyEqualFloat(vector.X, 3.0f), "X coordinate of vector should be 3.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(vector.Y, 4.0f), "Y coordinate of vector should be 4.0f");
        }

        [Fact]
        public void TestIsPointCCW_Float()
        {
            ILineSegment2d<float> lineSegment = new LineSegment2dFloat(new Point2dFloat(0.0f, 0.0f), new Point2dFloat(1.0f, 0.0f));
            IPoint2d<float> pointCCW = new Point2dFloat(0.5f, 1.0f);
            IPoint2d<float> pointCW = new Point2dFloat(0.5f, -1.0f);
            IPoint2d<float> pointColinear = new Point2dFloat(0.5f, 0.0f);

            Assert.True(lineSegment.IsPointCCW(pointCCW) == 1, "Point should be in counter-clockwise direction");
            Assert.True(lineSegment.IsPointCCW(pointCW) == -1, "Point should be in clockwise direction");
            Assert.True(lineSegment.IsPointCCW(pointColinear) == 0, "Point should be collinear");
        }
    }
}