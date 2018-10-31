namespace RayTracer
{
    class Material
    {
        public Vector Color { get; private set; }
        public double Specularity { get; private set; }
        public double Reflectivity { get; private set; }

        public Material(Vector color, double specularity, double reflectivity)
        {
            Color = color;
            Specularity = specularity;
            Reflectivity = reflectivity;
        }
    }
}
