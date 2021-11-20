using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    public class TexturePoint
    {
        private double u, v;

        public TexturePoint(double u, double v)
        {
            this.u = u;
            this.v = v;
        }

        public double U => u;

        public double V => v;
    }
}