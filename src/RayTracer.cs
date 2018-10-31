using System;
using System.Drawing;

namespace RayTracer
{
    class RayTracer
    {
        static void Main(string[] args)
        {
            int w = 640;
            int h = 480;
            Bitmap img = new Bitmap(w, h);
            Camera camera = new Camera(new Vector(0.0, 0.0, 8.0), new Vector(0.0, 0.0, -1.0).Normalize(), 65.0 * Math.PI / 180.0, h / (double)w);
            Scene scene = new Scene(new Vector(0.0, 0.0, 0.0), new Vector(0.1, 0.1, 0.1));
            
            scene.Primitives.Add(new Sphere(new Vector(-3.0, 0.0, 0.0), 1.0, new Vector(1.0, 0.0, 0.0), 1.0, 0.0));
            scene.Primitives.Add(new Sphere(new Vector(0.0, 0.0, 0.0), 1.0, new Vector(0.0, 1.0, 0.0), 1.0, 0.0));
            scene.Primitives.Add(new Sphere(new Vector(3.0, 0.0, 0.0), 1.0, new Vector(0.0, 0.0, 1.0), 1.0, 0.0));
            scene.Primitives.Add(new Sphere(new Vector(-1.5, 0.0, 1.5), 1.0, new Vector(1.0, 1.0, 0.0), 1.0, 0.0));
            scene.Primitives.Add(new Sphere(new Vector(1.5, 0.0, 1.5), 1.0, new Vector(0.0, 1.0, 1.0), 1.0, 0.0));
            scene.Primitives.Add(new Plane(new Vector(1.0, 1.0, 0.0), new Vector(0.0, 1.0, 0.0), new Vector(0.0, 1.0, 1.0), new Vector(1.0, 1.0, 1.0), 0.0, 0.05));
            
            scene.Lights.Add(new Light(new Vector(-5, -10, 10), new Vector(1.0, 1.0, 1.0)));

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Ray ray = camera.CalculateRay(x, y, w, h);
                    Vector color = scene.Trace(ray, 0);
                    img.SetPixel(x, y, Color.FromArgb(255, (int)(color.X * 255), (int)(color.Y * 255), (int)(color.Z * 255)));
                }
            }

            img.Save("output.png");
        }
    }
}
