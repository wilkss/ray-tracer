using System;

namespace RayTracer
{
    class Camera
    {
        public Vector Point { get; private set; }
        public Vector Direction { get; private set; }
        public double HalfWidth { get; private set; }
        public double HalfHeight { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Camera(Vector point, Vector direction, double fov, double aspectRatio)
        {
            Point = point;
            Direction = direction;
            HalfWidth = Math.Tan(fov / 2.0);
            HalfHeight = aspectRatio * HalfWidth;
            Width = HalfWidth * 2;
            Height = HalfHeight * 2;
        }

        public Ray CalculateRay(int x, int y, int imageWidth, int imageHeight)
        {
            double pixelWidth = Width / (imageWidth - 1);
            double pixelHeight = Height / (imageHeight - 1);

            Vector xs = Vector.Right * (x * pixelWidth - HalfWidth);
            Vector ys = Vector.Up * (y * pixelHeight - HalfHeight);

            return new Ray(Point, (Direction + xs + ys).Normalize());
        }
    }
}
