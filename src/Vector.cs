using System;

namespace RayTracer
{
    class Vector
    {
        public static readonly Vector Right = new Vector(1, 0, 0);
        public static readonly Vector Up = new Vector(0, 1, 0);

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Vector operator *(Vector v, double s)
        {
            return new Vector(v.X * s, v.Y * s, v.Z * s);
        }

        public static Vector operator /(Vector v, double s)
        {
            return new Vector(v.X / s, v.Y / s, v.Z / s);
        }

        public Vector Normalize()
        {
            double len = Length();
            X = X / len;
            Y = Y / len;
            Z = Z / len;
            return this;
        }

        public double Dot(Vector v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector Cross(Vector v)
        {
            return new Vector(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }
    }
}
