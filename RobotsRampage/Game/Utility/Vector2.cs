namespace RobotsRampage.Game.Utility
{
    using System;

    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 operator -(Vector2 vector2a, Vector2 vector2b)
        {
            return new Vector2(vector2b.X - vector2a.X, vector2b.Y - vector2a.Y);
        }

        public void Max(double max)
        {
            var ratio = max / Length();
            Multiply(ratio);
        }

        private void Multiply(double ratio)
        {
            X *= ratio;
            Y *= ratio;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }

        public void Add(Vector2 vectorToTarget)
        {
            X += vectorToTarget.X;
            Y += vectorToTarget.Y;
        }

        public static bool operator ==(Vector2 vector2a, Vector2 vector2b)
        {
            // TODO:check loss of precision
            return vector2a.X == vector2b.X && vector2a.Y == vector2b.Y;
        }

        public static bool operator !=(Vector2 vector2a, Vector2 vector2b)
        {
            return !(vector2a == vector2b);
        }
    }
}