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

        [Fact]
        public void TestBasicOperations_Float()
        {
            Vector2dFloat vectorA = new Vector2dFloat(1.0f, 2.0f);
            Vector2dFloat vectorB = new Vector2dFloat(3.0f, 4.0f);

            // Addition
            Vector2dFloat sum = vectorA + vectorB;
            Assert.True(HelperFunc.NearlyEqualFloat(sum.X, 4.0f), "X coordinate of sum should be 4.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(sum.Y, 6.0f), "Y coordinate of sum should be 6.0f");

            // Subtraction
            Vector2dFloat difference = vectorA - vectorB;
            Assert.True(HelperFunc.NearlyEqualFloat(difference.X, -2.0f), "X coordinate of difference should be -2.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(difference.Y, -2.0f), "Y coordinate of difference should be -2.0f");

            // Scalar multiplication
            double scalar = 2.0f;
            Vector2dFloat scaled = vectorA * scalar;
            Assert.True(HelperFunc.NearlyEqualFloat(scaled.X, 2.0f), "X coordinate of scaled vector should be 2.0f");
            Assert.True(HelperFunc.NearlyEqualFloat(scaled.Y, 4.0f), "Y coordinate of scaled vector should be 4.0f");

            // Scalar division
            double divisor = 2.0f;
            Vector2dFloat divided = vectorA / divisor;
            Assert.True(HelperFunc.NearlyEqualFloat(divided.X, 0.5f), "X coordinate of divided vector should be 0.5f");
            Assert.True(HelperFunc.NearlyEqualFloat(divided.Y, 1.0f), "Y coordinate of divided vector should be 1.0f");

            // +=, -=, *=, /= operators
            vectorA += vectorB;
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.X, 4.0f), "X coordinate of vectorA should be 4.0f after += operation");
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.Y, 6.0f), "Y coordinate of vectorA should be 6.0f after += operation");

            vectorA -= vectorB;
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.X, 1.0f), "X coordinate of vectorA should be 1.0f after -= operation");
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.Y, 2.0f), "Y coordinate of vectorA should be 2.0f after -= operation");

            vectorA *= scalar;
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.X, 2.0f), "X coordinate of vectorA should be 2.0f after *= operation");
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.Y, 4.0f), "Y coordinate of vectorA should be 4.0f after *= operation");

            vectorA /= divisor;
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.X, 1.0f), "X coordinate of vectorA should be 1.0f after /= operation");
            Assert.True(HelperFunc.NearlyEqualFloat(vectorA.Y, 2.0f), "Y coordinate of vectorA should be 2.0f after /= operation");
        }
        
    }
}