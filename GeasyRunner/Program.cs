using Geasy;
using System;
using System.Collections.Generic;

namespace GeasyRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // make polygon with randomly generated 1 M points
            var polygon = new List<IPoint2d<float>>();
            Random random = new Random();
            for (int i = 0; i < 10000000; i++)
            {
                float x = (float)(random.NextDouble() * 100);
                float y = (float)(random.NextDouble() * 100);
                polygon.Add(new Point2dFloat(x, y));
            }

            // generate one point
            float pointX = (float)(random.NextDouble() * 100);
            float pointY = (float)(random.NextDouble() * 100);

            var point = new Point2dFloat(pointX, pointY);
            // test if point is in polygon

            // measure time
            var watch = System.Diagnostics.Stopwatch.StartNew();
            bool isInPolygon = PointInPolygon.IsPointInPolygon(point, polygon);
            watch.Stop();
            Console.WriteLine($"Time taken for C#: {watch.ElapsedMilliseconds} ms");
            // measure time for C++ version
            watch.Restart();
            bool isInPolygonCpp = PointInPolygon.Test_Cpp(point, polygon);
            watch.Stop();
            Console.WriteLine($"Time taken for C++: {watch.ElapsedMilliseconds} ms");

            // print result
            Console.WriteLine($"Point: ({pointX}, {pointY})");
            Console.WriteLine($"Is in polygon: {isInPolygon}");
            Console.WriteLine($"Is in polygon (C++): {isInPolygonCpp}");
        }
    }
}
