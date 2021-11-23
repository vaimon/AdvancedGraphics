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
        private Camera camera;

        System.Drawing.Point toDumbPoint(Point p)
        {
            return new System.Drawing.Point((int) (Point.worldCenter.X + p.Xf * 100),
                (int) (Point.worldCenter.Y + p.Zf * 100));
        }

        void floatingHorizon(Func<double, double, double> f, double threshold = 5, int splitting = 20)
        {
            double step = threshold * 2.0 / splitting;

            double[] upHorizon = new double[splitting + 1];
            double[] downHorizon = new double[splitting + 1];

            for (int i = 0; i < splitting + 1; i++)
            {
                upHorizon[i] = double.MinValue;
                downHorizon[i] = double.MaxValue;
            }

            List<Point> surface = new List<Point>();
            for (double x = -threshold; x <= threshold; x += step)
            {
                for (double y = -threshold; y <= threshold; y += step)
                {
                    surface.Add(new Point(x,y,f(x,y)));
                }
            }

            
            var bitmap = new Bitmap(canvas.Width, canvas.Height);
            using (var fbitmap = new FastBitmap.FastBitmap(bitmap))
            {
                
            }
            
            canvas.Image = bitmap;
        }

        void redraw()
        {
            floatingHorizon(SelectedFunction);
        }
    }
}