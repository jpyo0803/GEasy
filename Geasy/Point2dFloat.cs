/*
    For game dev, 'float' is sufficient for most 2D point calculations.
*/

using System;

namespace Geasy {
    public class Point2dFloat : IPoint2d<float> {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2dFloat(float x, float y) {
            X = x;
            Y = y;
        }

        public double DistanceTo(IPoint2d<float> other) {
            if (other == null) {
                throw new ArgumentNullException(nameof(other), "The other point cannot be null.");
            }
            // cast float to double for distance calculation
            double dx = (double)X - (double)other.X;
            double dy = (double)Y - (double)other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString() {
            return $"Point2d({X}, {Y})";
        }
    }
}