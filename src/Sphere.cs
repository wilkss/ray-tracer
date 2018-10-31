using System;

namespace RayTracer
{
    class Sphere : Primitive
    {
        public Vector Center { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Vector center, double radius, Vector color, double specularity, double reflectivity)
            : base(color, specularity, reflectivity)
        {
            Center = center;
            Radius = radius;
        }

        public override Intersection Intersects(Ray ray)
        {
            Vector v = Center - ray.Origin;
            double b = v.Dot(ray.Direction);
            double disc = b * b - v.Dot(v) + Radius * Radius;
            if (disc < 0)
                return null;

            double discSq = Math.Sqrt(disc);
            double tMin = b - discSq;
            double tMax = b + discSq;
            if (tMin < 0 && tMax < 0)
                return null;
            
            return new Intersection(this, tMin < 0 && tMax > 0 ? tMax : tMin);
        }

        public override Vector GetNormalAtPoint(Vector point)
        {
            return (point - Center) / Radius;
        }
    }
}
