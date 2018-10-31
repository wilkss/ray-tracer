using System;
using System.Collections.Generic;

namespace RayTracer
{
    class Scene
    {
        private static readonly double Bias = 1e-4;
        private static readonly int MaxTraceDepth = 4;

        public Vector BackgroundColor { get; private set; }
        public Vector AmbientColor { get; private set; }
        public List<Light> Lights { get; private set; } = new List<Light>();
        public List<Primitive> Primitives { get; private set; } = new List<Primitive>();

        public Scene(Vector backgroundColor, Vector ambientColor)
        {
            BackgroundColor = backgroundColor;
            AmbientColor = ambientColor;
        }

        public Vector Trace(Ray ray, int depth)
        {
            Intersection nearestIntersection = FindNearestIntersection(ray);
            if (nearestIntersection == null || depth == MaxTraceDepth)
                return BackgroundColor;

            Vector color = new Vector(0.0, 0.0, 0.0);

            Vector intersectionPoint = ray.Origin + (ray.Direction * nearestIntersection.T);
            Vector normal = nearestIntersection.Primitive.GetNormalAtPoint(intersectionPoint);

            foreach (Light light in Lights)
            {
                Vector lightDirection = (light.Center - intersectionPoint).Normalize();

                double nDotL = Math.Max(normal.Dot(lightDirection), 0.0f);
                Vector diffuse = light.Color * nDotL;
                color += (AmbientColor + diffuse) * nearestIntersection.Primitive.Color;

                if (nearestIntersection.Primitive.Specularity > 0.0)
                {
                    Vector reflectDirection = lightDirection - (normal * (nDotL * 2.0));
                    double specular = Math.Pow(Math.Max(ray.Direction.Dot(reflectDirection), 0.0), 32);
                    color += light.Color * nearestIntersection.Primitive.Specularity * specular;
                }

                double lightDistance = (intersectionPoint - light.Center).Length();
                Ray shadowRay = new Ray(intersectionPoint + lightDirection * Bias, lightDirection);
                double shadow = 0.0;

                foreach (Primitive primitive in Primitives)
                {
                    Intersection intersection = primitive.Intersects(shadowRay);
                    if (intersection != null && intersection.T < lightDistance)
                        shadow = 0.5;
                }

                color *= 1.0 - shadow;

                if (nearestIntersection.Primitive.Reflectivity > 0.0)
                {
                    Vector reflectDirection = ray.Direction - (normal * (ray.Direction.Dot(normal) * 2.0));
                    Ray reflectRay = new Ray(intersectionPoint + reflectDirection * Bias, reflectDirection);
                    color += Trace(reflectRay, depth + 1) * nearestIntersection.Primitive.Reflectivity;
                }
            }

            color.X = Math.Min(Math.Max(color.X, 0.0f), 1.0f);
            color.Y = Math.Min(Math.Max(color.Y, 0.0f), 1.0f);
            color.Z = Math.Min(Math.Max(color.Z, 0.0f), 1.0f);
            return color;
        }

        private Intersection FindNearestIntersection(Ray ray)
        {
            Intersection nearest = null;
            double minDistance = double.MaxValue;

            foreach (Primitive primitive in Primitives)
            {
                Intersection intersection = primitive.Intersects(ray);
                if (intersection != null && intersection.T < minDistance)
                {
                    nearest = intersection;
                    minDistance = intersection.T;
                }
            }

            return nearest;
        }
    }
}
