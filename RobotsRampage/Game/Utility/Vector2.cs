namespace RobotsRampage.Game.Utility
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("X:{X} Y:{Y}")]
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2()
        {
        }

        protected bool Equals(Vector2 other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((Vector2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X.GetHashCode() * 397) ^ this.Y.GetHashCode();
            }
        }

        public static Vector2 operator -(Vector2 vector2a, Vector2 vector2b)
        {
            return new Vector2(vector2b.X - vector2a.X, vector2b.Y - vector2a.Y);
        }

        public void Max(double max)
        {
            double length = this.Length();
            if (length > max)
            {
                var ratio = max / length;
                this.Multiply(ratio);
            }
        }

        private void Multiply(double ratio)
        {
            this.X *= ratio;
            this.Y *= ratio;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2));
        }

        public void Add(Vector2 vectorToTarget)
        {
            this.X += vectorToTarget.X;
            this.Y += vectorToTarget.Y;
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