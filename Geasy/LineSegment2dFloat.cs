/*
    LineSegment2dFloat implementation
*/

using System;

namespace Geasy
{
    public class LineSegment2dFloat : ILineSegment2d<float>
    {
        public IPoint2d<float> Start { get; set; }
        public IPoint2d<float> End { get; set; }

        public LineSegment2dFloat(IPoint2d<float> start, IPoint2d<float> end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and end points cannot be null.");
            }

            Start = start;
            End = end;
        }

        public double Length()
        {
            return Point2dFloat.Distance(Start, End);
        }

        public IVector2d<float> ToVector()
        {
            return new Vector2dFloat(Start, End);
        }

        public int IsPointCCW(IPoint2d<float> point)
        {
            if (point == null)
            {
                throw new ArgumentNullException("Point cannot be null.");
            }

            return Point2dFloat.IsCCW(Start, End, point);
        }

        public bool IsPointOnMe(IPoint2d<float> point)
        {
            if (point == null)
            {
                throw new ArgumentNullException("Point cannot be null.");
            }
            return IsPointOnLineSegment(point, this);
        }

        public static bool IsPointOnLineSegment(IPoint2d<float> point, ILineSegment2d<float> line_segment)
        {
            if (point == null || line_segment == null)
            {
                throw new ArgumentNullException("Point and line segment cannot be null.");
            }

            if (line_segment.IsPointCCW(point) != 0)
            {
                return false;
            }
            // Point CCW == 0

            float min_x = Math.Min(line_segment.Start.X, line_segment.End.X);
            float max_x = Math.Max(line_segment.Start.X, line_segment.End.X);
            float min_y = Math.Min(line_segment.Start.Y, line_segment.End.Y);
            float max_y = Math.Max(line_segment.Start.Y, line_segment.End.Y);
            return min_x <= point.X && point.X <= max_x && min_y <= point.Y && point.Y <= max_y;
        }
    }
}