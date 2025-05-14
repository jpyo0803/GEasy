using Xunit;
using Geasy;
using System;

using System.Collections.Generic;

namespace Geasy.Tests
{
    public class ConvexHullTests
    {
        [Fact]
        public void TestConvexHull_Square()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(0, 1),
                new Point2dFloat(1, 1),
                new Point2dFloat(1, 0),
                new Point2dFloat(0.5f, 0.5f) // 내부 점
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 0),
                new Point2dFloat(1, 1),
                new Point2dFloat(0, 1)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHull, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);
            Assert.Equal(expectedHull.Count, actualHullCpp.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHullCpp, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }
        }

        [Fact]
        public void TestConvexHull_ColinearPoints()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 1),
                new Point2dFloat(2, 2)
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 2)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHull, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);

            Assert.Equal(expectedHull.Count, actualHullCpp.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHullCpp, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }
        }

        [Fact]
        public void TestConvexHull_Triangle()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 0),
                new Point2dFloat(1, 2),
                new Point2dFloat(1, 1) // 내부 점
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 0),
                new Point2dFloat(1, 2)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHull, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);

            Assert.Equal(expectedHull.Count, actualHullCpp.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHullCpp, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }
        }

        [Fact]
        public void TestConvexHull_WithDuplicates()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 1),
                new Point2dFloat(2, 0),
                new Point2dFloat(1, -1),
                new Point2dFloat(0, 0), // duplicate
                new Point2dFloat(1, 1), // duplicate
                new Point2dFloat(2, 0)  // duplicate
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(1, 1),
                new Point2dFloat(1, -1),
                new Point2dFloat(2, 0)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHull, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);
            Assert.Equal(expectedHull.Count, actualHullCpp.Count);

            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHullCpp, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }
        }

        [Fact]
        public void TestConvexHull_UShape()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 0),
                new Point2dFloat(0, 2),
                new Point2dFloat(2, 2),
                new Point2dFloat(1, 1) // 가운데 깊이 파인 점
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 0),
                new Point2dFloat(2, 2),
                new Point2dFloat(0, 2)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            for (int i = 0; i < expectedHull.Count; i++)
            {
                Assert.True(HelperFunc.NearlyEqualFloat(expectedHull[i].X, actualHull[i].X));
                Assert.True(HelperFunc.NearlyEqualFloat(expectedHull[i].Y, actualHull[i].Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);
            Assert.Equal(expectedHull.Count, actualHullCpp.Count);
            for (int i = 0; i < expectedHull.Count; i++)
            {
                Assert.True(HelperFunc.NearlyEqualFloat(expectedHull[i].X, actualHullCpp[i].X));
                Assert.True(HelperFunc.NearlyEqualFloat(expectedHull[i].Y, actualHullCpp[i].Y));
            }
        }

        [Fact]
        public void TestConvexHull_ThousandPointsOnCircle()
        {
            var points = new List<IPoint2d<float>>();
            int N = 1000;
            for (int i = 0; i < N; i++)
            {
                float angle = (float)(2 * Math.PI * i / N);
                float x = (float)Math.Cos(angle);
                float y = (float)Math.Sin(angle);
                points.Add(new Point2dFloat(x, y));
            }

            var hull = ConvexHull.Construct(points);

            Assert.True(hull.Count >= 10); // 원이므로 많은 점이 외곽에 있어야 함

            // Check if the hull points are on the circle

            var hull_cpp = ConvexHull.Build_Cpp(points);

            Assert.True(hull_cpp.Count >= 10); // 원이므로 많은 점이 외곽에 있어야 함
        }
        [Fact]
        public void TestConvexHull_HighPrecisionPoints()
        {
            var points = new List<IPoint2d<float>>
            {
                new Point2dFloat(0.321535f, 0.036296f),
                new Point2dFloat(0.024024f, -0.235673f),
                new Point2dFloat(0.045909f, -0.415641f),
                new Point2dFloat(0.321838f, 0.137985f),
                new Point2dFloat(0.115065f, -0.105952f),
                new Point2dFloat(0.262254f, -0.297029f),
                new Point2dFloat(-0.161921f, -0.405534f),
                new Point2dFloat(0.190538f, 0.369860f),
                new Point2dFloat(0.238709f, -0.016298f),
                new Point2dFloat(0.074959f, -0.165983f),
                new Point2dFloat(0.331934f, -0.182181f),
                new Point2dFloat(0.077036f, -0.249943f),
                new Point2dFloat(0.206924f, -0.223297f),
                new Point2dFloat(0.046041f, -0.192357f),
                new Point2dFloat(0.050543f, 0.475493f),
                new Point2dFloat(-0.390059f, 0.279783f),
                new Point2dFloat(0.312069f, -0.050633f),
                new Point2dFloat(0.011388f, 0.400250f),
                new Point2dFloat(0.009645f, 0.106025f),
                new Point2dFloat(-0.035979f, 0.295364f),
                new Point2dFloat(0.181829f, 0.001454f),
                new Point2dFloat(0.444056f, 0.250250f),
                new Point2dFloat(-0.053018f, -0.065539f),
                new Point2dFloat(0.482390f, -0.477617f),
                new Point2dFloat(-0.308923f, -0.063561f),
                new Point2dFloat(-0.271781f, 0.181081f),
                new Point2dFloat(0.429363f, 0.298090f),
                new Point2dFloat(-0.004797f, 0.382664f),
                new Point2dFloat(0.430696f, -0.299507f),
                new Point2dFloat(0.179967f, -0.297347f),
                new Point2dFloat(0.493217f, 0.492809f),
                new Point2dFloat(-0.352149f, 0.435266f),
                new Point2dFloat(-0.490737f, 0.186583f),
                new Point2dFloat(-0.104792f, -0.247073f),
                new Point2dFloat(0.437496f, -0.001606f),
                new Point2dFloat(0.003256f, -0.272919f),
                new Point2dFloat(0.043104f, 0.445260f),
                new Point2dFloat(0.491620f, -0.345392f),
                new Point2dFloat(0.001675f, 0.153184f),
                new Point2dFloat(-0.440429f, -0.289486f)
            };

            var expectedHull = new List<IPoint2d<float>>
            {
                new Point2dFloat(-0.161921f, -0.405534f),
                new Point2dFloat(0.050543f, 0.475493f),
                new Point2dFloat(0.482390f, -0.477617f),
                new Point2dFloat(0.493217f, 0.492809f),
                new Point2dFloat(-0.352149f, 0.435266f),
                new Point2dFloat(-0.490737f, 0.186583f),
                new Point2dFloat(0.491620f, -0.345392f),
                new Point2dFloat(-0.440429f, -0.289486f)
            };

            var actualHull = ConvexHull.Construct(points);

            Assert.Equal(expectedHull.Count, actualHull.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHull, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }

            var actualHullCpp = ConvexHull.Build_Cpp(points);

            Assert.Equal(expectedHull.Count, actualHullCpp.Count);
            foreach (var expected in expectedHull)
            {
                Assert.Contains(actualHullCpp, actual =>
                    HelperFunc.NearlyEqualFloat(expected.X, actual.X) &&
                    HelperFunc.NearlyEqualFloat(expected.Y, actual.Y));
            }
        }

    }
}