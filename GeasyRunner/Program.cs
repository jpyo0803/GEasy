using Geasy;
using System;
using System.Collections.Generic;

namespace GeasyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var polygon = new List<IPoint2d<float>>
            {
                new Point2dFloat(0, 0),
                new Point2dFloat(4, 0),
                new Point2dFloat(4, 4),
                new Point2dFloat(0, 4)
            };

            var insidePoint = new Point2dFloat(2, 2);
            PointInPolygon.Test_Cpp(insidePoint, polygon);

            var outsidePoint = new Point2dFloat(5, 5);
            PointInPolygon.Test_Cpp(outsidePoint, polygon);
        }
    }
}
