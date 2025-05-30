/*
    Vector2dFloat implementation
*/

using System;

namespace Geasy
{
    public struct Vector2dFloat : IVector2d<float>
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2dFloat(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2dFloat(IPoint2d<float> start, IPoint2d<float> end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and end points cannot be null.");
            }

            X = end.X - start.X;
            Y = end.Y - start.Y;
        }

        // Move it to the interface in the future when C#11 is used
        public static Vector2dFloat FromPoints(IPoint2d<float> start, IPoint2d<float> end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and end points cannot be null.");
            }

            return new Vector2dFloat(end.X - start.X, end.Y - start.Y);
        }

        // Move it to the interface in the future when C#11 is used
        public static Vector2dFloat operator +(Vector2dFloat a, Vector2dFloat b)
        {
            return new Vector2dFloat(a.X + b.X, a.Y + b.Y);
        }

        // Move it to the interface in the future when C#11 is used
        public static Vector2dFloat operator -(Vector2dFloat a, Vector2dFloat b)
        {
            return new Vector2dFloat(a.X - b.X, a.Y - b.Y);
        }

        // Move it to the interface in the future when C#11 is used
        public static Vector2dFloat operator *(Vector2dFloat v, double scalar)
        {
            return new Vector2dFloat((float)(v.X * scalar), (float)(v.Y * scalar));
        }

        // Move it to the interface in the future when C#11 is used
        public static Vector2dFloat operator /(Vector2dFloat v, double scalar)
        {
            // TODO(jpyo0803): if scalar is very close to zero, should it stop further calculation?
            // or should it just return a zero vector? 
            // also is 1e-9 a good value for epsilon?
            const double epsilon = 1e-9; // use a small epsilon to avoid division by zero
            if (Math.Abs(scalar) < epsilon)
            {
                throw new ArgumentException("Scalar cannot be zero.", nameof(scalar));
            }

            return new Vector2dFloat((float)(v.X / scalar), (float)(v.Y / scalar));
        }

        // Move it to the interface in the future when C#11 is used
        public static double Cross(Vector2dFloat a, Vector2dFloat b)
        {
            double ax = a.X, ay = a.Y;
            double bx = b.X, by = b.Y;

            return ax * by - ay * bx;
        }

        // Move it to the interface in the future when C#11 is used
        public static double Dot(Vector2dFloat a, Vector2dFloat b)
        {
            double ax = a.X, ay = a.Y;
            double bx = b.X, by = b.Y;

            return ax * bx + ay * by;
        }

        // Specific to this concrete class, not part of the interface
        public override string ToString() => $"({X}, {Y})";
    }
}