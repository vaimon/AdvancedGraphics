using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using GraphicsHelper;
using Point = GraphicsHelper.Point;

namespace AdvancedGraphics
{
    public partial class FormPlotting
    {
        private const int scaleFactor = 100;
        private const double threshold = 5;
        private const double splitting = 50;
        private double yawAngle;
        private double pitchAngle;

        Point getScaledPoint(Point p)
        {
            p = AffineTransformations.rotate(p, AxisType.Y, yawAngle);
            p = AffineTransformations.rotate(p, AxisType.X, pitchAngle);
            return new Point(Point.worldCenter.X + scaleFactor * p.Xf,
                Point.worldCenter.Y - scaleFactor * p.Yf, p.Zf * scaleFactor);
        }
        
        public void changeViewAngles(double shiftX = 0, double shiftY = 0)
        {
            pitchAngle = Math.Clamp(pitchAngle + shiftY, -89.0, 89.0);
            yawAngle = (yawAngle + shiftX) % 360;
        }


        void floatingHorizon(Func<double, double, double> f)
        {
            double step = threshold * 2.0 / splitting;

            double[] upHorizon = new double[canvas.Width];
            double[] downHorizon = new double[canvas.Width];

            for (int i = 0; i < canvas.Width; i++)
            {
                upHorizon[i] = double.MinValue;
                downHorizon[i] = double.MaxValue;
            }

            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            var fbitmap = new FastBitmap.FastBitmap(bitmap);

            for (double z = -threshold; z <= threshold; z += step)
            {
                Point last = getScaledPoint(new Point(-threshold, f(-threshold, z),z));
                for (double x = -threshold; x <= threshold; x += step)
                {
                    Point curr = getScaledPoint(new Point(x, f(x, z),z));
                    AdditionalAlgorithms.drawVuLine(ref fbitmap, last.toSimple2D(), curr.toSimple2D(), Color.Navy);
                    last = curr;
                }
            }
            
            fbitmap.Dispose();
            canvas.Image = bitmap;
        }

        void redraw()
        {
            floatingHorizon(SelectedFunction);
        }
    }
}