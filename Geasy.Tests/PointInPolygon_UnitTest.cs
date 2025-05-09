using Xunit;
using Geasy;
using System;

using System.Collections.Generic;

namespace Geasy.Tests
{
    public class PointInPolygonTests
    {
        [Fact]
        public void TestPointInPolygon()
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(4, 0),
                new Point2dFloat(4, 4),
                new Point2dFloat(0, 4)
            };

            var insidePoint = new Point2dFloat(2, 2);
            Assert.True(PointInPolygon.IsPointInPolygon(insidePoint, polygon));
            Assert.True(PointInPolygon.Test_Cpp(insidePoint, polygon));

            var outsidePoint = new Point2dFloat(5, 5);
            Assert.False(PointInPolygon.IsPointInPolygon(outsidePoint, polygon));
            Assert.False(PointInPolygon.Test_Cpp(outsidePoint, polygon));
        }

        [Fact]
        public void TestPointInPolygonEdges()
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(4, 0),
                new Point2dFloat(4, 4),
                new Point2dFloat(0, 4)
            };

            var edgePoint1 = new Point2dFloat(2, 0);
            Assert.True(PointInPolygon.IsPointInPolygon(edgePoint1, polygon));
            Assert.True(PointInPolygon.Test_Cpp(edgePoint1, polygon));

            var edgePoint2 = new Point2dFloat(0, 2);
            Assert.True(PointInPolygon.IsPointInPolygon(edgePoint2, polygon));
            Assert.True(PointInPolygon.Test_Cpp(edgePoint2, polygon));

            var edgePoint3 = new Point2dFloat(4, 2);
            Assert.True(PointInPolygon.IsPointInPolygon(edgePoint3, polygon));
            Assert.True(PointInPolygon.Test_Cpp(edgePoint3, polygon));

            var edgePoint4 = new Point2dFloat(2, 4);
            Assert.True(PointInPolygon.IsPointInPolygon(edgePoint4, polygon));
            Assert.True(PointInPolygon.Test_Cpp(edgePoint4, polygon));
        }

        [Fact]
        public void TestPointInPolygonVertices()
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(4, 0),
                new Point2dFloat(4, 4),
                new Point2dFloat(0, 4)
            };

            var vertexPoint1 = new Point2dFloat(0, 0);
            Assert.True(PointInPolygon.IsPointInPolygon(vertexPoint1, polygon));
            Assert.True(PointInPolygon.Test_Cpp(vertexPoint1, polygon));

            var vertexPoint2 = new Point2dFloat(4, 0);
            Assert.True(PointInPolygon.IsPointInPolygon(vertexPoint2, polygon));
            Assert.True(PointInPolygon.Test_Cpp(vertexPoint2, polygon));

            var vertexPoint3 = new Point2dFloat(4, 4);
            Assert.True(PointInPolygon.IsPointInPolygon(vertexPoint3, polygon));
            Assert.True(PointInPolygon.Test_Cpp(vertexPoint3, polygon));

            var vertexPoint4 = new Point2dFloat(0, 4);
            Assert.True(PointInPolygon.IsPointInPolygon(vertexPoint4, polygon));
            Assert.True(PointInPolygon.Test_Cpp(vertexPoint4, polygon));
        }

        [Fact]
        public void TestPointInPolygonComplexPolygon()
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(2, 0),
                new Point2dFloat(2, 8),
                new Point2dFloat(5, 8),
                new Point2dFloat(5, 4),
                new Point2dFloat(10, 10),
                new Point2dFloat(0, 10),
            };

            var point1 = new Point2dFloat(5, 4);
            Assert.True(PointInPolygon.IsPointInPolygon(point1, polygon));
            Assert.True(PointInPolygon.Test_Cpp(point1, polygon));

            var point2 = new Point2dFloat(3, 4);
            Assert.False(PointInPolygon.IsPointInPolygon(point2, polygon));
            Assert.False(PointInPolygon.Test_Cpp(point2, polygon));

            var point3 = new Point2dFloat(1, 1);
            Assert.True(PointInPolygon.IsPointInPolygon(point3, polygon));
            Assert.True(PointInPolygon.Test_Cpp(point3, polygon));
        }

        [Fact]
        public void TestPointInPolygonComplexPolygon2()
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(10, 0),
                new Point2dFloat(7, 5),
                new Point2dFloat(7, 2),
                new Point2dFloat(3, 2),
                new Point2dFloat(3, 10),
                new Point2dFloat(0, 10),
            };

            var point1 = new Point2dFloat(7, 5);
            Assert.True(PointInPolygon.IsPointInPolygon(point1, polygon));
            Assert.True(PointInPolygon.Test_Cpp(point1, polygon));

            var point2 = new Point2dFloat(5, 5);
            Assert.False(PointInPolygon.IsPointInPolygon(point2, polygon));
            Assert.False(PointInPolygon.Test_Cpp(point2, polygon));

            var point3 = new Point2dFloat(1, 1);
            Assert.True(PointInPolygon.IsPointInPolygon(point3, polygon));
            Assert.True(PointInPolygon.Test_Cpp(point3, polygon));
        }
    }
}