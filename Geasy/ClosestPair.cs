using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
// using System.Linq;

namespace Geasy
{

    public class ClosestPair
    {
        public class Point2dFloatWithTag : IPoint2d<float>
        {
            public float X { get; set; }
            public float Y { get; set; }
            public int Tag { get; set; }

            public Point2dFloatWithTag(float x, float y, int tag)
            {
                X = x;
                Y = y;
                Tag = tag;
            }
        }
        // Return closest pair of points and their distance
        public static ((IPoint2d<float>, IPoint2d<float>) pair, double distance) Solve(List<IPoint2d<float>> points)
        {
            if (points == null || points.Count < 2)
            {
                throw new ArgumentException("At least two points are required to find the closest pair.");
            }

            var tagged_points_sorted_x = new List<Point2dFloatWithTag>();
            var tagged_points_sorted_y = new List<Point2dFloatWithTag>();

            for (int i = 0; i < points.Count; i++)
            {
                tagged_points_sorted_x.Add(new Point2dFloatWithTag(points[i].X, points[i].Y, -1)); // tag after sorting by x
            }

            tagged_points_sorted_x.Sort((a, b) => a.X.CompareTo(b.X));
            for (int i = 0; i < tagged_points_sorted_x.Count; i++)
            {
                tagged_points_sorted_x[i].Tag = i; // tag after sorting by x
            }

            // copy sorted x to sorted y
            tagged_points_sorted_y.AddRange(tagged_points_sorted_x);
            tagged_points_sorted_y.Sort((a, b) => a.Y.CompareTo(b.Y));


            var (closest_pair, min_dist) = ClosestPairRec(ref tagged_points_sorted_x, ref tagged_points_sorted_y);

            return ((closest_pair), min_dist);
        }

        private static ((IPoint2d<float>, IPoint2d<float>) pair, double min_dist) ClosestPairRec(ref List<Point2dFloatWithTag> points_sorted_x, ref List<Point2dFloatWithTag> points_sorted_y)
        {
            const float epsilon = 1e-6f;

            double min_dist = double.MaxValue;
            IPoint2d<float> closest_point1 = null;
            IPoint2d<float> closest_point2 = null;

            if (points_sorted_x.Count <= 3)
            {
                // Brute force search for 3 points or less
                for (int i = 0; i < points_sorted_x.Count - 1; i++)
                {
                    for (int j = i + 1; j < points_sorted_x.Count; j++)
                    {
                        double dist = Point2dFloat.Distance(points_sorted_x[i], points_sorted_x[j]);
                        if (dist < min_dist)
                        {
                            min_dist = dist;
                            closest_point1 = points_sorted_x[i];
                            closest_point2 = points_sorted_x[j];
                        }
                    }
                }
                return ((closest_point1, closest_point2), min_dist);
            }

            int n = points_sorted_x.Count;
            int mTag = n / 2;
            var mTagPoint = points_sorted_x[mTag];

            var left_sorted_x = points_sorted_x.GetRange(0, mTag);
            var right_sorted_x = points_sorted_x.GetRange(mTag, n - mTag);
            var left_sorted_y = new List<Point2dFloatWithTag>();
            var right_sorted_y = new List<Point2dFloatWithTag>();

            foreach (var point in points_sorted_y)
            {
                if (point.X < mTagPoint.X - epsilon)
                {
                    left_sorted_y.Add(point);
                }
                else if (point.X > mTagPoint.X + epsilon)
                {
                    right_sorted_y.Add(point);
                }
                else // point.X == mTagPoint.X
                {
                    if (point.Tag < mTagPoint.Tag)
                    {
                        left_sorted_y.Add(point);
                    }
                    else
                    {
                        right_sorted_y.Add(point);
                    }
                }
            }

            var (result_left, min_dist_left) = ClosestPairRec(ref left_sorted_x, ref left_sorted_y);
            var (result_right, min_dist_right) = ClosestPairRec(ref right_sorted_x, ref right_sorted_y);

            min_dist = Math.Min(min_dist_left, min_dist_right);

            closest_point1 = min_dist_left < min_dist_right ? result_left.Item1 : result_right.Item1;
            closest_point2 = min_dist_left < min_dist_right ? result_left.Item2 : result_right.Item2;

            var strip = new List<Point2dFloatWithTag>();
            foreach (var point in points_sorted_y)
            {
                if (Math.Abs(point.X - mTagPoint.X) < min_dist)
                {
                    strip.Add(point);
                }
            }

            for (int i = 0; i < strip.Count; i++)
            {
                for (int j = i + 1; j < strip.Count && (strip[j].Y - strip[i].Y) < min_dist; j++)
                {
                    double dist = Point2dFloat.Distance(strip[i], strip[j]);
                    if (dist < min_dist)
                    {
                        min_dist = dist;
                        closest_point1 = strip[i];
                        closest_point2 = strip[j];
                    }
                }
            }

            return ((closest_point1, closest_point2), min_dist);
        }


        [DllImport(NativeLibrary.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]

        private static extern void ClosestPairFloat(
            [In] float[] points_x_arr,
            [In] float[] points_y_arr,
            int size,
            out float x1,
            out float y1,
            out float x2,
            out float y2,
            out double min_dist);

        public static ((IPoint2d<float>, IPoint2d<float>) pair, double distance) Solve_Cpp(List<IPoint2d<float>> points)
        {
            int size = points.Count;
            float[] points_x_arr = new float[size];
            float[] points_y_arr = new float[size];

            for (int i = 0; i < size; i++)
            {
                points_x_arr[i] = points[i].X;
                points_y_arr[i] = points[i].Y;
            }

            float x1, y1, x2, y2;
            double min_dist;
            ClosestPairFloat(points_x_arr, points_y_arr, size, out x1, out y1, out x2, out y2, out min_dist);
            var point1 = new Point2dFloat(x1, y1);
            var point2 = new Point2dFloat(x2, y2);
            return ((point1, point2), min_dist);
        }
    }
}