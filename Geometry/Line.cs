using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Отрезок в пространстве
    /// </summary>
    public class Line
    {
        public Point start, end;

        public Line(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public Point Start
        {
            get => start;
            set => start = value;
        }

        public Point End
        {
            get => end;
            set => end = value;
        }

        public Point getVectorCoordinates()
        {
            return new Point(end.Xf - start.Xf, end.Yf - start.Yf, end.Zf - start.Zf);
        }

        public Point getReverseVectorCoordinates()
        {
            return new Point(start.Xf - end.Xf, start.Yf - end.Yf, start.Zf - end.Zf);
        }
    }
}