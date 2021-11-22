using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsHelper
{
    using FastBitmap;
    //для реализации освещения по модели Ламберта 
    class Lighting
    {
        //Вычислить цвет в каждой вершине по модели Ламберта (рассеянную часть).
        //Закрасить грань, интерполируя цвет между цветами вершин(билинейная интерполяция).
        //Добавить возможность применения аффинных преобразований к объекту.
        public static  double GetLightness(Vertex v, AdvancedGraphics.CoolStuff.LightSource light)
        {
            var normv = v.normVector;
            var raytovertex = new Vector(v.Xf - light.Position.Xf, v.Yf - light.Position.Yf, v.Zf - light.Position.Zf);
            //
            //cos α = a·b/
            //|a |·| b |
            double cos = Vector.GetCos(normv, raytovertex);
            return cos;
        }
        //Имеется также простая зависимость между силой света, излучаемого плоской рассеивающей площадкой {\displaystyle dS}dS в каком-либо направлении, от угла {\displaystyle \alpha }\alpha  между этим направлением и перпендикуляром к {\displaystyle dS}dS:
        //Ia=I0*cosa

        public static double GetIntense(double lightness, Color c)
        {
            return lightness * c.A;
        }
        public static void CalculateLambert(Face f, Color c, AdvancedGraphics.CoolStuff.LightSource light)
        {
            //посчитать яркость в каждой вершине многоугольника
            foreach (var vert in f.Vertices)
            {
                double lamb = GetLightness(vert,light);
                double intense = GetIntense(lamb, c);
                vert.lightness = intense;
            }
        }
        public static void CalculateLambertFigure(Shape s, AdvancedGraphics.CoolStuff.LightSource light)
        {
            //считаем для каждой грани
            foreach (var face in s.Faces)
            {
                //для каждой вершины грани
                CalculateLambert(face, s.GetColor, light);
            }
        }
        public static Bitmap z_buf(int width, int height, Shape shape, AdvancedGraphics.CoolStuff.LightSource light, Color color,Camera camera)
        {
            CalculateLambertFigure(shape, light);
            Bitmap canvas = new Bitmap(width, height);
            //new FastBitmap(bitmap);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    canvas.SetPixel(i, j, Color.White); //new System.Drawing.Point(i, j)
            //z-буфер
            double[,] zbuffer = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuffer[i, j] = double.MaxValue; //Изначально, буфер
            // инициализируется значением z = zmax
            List<List<List<Point>>> rasterscene = new List<List<List<Point>>>();
                rasterscene.Add(GraphicsHelper.Z_buffer.RasterFigure(shape, camera)); //растеризовали все фигуры
            int withmiddle = width / 2;
            int heightmiddle = height / 2;
            int index = 0;
            for (int i = 0; i < rasterscene.Count(); i++)
            {
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Point> current = rasterscene[i][j]; //это типа грань но уже растеризованная
                    foreach (Point p in current)
                    {
                        int x = (int)(p.X); //

                        int y = (int)(p.Y); // + heightmiddle 
                        ;
                        if (x < width && y < height && y > 0 && x > 0)
                        {
                            if (p.Zf < zbuffer[x, y])
                            {
                                zbuffer[x, y] = p.Zf;
                                canvas.SetPixel(x, y, Color.FromArgb((int)(p.lightness*color.R), (int)(p.lightness * color.G), (int)(p.lightness * color.B))); //canvas.Height - 
                            }
                        }
                    }

                    index++;
                }
            }

            return canvas;
        }
    }

}