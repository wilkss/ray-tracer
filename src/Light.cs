namespace RayTracer
{
    class Light
    {
        public Vector Center { get; private set; }
        public Vector Color { get; private set; }

        public Light(Vector center, Vector color)
        {
            Center = center;
            Color = color;
        }
    }
}
