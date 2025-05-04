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

        public Vector2dFloat(Point2dFloat start, Point2dFloat end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and end points cannot be null.");
            }

            X = end.X - start.X;
            Y = end.Y - start.Y;
        }

        public static Vector2dFloat FromPoints(IPoint2d<float> start, IPoint2d<float> end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentNullException("Start and end points cannot be null.");
            }

            return new Vector2dFloat(end.X - start.X, end.Y - start.Y);
        }

        public override string ToString() => $"({X}, {Y})";
    }
}