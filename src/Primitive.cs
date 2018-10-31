namespace RayTracer
{
    abstract class Primitive
    {
        public Vector Color { get; private set; }
        public double Specularity { get; private set; }
        public double Reflectivity { get; private set; }

        public Primitive(Vector color, double specularity, double reflectivity)
        {
            Color = color;
            Specularity = specularity;
            Reflectivity = reflectivity;
        }

        public abstract Intersection Intersects(Ray ray);
        public abstract Vector GetNormalAtPoint(Vector point);
    }
}
