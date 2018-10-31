namespace RayTracer
{
    class Plane : Primitive
    {
        public Vector Normal { get; private set; }
        public double D { get; private set; }

        public Plane(Vector p0, Vector p1, Vector p2, Vector color, double specularity, double reflectivity) :
            base(color, specularity, reflectivity)
        {
            Normal = (p1 - p0).Cross(p2 - p0);
            D = -Normal.Dot(p0);
        }

        public override Intersection Intersects(Ray ray)
        {
            double denominator = Normal.Dot(ray.Direction);
            if (denominator == 0.0)
                return null;

            double t = -(Normal.Dot(ray.Origin) + D) / denominator;
            if (t < 0)
                return null;

            return new Intersection(this, t);
        }

        public override Vector GetNormalAtPoint(Vector point)
        {
            return Normal;
        }
    }
}
