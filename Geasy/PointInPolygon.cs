using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
// using System.Linq;



namespace Geasy
{
    public class PointInPolygon
    {
        public static bool IsPointInPolygon(IPoint2d<float> point, List<IPoint2d<float>> polygon)
        {
            int n = polygon.Count;
            float x = point.X;
            float y = point.Y;

            int winding_cnt = 0;
            for (int i = 0; i < n; i++)
            {
                ILineSegment2d<float> line_segment = new LineSegment2dFloat(polygon[i], polygon[(i + 1) % n]);
                if (line_segment.IsPointOnMe(point))
                {
                    return true; // Point is on the edge of the polygon
                }

                float x0 = polygon[i].X;
                float y0 = polygon[i].Y;
                float x1 = polygon[(i + 1) % n].X;
                float y1 = polygon[(i + 1) % n].Y;

                if (Math.Min(y0, y1) <= point.Y && point.Y <= Math.Max(y0, y1))
                {
                    int ccw = line_segment.IsPointCCW(point);
                    if (y0 < y1 && ccw > 0)
                    {
                        winding_cnt++;
                    }
                    else if (y0 > y1 && ccw < 0)
                    {
                        winding_cnt--;
                    }
                }
            }
            // If winding count is not zero, the point is inside the polygon
            // If winding count is zero, the point is outside the polygon
            return winding_cnt != 0;
        }

        [DllImport(NativeLibrary.LIB_NAME, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)] // ✅ bool 반환 시 필요
        private static extern bool PNPolyFloat(
            float point_x,
            float point_y,
            [In] float[] polygon_x_arr,
            [In] float[] polygon_y_arr,
            int size);

        public static bool Test_Cpp(IPoint2d<float> point, List<IPoint2d<float>> polygon)
        {
            int size = polygon.Count;
            float[] polygon_x_arr = new float[size];
            float[] polygon_y_arr = new float[size];

            for (int i = 0; i < size; i++)
            {
                polygon_x_arr[i] = polygon[i].X;
                polygon_y_arr[i] = polygon[i].Y;
            }

            return PNPolyFloat(point.X, point.Y, polygon_x_arr, polygon_y_arr, size);
        }
    }
}