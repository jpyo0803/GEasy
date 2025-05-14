using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Geasy
{
    public class ConvexHull
    {
        public static List<IPoint2d<float>> Construct(List<IPoint2d<float>> points)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("Convex hull requires at least 3 points.");
            }

            // Andrew's monotone chain algorithm
            points = points.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();
            var uniquePoints = DeduplicateSorted(points);

            List<IPoint2d<float>> lower = new List<IPoint2d<float>>();
            List<IPoint2d<float>> upper = new List<IPoint2d<float>>();

            for (int i = 0; i < uniquePoints.Count; i++)
            {
                while (lower.Count >= 2 && Point2dFloat.IsCCW(lower[lower.Count - 2], lower[lower.Count - 1], uniquePoints[i]) <= 0)
                    lower.RemoveAt(lower.Count - 1);
                lower.Add(uniquePoints[i]);
            }

            for (int i = uniquePoints.Count - 1; i >= 0; i--)
            {
                while (upper.Count >= 2 && Point2dFloat.IsCCW(upper[upper.Count - 2], upper[upper.Count - 1], uniquePoints[i]) <= 0)
                    upper.RemoveAt(upper.Count - 1);
                upper.Add(uniquePoints[i]);
            }

            upper.RemoveAt(upper.Count - 1); // Remove the last point because it's repeated at the beginning of lower
            lower.RemoveAt(lower.Count - 1); // Remove the last point because it's repeated at the beginning of upper

            return lower.Concat(upper).ToList();
        }

        // TODO(jpyo0803): If this function is used in other places, move it to the helper class
        // Time complexity: O(n*log2(n))
        private static List<IPoint2d<float>> DeduplicateSorted(List<IPoint2d<float>> sortedPoints)
        {
            const float epsilon = 1e-6f;
            var unique = new List<IPoint2d<float>>();

            for (int i = 0; i < sortedPoints.Count; i++)
            {
                if (i == 0 ||
                    Math.Abs(sortedPoints[i].X - sortedPoints[i - 1].X) > epsilon ||
                    Math.Abs(sortedPoints[i].Y - sortedPoints[i - 1].Y) > epsilon)
                {
                    unique.Add(sortedPoints[i]);
                }
            }

            return unique;
        }

        [DllImport(NativeLibrary.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ConvexHullFloat(
            [In] float[] points_x_arr,
            [In] float[] points_y_arr,
            int size,
            [Out] float[] hull_x_arr,
            [Out] float[] hull_y_arr,
            out int hull_size);

        public static List<IPoint2d<float>> Build_Cpp(List<IPoint2d<float>> points)
        {
            int size = points.Count;
            float[] points_x_arr = new float[size];
            float[] points_y_arr = new float[size];

            for (int i = 0; i < size; i++)
            {
                points_x_arr[i] = points[i].X;
                points_y_arr[i] = points[i].Y;
            }

            float[] hull_x_arr = new float[size];
            float[] hull_y_arr = new float[size];
            ConvexHullFloat(points_x_arr, points_y_arr, size, hull_x_arr, hull_y_arr, out int hull_size);

            var hull = new List<IPoint2d<float>>(hull_size);
            for (int i = 0; i < hull_size; i++)
            {
                hull.Add(new Point2dFloat(hull_x_arr[i], hull_y_arr[i]));
            }

            return hull;
        }
    }
}