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
        private double yawAngle;
        private double pitchAngle;

        static Point getScaledPoint(double x, double y, double z)
        {
            return new Point(Point.worldCenter.X + scaleFactor * x,
                Point.worldCenter.Y - scaleFactor * y, z * scaleFactor);
        }
        
        public void changeViewAngles(double shiftX = 0, double shiftY = 0)
        {
            pitchAngle = Math.Clamp(pitchAngle + shiftY, -89.0, 89.0);
            yawAngle = (yawAngle + shiftX) % 360;
        }


        void floatingHorizon(Func<double, double, double> f)
        {
            double step = threshold * 2.0 / 100;

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
                Point last = getScaledPoint(-threshold, f(-threshold, z),z);
                for (double x = -threshold; x <= threshold; x += step)
                {
                    Point curr = getScaledPoint(x, f(x, z),z);
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