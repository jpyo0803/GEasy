using System;
using System.Collections.Generic;
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
    }
}