/*
    Point interface for 2D points, data type is templated to allow for different numeric types.
*/

namespace Geasy {
    public interface Point2d<T> where T : struct {
        T X { get; set; }
        T Y { get; set; }
    }
}