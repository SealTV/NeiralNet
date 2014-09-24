using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestApplication
{
    public static class GraphicsDrawer
    {
        public static Graphics Graphics { get; set; }
        public static float CenterX { get; set; }
        public static float CenterY { get; set; }
        public static float Radius { get; set; }

        private static List<PointF> inputPoints = new List<PointF>();

        public static void ReDraw()
        {
            DrawEllipses();
            for (int i = 0; i < InputPoints.Count; i++)
            {
                Graphics.DrawLine(new Pen(Color.Crimson), CenterX, CenterY, (InputPoints[i].X * Radius) + CenterX,
                    (InputPoints[i].Y * -Radius) + CenterY);
                Graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                    new RectangleF((InputPoints[i].X * Radius) + CenterX, (InputPoints[i].Y * -Radius) + CenterY, 5, 5));
            }
        }
        public static List<PointF> InputPoints
        {
            get { return inputPoints; }
            set { inputPoints = value; }
        }

        public static void DrawEllipses()
        {
            Graphics.Clear(Color.WhiteSmoke);

            Graphics.DrawLine(new Pen(Color.Black), 0, 0, 2*CenterX, 2*CenterY);
            Graphics.DrawLine(new Pen(Color.Black), 0, CenterY, 2*CenterX, CenterY);
            Graphics.DrawLine(new Pen(Color.Black), CenterX, 0, CenterX, 2*CenterY);
            Graphics.DrawLine(new Pen(Color.Black), 2*CenterX, 0, 0, 2*CenterY);

            Graphics.DrawEllipse(new Pen(Color.Green), CenterX - Radius*0.2f, CenterY - Radius*0.2f,
                Radius*0.4f, Radius*0.4f);

            Graphics.DrawEllipse(new Pen(Color.Chocolate), CenterX - Radius*0.3f, CenterY - Radius*0.3f,
                Radius*0.6f, Radius*0.6f);

            Graphics.DrawEllipse(new Pen(Color.BlueViolet), CenterX - Radius*0.4f, CenterY - Radius*0.4f,
                Radius*0.8f, Radius*0.8f);

            Graphics.DrawEllipse(new Pen(Color.Chocolate), CenterX - Radius*0.5f, CenterY - Radius*0.5f,
                Radius*1f, Radius*1f);

            Graphics.DrawEllipse(new Pen(Color.DarkBlue), CenterX - Radius*0.6f, CenterY - Radius*0.6f,
                Radius*1.2f, Radius*1.2f);

            Graphics.DrawEllipse(new Pen(Color.Fuchsia), CenterX - Radius*0.7f, CenterY - Radius*0.7f,
                Radius*1.4f, Radius*1.4f);

            Graphics.DrawEllipse(new Pen(Color.Crimson), CenterX - Radius*0.8f, CenterY - Radius*0.8f,
                Radius*1.6f, Radius*1.6f);

            Graphics.DrawEllipse(new Pen(Color.Crimson), CenterX - Radius*0.9f, CenterY - Radius*0.9f,
                Radius*1.8f, Radius*1.8f);

            Graphics.DrawEllipse(new Pen(Color.Green), 0, 0, CenterX*2, CenterY*2);
        }

        public static void DrawNewElement(Point point)
        {
            PointF pointF = new PointF((point.X - CenterX + 0.0f)/Radius, (CenterY - point.Y + 0.0f)/Radius);

            bool isnewPoint = true;
            for (int i = 0; i < InputPoints.Count; i++)
            {
                if (GetSimpleAngle(InputPoints[i]) == GetSimpleAngle(pointF))
                {
                    InputPoints[i] = pointF;
                    isnewPoint = false;
                }
                Graphics.DrawLine(new Pen(Color.Crimson), CenterX, CenterY, (InputPoints[i].X*Radius) + CenterX,
                    (InputPoints[i].Y*-Radius) + CenterY);
                Graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                    new RectangleF((InputPoints[i].X*Radius) + CenterX, (InputPoints[i].Y*-Radius) + CenterY, 5, 5));
            }
            if (!isnewPoint) return;
            InputPoints.Add(pointF);
            Graphics.DrawLine(new Pen(Color.Crimson), CenterX, CenterY, (pointF.X*Radius) + CenterX,
                (pointF.Y*-Radius) + CenterY);
            Graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                new RectangleF((pointF.X*Radius) + CenterX, (pointF.Y*-Radius) + CenterY, 5, 5));
        }

        public static void RemoveElement(Point point)
        {
            PointF pointF = new PointF((point.X - CenterX + 0.0f) / Radius, (CenterY - point.Y + 0.0f) / Radius);

            PointF turgetToRemovePoint = new PointF();
            foreach (PointF inputPoint in InputPoints.Where(inputPoint => GetSimpleAngle(inputPoint) == GetSimpleAngle(pointF)))
            {
                turgetToRemovePoint = inputPoint;
                break;
            }

            InputPoints.Remove(turgetToRemovePoint);
            foreach (PointF t in InputPoints)
            {
                Graphics.DrawLine(new Pen(Color.Crimson), CenterX, CenterY, (t.X * Radius) + CenterX,
                    (t.Y * -Radius) + CenterY);
                Graphics.FillEllipse(new SolidBrush(Color.DarkRed),
                    new RectangleF((t.X * Radius) + CenterX, (t.Y * -Radius) + CenterY, 5, 5));
            }
        }

        public static int GetSimpleAngle(PointF inputPoint)
        {
            double angle = Math.Atan2(inputPoint.Y, inputPoint.X);
            if (angle < 0) angle += (Math.PI*2);
            return (int) (angle/Math.PI*4);
        }
    }
}