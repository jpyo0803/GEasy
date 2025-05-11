using Xunit;
using Geasy;
using System;

using System.Collections.Generic;

namespace Geasy.Tests
{
    public class ClosestPairTests
    {
        [Fact]
        public void TestClosestPair()
        {
            /*
                0 0
                10 10
                0 10
                10 0
            */

            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(10, 10),
                new Point2dFloat(0, 10),
                new Point2dFloat(10, 0)
            };

            // Expected distance is 10
            double expectedDistance = 10.0;

            var result = ClosestPair.Solve(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result.Item2, expectedDistance), "Distance should be approximately 10.0");

            var result_cpp = ClosestPair.Solve_Cpp(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result_cpp.Item2, expectedDistance), "Distance should be approximately 10.0");
        }

        [Fact]
        public void TestClosestPair_Collinear()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 1),
                new Point2dFloat(2, 2),
                new Point2dFloat(3, 3)
            };

            // Expected distance is 1.414 (between (0,0) and (1,1))
            double expectedDistance = Math.Sqrt(2);

            var result = ClosestPair.Solve(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result.Item2, expectedDistance), "Distance should be approximately 1.414");

            var result_cpp = ClosestPair.Solve_Cpp(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result_cpp.Item2, expectedDistance), "Distance should be approximately 1.414");
        }

        [Fact]
        public void TestClosestPair_V()
        {
            /*
            -2 100
            -1 50
            0 0
            1 100
            */

            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(-2, 100),
                new Point2dFloat(-1, 50),
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 100)
            };

            // Expected distance is 3.0, between (-2, 100, 1, 100)
            double expectedDistance = 3.0;

            var result = ClosestPair.Solve(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result.Item2, expectedDistance), "Distance should be approximately 3.0");
            Assert.True(result.Item1.Item1.X == -2 && result.Item1.Item1.Y == 100, "First point should be (-2, 100)");
            Assert.True(result.Item1.Item2.X == 1 && result.Item1.Item2.Y == 100, "Second point should be (1, 100)");

            var result_cpp = ClosestPair.Solve_Cpp(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result_cpp.Item2, expectedDistance), "Distance should be approximately 3.0");
            Assert.True(result_cpp.Item1.Item1.X == -2 && result_cpp.Item1.Item1.Y == 100, "First point should be (-2, 100)");
            Assert.True(result_cpp.Item1.Item2.X == 1 && result_cpp.Item1.Item2.Y == 100, "Second point should be (1, 100)");
        }

        [Fact]
        public void TestClosestPair_Case1()
        {
            /*
            -5 0
            -3 4
            2 1
            3 4
            -1 1
            8 8
            1 7
            */

            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(-5, 0),
                new Point2dFloat(-3, 4),
                new Point2dFloat(2, 1),
                new Point2dFloat(3, 4),
                new Point2dFloat(-1, 1),
                new Point2dFloat(8, 8),
                new Point2dFloat(1, 7)
            };

            // Expected distance is 3.0, between (2, 1) and (-1, 1)
            double expectedDistance = 3.0;

            var result = ClosestPair.Solve(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result.Item2, expectedDistance), "Distance should be approximately 3.0");
            Assert.True(result.Item1.Item1.X == -1 && result.Item1.Item1.Y == 1, "First point should be (-1, 1)");
            Assert.True(result.Item1.Item2.X == 2 && result.Item1.Item2.Y == 1, "Second point should be (2, 1)");

            var result_cpp = ClosestPair.Solve_Cpp(points);
            Assert.True(HelperFunc.NearlyEqualDouble(result_cpp.Item2, expectedDistance), "Distance should be approximately 3.0");
            Assert.True(result_cpp.Item1.Item1.X == -1 && result_cpp.Item1.Item1.Y == 1, "First point should be (-1, 1)");
            Assert.True(result_cpp.Item1.Item2.X == 2 && result_cpp.Item1.Item2.Y == 1, "Second point should be (2, 1)");
        }
    }
}