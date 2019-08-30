using System;
using System.Drawing;

namespace MathHelper
{
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Vector(double inputX,double inputY)
        {
            X = inputX;
            Y = inputY;
        }
        public static Vector Zero = new Vector(0.0, 0.0);
        public static Vector UnitX = new Vector(1.0, 0.0);
        public static Vector UnitY = new Vector(0.0, 1.0);
        public PointF ToPoint()
        {
            return new PointF((float)X, (float)Y);
        }
        public RectangleF ToCircleBoundingBox(double radius)
        {
            float diameter = (float)(radius*2);
            return new RectangleF((float)(X - radius), (float)(Y - radius), diameter, diameter);
        }
        public static RectangleF ToRectangleF(Vector a, Vector b)
        {
            double x1 = Math.Min(a.X, b.X);
            double y1 = Math.Min(a.Y, b.Y);
            double width = Math.Max(a.X, b.X) - x1;
            double height = Math.Max(a.Y, b.Y) - y1;
            return new RectangleF((float)x1, (float)y1, (float)width, (float)height);
        }

        #region operations
        public static Vector operator +(Vector a) => a;
        public static Vector operator -(Vector a) => new Vector(-a.X,-a.Y);
        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);
        public static Vector operator *(Vector a, double b) => new Vector(a.X * b, a.Y * b);
        public static Vector operator *(double b, Vector a) => new Vector(a.X * b, a.Y * b);
        public static Vector operator /(Vector a, double b) => new Vector(a.X / b, a.Y / b);
        public static Vector operator /(double b, Vector a) => new Vector(a.X / b, a.Y / b);
        public static double operator ^(Vector a, Vector b) => a.X * b.X + a.Y * b.Y;
        #endregion

        #region helper functions
        public Vector MapToScreen(double scale,Vector origin) => this * scale + origin;
        public Vector MapFromScreen(double scale, Vector origin) => (this - origin) / scale;
        public double Length() => Math.Sqrt(X * X + Y * Y);
        public static double PointDistance(Vector query, Vector point) => (query - point).Length();
        public static double SegmentDistance(Vector query, Vector start, Vector end)
        {
            // from https://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment by Joshua
            double x = query.X, y = query.Y;
            double x1 = start.X, y1 = start.Y;
            double x2 = end.X, y2 = end.Y;
            double A = x - x1;
            double B = y - y1;
            double C = x2 - x1;
            double D = y2 - y1;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = -1;
            if (len_sq != 0) //in case of 0 length line
                param = dot / len_sq;

            double xx, yy;

            if (param < 0)
            {
                xx = x1;
                yy = y1;
            }
            else if (param > 1)
            {
                xx = x2;
                yy = y2;
            }
            else
            {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            double dx = x - xx;
            double dy = y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double GetAngel(Vector a, Vector b)
        {
            double lengthProduct = a.Length() * b.Length();
            if (lengthProduct < 1e-10)
                return 0.0f;
            double cosValue = (a ^ b) / lengthProduct;
            return Math.Acos(cosValue);
        }

        public Vector Rotate(double angle)
        {
            double cosValue = Math.Cos(angle), sinValue = Math.Sin(angle);
            return new Vector(cosValue * X - sinValue * Y, sinValue * X + cosValue * Y);
        }
        #endregion
    }
}
