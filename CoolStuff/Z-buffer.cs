﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;

namespace GraphicsHelper
{
    using FastBitmap;

    class Z_buffer
    {

        /// <summary>
        /// Интерполяция точек
        /// </summary>
        /// <param name="x1">Стартовая точка</param>
        /// <param name="y1">Стартовая точка</param>
        /// <param name="x2">Конечная точка</param>
        /// <param name="y2">Конечная точка</param>
        public static List<int> interpolate(int x1, int y1, int x2, int y2)
        {
            List<int> res = new List<int>();
            if (x1 == x2)
            {
                res.Add(y2);
            }

            double step = (y2 - y1) * 1.0f / (x2 - x1); //с таким шагом будем получать новые точки
            double y = y1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add((int) y);
                y += step;
            }

            return res;
        }

        //растеризация треугольника
        /// <summary>
        /// Растеризация треугольника
        /// </summary>
        /// <param name="points">Список вершин треугольника</param>
        public static List<Point> Raster(List<Point> points, Dictionary<int, TexturePoint> texels, List<Point> triangle)
        {
            List<Point> res = new List<Point>();
            //отсортировать точки по неубыванию ординаты
            points.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            triangle.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            Vector texture_p1 = new Vector(triangle[1]), texture_p2 = new Vector(triangle[0]), texture_p4 = new Vector(triangle[2]);
            Vector a = texture_p1;
            Vector e1 = (texture_p2 - texture_p1).normalize();
            Vector e2 = (texture_p4 - texture_p1).normalize();
            Vector n = e1 * e2;
            double X = (a.Xf + e1.Xf + e2.Xf) / (a.Zf + e1.Zf + e2.Zf);
            double Y = (a.Yf + e1.Yf + e2.Yf) / (a.Zf + e1.Zf + e2.Zf);

            Vector m = (e2 * a).normalize();
            Vector l = (a * e1).normalize();

            Matrix m1 = new Matrix(3, 3).fill(m.Xf, m.Yf, m.Zf, l.Xf, l.Yf, l.Zf, n.Xf, n.Yf, n.Zf);
            Matrix m2 = new Matrix(3, 1).fill(X, Y, 1);

            Matrix matr = m1 * m2;

            texels[texels.Count()] = new TexturePoint(matr[0, 0], matr[1, 0]);

            // "рабочие точки"
            // изначально они находятся в верхней точке
            var wpoints = points.Select((p) => (x: (int) p.X, y: (int) p.Y, z: (int) p.Z)).ToList();
            var xy01 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[1].y, wpoints[1].x);
            var xy12 = interpolate(wpoints[1].y, wpoints[1].x, wpoints[2].y, wpoints[2].x);
            var xy02 = interpolate(wpoints[0].y, wpoints[0].x, wpoints[2].y, wpoints[2].x);
            var yz01 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[1].y, wpoints[1].z);
            var yz12 = interpolate(wpoints[1].y, wpoints[1].z, wpoints[2].y, wpoints[2].z);
            var yz02 = interpolate(wpoints[0].y, wpoints[0].z, wpoints[2].y, wpoints[2].z);
            xy01.RemoveAt(xy01.Count() - 1); //убрать точку, чтобы не было повтора
            var xy = xy01.Concat(xy12).ToList();
            yz01.RemoveAt(yz01.Count() - 1);
            var yz = yz01.Concat(yz12).ToList();
            //когда растеризуем, треугольник делим надвое
            //ищем координаты, чтобы разделить треугольник на 2
            int center = xy.Count() / 2;
            List<int> lx, rx, lz, rz; //для приращений
            if (xy02[center] < xy[center])
            {
                lx = xy02;
                lz = yz02;
                rx = xy;
                rz = yz;
            }
            else
            {
                lx = xy;
                lz = yz;
                rx = xy02;
                rz = yz02;
            }

            int y0 = wpoints[0].y;
            int y2 = wpoints[2].y;
            for (int i = 0; i <= y2 - y0; i++)
            {
                int leftx = lx[i];
                int rightx = rx[i];
                List<int> zcurr = interpolate(leftx, lz[i], rightx, rz[i]);
                for (int j = leftx; j < rightx; j++)
                {
                    res.Add(new Point(j, y0 + i, zcurr[j - leftx]));
                }
            }

            return res;
        }

        //разбиение на треугольники
        /// <summary>
        /// Разбиение полигона на треугольники
        /// </summary>
        /// <param name="points">Список вершин треугольника</param>
        public static List<List<Point>> Triangulate(List<Point> points)
        {
            //если всего 3 точки, то это уже трекгольник
            List<List<Point>> res = new List<List<Point>>();
            if (points.Count == 3)
            {
                res = new List<List<Point>> {points};
            }

            for (int i = 2; i < points.Count(); i++)
            {
                res.Add(new List<Point> {points[0], points[i - 1], points[i]}); //points[0]
            }

            return res;
        }

        //растеризовать фигуру
        /// <summary>
        /// Растеризация фигуры
        /// </summary>
        /// <param name="figure">Фигура</param>
        /// <param name="camera">Камера</param>
        public static List<List<Point>> RasterFigure(Shape figure, Camera camera, Dictionary<int, TexturePoint> texels = null)
        {
            int faceIndex = 0;
            List<List<Point>> res = new List<List<Point>>();
            foreach (var polygon in figure.Faces) //каждая грань-это многоугольник, который надо растеризовать
            {
                List<Point> currentface = new List<Point>();
                List<Point> points = new List<Point>();
                //добавим все вершины
                for (int i = 0; i < polygon.Vertices.Count(); i++)
                {
                    points.Add(polygon.Vertices[i]);
                }

                List<List<Point>> triangles = Triangulate(points); //разбили все грани на треугольники
                foreach (var triangle in triangles)
                {
                    currentface.AddRange(Raster(ProjectionToPlane(triangle, camera), texels, triangle)); //projection(triangle)
                    //currentface.AddRange(Raster(triangle));
                }

                faceIndex++;
                texels[faceIndex] = null;

                res.Add(currentface);
            }

            return res;
        }

        /// <summary>
        /// Проецирование точек на экран с учетом камеры и вида проекции
        /// </summary>
        /// <param name="points">Список точек</param>
        /// <param name="camera">Камера</param>
        public static List<Point> ProjectionToPlane(List<Point> points, Camera camera) //Camera camera,ProjectionType type 
        {
            List<Point> res = new List<Point>();
            // float c = 1000;
            //Matrix matrix = new Matrix(4, 4).fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, -1 / c, 0, 0, 0, 1);//перспективная чисто для начала
            foreach (var p in points) //потом заменить to2D(camera)
            {
                var current = p.to2D(camera);
                if (current.Item1 != null)
                {
                    // Point newpoint = new Point(current.Item1.Value.X, current.Item1.Value.Y,current.Item2);
                    //var current = transformPoint(p, matrix);
                    var tocamv = camera.toCameraView(p);
                    Point newpoint = new Point(current.Item1.Value.X, current.Item1.Value.Y, tocamv.Zf);
                    res.Add(newpoint);
                }
            }

            return res;
        }

        /// <summary>
        /// Перевод координат точки согласно матрице
        /// </summary>
        /// <param name="p">Точка</param>
        /// <param name="matrix">Матрица перевода</param>
        public static Point transformPoint(Point p, Matrix matrix)
        {
            var matrfrompoint = new Matrix(4, 1).fill(p.Xf, p.Yf, p.Zf, 1);

            var matrPoint = matrix * matrfrompoint; //применение преобразования к точке
            //Point newPoint = new Point(matrPoint[0, 0] / matrPoint[3, 0], matrPoint[1, 0] / matrPoint[3, 0], matrPoint[2, 0] / matrPoint[3, 0]);
            Point newPoint = new Point(matrPoint[0, 0], matrPoint[1, 0], matrPoint[2, 0]);
            return newPoint;
        }

        /// <summary>
        /// Алгоритм z-буфера
        /// </summary>
        /// <param name="width">Ширина канваса</param>
        /// <param name="height">Высота канваса</param>
        /// <param name="scene">Множество фигур на сцене</param>
        /// <param name="camera">Камера</param>
        /// <param name="colors">Список цветов</param>
        public static Bitmap z_buf(int width, int height, List<Shape> scene, Camera camera, List<Color> colors)
        {
            //Bitmap bitmap = new Bitmap(width, height);
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
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i], camera)); //растеризовали все фигуры
            }

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
                        int x = (int) (p.X); //

                        int y = (int) (p.Y); // + heightmiddle 
                        ;
                        if (x < width && y < height && y > 0 && x > 0)
                        {
                            if (p.Zf < zbuffer[x, y])
                            {
                                zbuffer[x, y] = p.Zf;
                                canvas.SetPixel(x, y, colors[index % colors.Count()]); //canvas.Height - 
                            }
                        }
                    }

                    index++;
                }
            }

            return canvas;
        }

        /// <summary>
        /// Алгоритм z-буфера для текстурирования
        /// </summary>
        /// <param name="width">Ширина канваса</param>
        /// <param name="height">Высота канваса</param>
        /// <param name="scene">Множество фигур на сцене</param>
        /// <param name="camera">Камера</param>
        /// <param name="colors">Список цветов</param>
        public static Bitmap z_buf_texturing(int width, int height, List<Shape> scene, Camera camera, string textureFile)
        {

            Image newImage = Image.FromFile(textureFile);
            Bitmap textureBitmap = newImage as Bitmap;
            //Bitmap bitmap = new Bitmap(width, height);
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
            Dictionary<int, TexturePoint> texels = new Dictionary<int, TexturePoint>();
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i], camera, texels)); //растеризовали все фигуры
            }

            int withmiddle = width / 2;
            int heightmiddle = height / 2;
            int index = 0;
            int widthTexture = textureBitmap.Width, heightTexture = textureBitmap.Height;
            for (int i = 0; i < rasterscene.Count(); i++)
            {
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Point> current = rasterscene[i][j]; //это типа грань но уже растеризованная
                    int ii = 0, jj = 0;
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

                                if (texels[index] == null)
                                    index--;

                                int tempii = ii + (int)texels[index].U >= widthTexture ? ii : ii + (int)texels[index].U;

                                int tempjj = jj + (int)texels[index].V >= heightTexture ? jj : jj + (int)texels[index].V;

                                Color c = textureBitmap.GetPixel(Math.Abs(tempii), Math.Abs(tempjj));
                                if (ii + 1 < heightTexture)
                                    ii++;
                                if (jj + 1 < widthTexture)
                                    jj++;

                                canvas.SetPixel(x, y, c); //canvas.Height - 
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