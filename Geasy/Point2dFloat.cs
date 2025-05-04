/*
    For game dev, 'float' is sufficient for most 2D point calculations.
*/

namespace Geasy {
    public class Point2dFloat : IPoint2d<float> {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2dFloat(float x, float y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"Point2d({X}, {Y})";
        }
    }
}