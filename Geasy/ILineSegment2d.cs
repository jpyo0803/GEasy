/*
    Point interface for 2D points, data type is templated to allow for different numeric types.
*/

namespace Geasy
{
    public interface ILineSegment2d<T> where T : struct
    {
        IPoint2d<T> Start { get; set; }
        IPoint2d<T> End { get; set; }

        double Length();
        IVector2d<T> ToVector();

        int IsPointCCW(IPoint2d<T> point);
    }
}