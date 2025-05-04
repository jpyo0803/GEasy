
namespace Geasy {
    public class Point2dImpl<T> : Point2d<T> where T : struct {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2dImpl(T x, T y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"Point2d({X}, {Y})";
        }
    }
}