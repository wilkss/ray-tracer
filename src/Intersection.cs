namespace RayTracer
{
    class Intersection
    {
        public Primitive Primitive { get; private set; }
        public double T { get; private set; }

        public Intersection(Primitive primitive, double t)
        {
            Primitive = primitive;
            T = t;
        }
    }
}
