using Xunit;
using Geasy;
using System;

namespace Geasy.Tests
{
    public class Vector2dImplTests
    {
        [Fact]
        public void TestGetterAndSetter_Float()
        {
            Vector2dFloat vector = new Vector2dFloat(1.0f, 2.0f);
            Assert.True(HelperFunc.NearlyEqualFloat(vector.X, 1.0f), "X coordinate should be 1.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(vector.Y, 2.0f), "Y coordinate should be 2.0f");

            vector.X = 3.0f;
            vector.Y = 4.0f;

            Assert.True(HelperFunc.NearlyEqualFloat(vector.X, 3.0f), "X coordinate should be 3.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(vector.Y, 4.0f), "Y coordinate should be 4.0f");
        }

        [Fact]

        public void TestVectorCreationFromPoints_Float()
        {
            Point2dFloat pointA = new Point2dFloat(1.0f, 2.0f);
            Point2dFloat pointB = new Point2dFloat(4.0f, 6.0f);

            Vector2dFloat vector = new Vector2dFloat(pointA, pointB);

            Assert.True(HelperFunc.NearlyEqualFloat(vector.X, 3.0f), "X coordinate should be 3.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(vector.Y, 4.0f), "Y coordinate should be 4.0f");
        }
    }
}