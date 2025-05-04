/*
    For game dev, 'float' is sufficient for most 2D point calculations.
*/

using System;

namespace Geasy
{
    public class Point2dFloat : IPoint2d<float>, IEquatable<Point2dFloat>
    {

        public float X { get; set; }
        public float Y { get; set; }

        public Point2dFloat(float x, float y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(IPoint2d<float> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "The other point cannot be null.");
            }
            // cast float to double for distance calculation
            double dx = (double)X - (double)other.X;
            double dy = (double)Y - (double)other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point2dFloat other))
            { // means if obj is a type of Point2dFloat then cast it to other
                return false; // not the same type
            }

            return Equals(other); // call the other Equals method
        }

        public bool Equals(Point2dFloat other)
        {
            if (other is null)
            {
                return false; // null check
            }

            const float epsilon = 1e-6f; // tolerance for floating point comparison
            return Math.Abs(X - other.X) < epsilon && Math.Abs(Y - other.Y) < epsilon;
        }

        public override int GetHashCode()
        {
            unchecked
            { // unchecked to avoid overflow exceptions
                int hash = 17; // start with a non-zero constant
                hash = hash * 23 + X.GetHashCode(); // combine hash codes
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"Point2d({X}, {Y})";
        }

        public static bool operator ==(Point2dFloat a, Point2dFloat b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.Equals(b); // neither a nor b is null
        }

        public static bool operator !=(Point2dFloat a, Point2dFloat b)
        {
            return !(a == b); // use the equality operator to determine inequality
        }
    }
}