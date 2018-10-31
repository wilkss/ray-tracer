namespace RayTracer
{
    class Ray
    {
        public Vector Origin { get; private set; }
        public Vector Direction { get; private set; }

        public Ray(Vector origin, Vector direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }
}
