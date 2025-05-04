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
    }
}