using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Класс для получения фигур различного типа
    /// </summary>
    class ShapeFactory
    {
        /// <summary>
        /// Получает фигуру фиксированного размера (в среднем до 200 пикселей по размеру)
        /// </summary>
        /// <param name="type">Тип фигуры</param>
        /// <returns></returns>
        public static Shape getShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.TETRAHEDRON: return getTetrahedron();
                case ShapeType.OCTAHEDRON: return getOctahedron();
                case ShapeType.HEXAHEDRON: return getHexahedron();
                case ShapeType.ICOSAHEDRON: return getIcosahedron();
                case ShapeType.DODECAHEDRON: return getDodecahedron();


                default: throw new Exception("C# очень умный (нет)");
            }
        }

        /// <summary>
        /// Получение тетраэдра
        /// </summary>
        /// <returns></returns>
        public static Tetrahedron getTetrahedron()
        {
            Tetrahedron res = new Tetrahedron();
            Point a = new Point(0, 0, 0);
            Point c = new Point(200, 0, 200);
            Point f = new Point(200, 200, 0);
            Point h = new Point(0, 200, 200);
            res.addFace(new Face().addEdge(new Line(a, c)).addEdge(new Line(c, f)).addEdge(new Line(f, a))); // ok
            res.addFace(new Face().addEdge(new Line(f, c)).addEdge(new Line(c, h)).addEdge(new Line(h, f))); // ok
            res.addFace(new Face().addEdge(new Line(a, h)).addEdge(new Line(h, c)).addEdge(new Line(c, a))); // ok
            res.addFace(new Face().addEdge(new Line(f, h)).addEdge(new Line(h, a)).addEdge(new Line(a, f))); // ok
            return res;
        }

        /// <summary>
        /// Получение октаэдра
        /// </summary>
        /// <returns></returns>
        public static Octahedron getOctahedron()
        {
            Octahedron res = new Octahedron();
            //Point a = new Point(100, 100, 0);
            //Point b = new Point(200, 100, 100);
            //Point c = new Point(100, 100, 200);
            //Point d = new Point(0, 100, 100);
            //Point e = new Point(100, 200, 100);
            //Point f = new Point(100, 0, 100);
            var cube = getHexahedron();
            Point a = cube.Faces[0].getCenter();
            Point b = cube.Faces[1].getCenter();
            Point c = cube.Faces[2].getCenter();
            Point d = cube.Faces[3].getCenter();
            Point e = cube.Faces[4].getCenter();
            Point f = cube.Faces[5].getCenter();
            res.addVerticles(new List<Point> {a, b, c, d, e, f});
            res.addFace(new Face().addEdge(new Line(a, f)).addEdge(new Line(f, b)).addEdge(new Line(b, a))); // ok
            res.addFace(new Face().addEdge(new Line(b, f)).addEdge(new Line(f, c)).addEdge(new Line(c, b))); // ok
            res.addFace(new Face().addEdge(new Line(c, f)).addEdge(new Line(f, d)).addEdge(new Line(d, c))); // ok
            res.addFace(new Face().addEdge(new Line(d, f)).addEdge(new Line(f, a)).addEdge(new Line(a, d))); // ok
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, e)).addEdge(new Line(e, a))); // ok
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, e)).addEdge(new Line(e, b))); // ok
            res.addFace(new Face().addEdge(new Line(c, d)).addEdge(new Line(d, e)).addEdge(new Line(e, c))); // ok
            res.addFace(new Face().addEdge(new Line(d, a)).addEdge(new Line(a, e)).addEdge(new Line(e, d))); // ok
            return res;
        }

        /// <summary>
        /// Получение гексаэдра (куба)
        /// </summary>
        /// <returns></returns>
        public static Hexahedron getHexahedron()
        {
            Hexahedron res = new Hexahedron();
            Point a = new Point(0, 0, 0);
            Point b = new Point(200, 0, 0);
            Point c = new Point(200, 0, 200);
            Point d = new Point(0, 0, 200);
            Point e = new Point(0, 200, 0);
            Point f = new Point(200, 200, 0);
            Point g = new Point(200, 200, 200);
            Point h = new Point(0, 200, 200);
            res.addFace(new Face().addEdge(new Line(a, d)).addEdge(new Line(d, c)).addEdge(new Line(c, b))
                .addEdge(new Line(b, a)));
            res.addFace(new Face().addEdge(new Line(b, c)).addEdge(new Line(c, g)).addEdge(new Line(g, f))
                .addEdge(new Line(f, b)));
            res.addFace(new Face().addEdge(new Line(f, g)).addEdge(new Line(g, h)).addEdge(new Line(h, e))
                .addEdge(new Line(e, f)));
            res.addFace(new Face().addEdge(new Line(h, d)).addEdge(new Line(d, a)).addEdge(new Line(a, e))
                .addEdge(new Line(e, h)));
            res.addFace(new Face().addEdge(new Line(a, b)).addEdge(new Line(b, f)).addEdge(new Line(f, e))
                .addEdge(new Line(e, a)));
            res.addFace(new Face().addEdge(new Line(d, h)).addEdge(new Line(h, g)).addEdge(new Line(g, c))
                .addEdge(new Line(c, d)));
            return res;
        }

        /// <summary>
        /// Получение икосаэдра
        /// </summary>
        /// <returns></returns>
        public static Icosahedron getIcosahedron()
        {
            Icosahedron res = new Icosahedron();
            Point circleCenter = new Point(100, 100, 100);
            List<Point> circlePoints = new List<Point>();
            for (int angle = 0; angle < 360; angle += 36)
            {
                if (angle % 72 == 0)
                {
                    circlePoints.Add(new Point(circleCenter.X + (100 * Math.Cos(Geometry.degreesToRadians(angle))),
                        circleCenter.Y + 100, circleCenter.Z + (100 * Math.Sin(Geometry.degreesToRadians(angle)))));
                    continue;
                }

                circlePoints.Add(new Point(circleCenter.X + (100 * Math.Cos(Geometry.degreesToRadians(angle))),
                    circleCenter.Y, circleCenter.Z + (100 * Math.Sin(Geometry.degreesToRadians(angle)))));
            }

            Point a = new Point(100, 50, 100);
            Point b = new Point(100, 250, 100);
            for (int i = 0; i < 10; i++)
            {
                res.addFace(new Face().addEdge(new Line(circlePoints[i], circlePoints[(i + 1) % 10]))
                    .addEdge(new Line(circlePoints[(i + 1) % 10], circlePoints[(i + 2) % 10]))
                    .addEdge(new Line(circlePoints[(i + 2) % 10], circlePoints[i])).addVerticles(new List<Point>
                        {circlePoints[i], circlePoints[(i + 1) % 10], circlePoints[(i + 2) % 10]}));
            }

            res.addFace(new Face().addEdge(new Line(circlePoints[1], a)).addEdge(new Line(a, circlePoints[3]))
                .addEdge(new Line(circlePoints[3], circlePoints[1]))
                .addVerticles(new List<Point> {circlePoints[1], a, circlePoints[3]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[3], a)).addEdge(new Line(a, circlePoints[5]))
                .addEdge(new Line(circlePoints[5], circlePoints[3]))
                .addVerticles(new List<Point> {circlePoints[3], a, circlePoints[5]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[5], a)).addEdge(new Line(a, circlePoints[7]))
                .addEdge(new Line(circlePoints[7], circlePoints[5]))
                .addVerticles(new List<Point> {circlePoints[5], a, circlePoints[7]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[7], a)).addEdge(new Line(a, circlePoints[9]))
                .addEdge(new Line(circlePoints[9], circlePoints[7]))
                .addVerticles(new List<Point> {circlePoints[7], a, circlePoints[9]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[9], a)).addEdge(new Line(a, circlePoints[1]))
                .addEdge(new Line(circlePoints[1], circlePoints[9]))
                .addVerticles(new List<Point> {circlePoints[9], a, circlePoints[1]}));

            res.addFace(new Face().addEdge(new Line(circlePoints[0], b)).addEdge(new Line(b, circlePoints[2]))
                .addEdge(new Line(circlePoints[2], circlePoints[0]))
                .addVerticles(new List<Point> {circlePoints[0], b, circlePoints[2]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[2], b)).addEdge(new Line(b, circlePoints[4]))
                .addEdge(new Line(circlePoints[4], circlePoints[2]))
                .addVerticles(new List<Point> {circlePoints[2], b, circlePoints[4]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[4], b)).addEdge(new Line(b, circlePoints[6]))
                .addEdge(new Line(circlePoints[6], circlePoints[4]))
                .addVerticles(new List<Point> {circlePoints[4], b, circlePoints[6]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[6], b)).addEdge(new Line(b, circlePoints[8]))
                .addEdge(new Line(circlePoints[8], circlePoints[6]))
                .addVerticles(new List<Point> {circlePoints[6], b, circlePoints[8]}));
            res.addFace(new Face().addEdge(new Line(circlePoints[8], b)).addEdge(new Line(b, circlePoints[0]))
                .addEdge(new Line(circlePoints[0], circlePoints[8]))
                .addVerticles(new List<Point> {circlePoints[8], b, circlePoints[0]}));
            return res;
        }

        /// <summary>
        /// Получение додекаэдра
        /// </summary>
        /// <returns></returns>
        public static Dodecahedron getDodecahedron()
        {
            Dodecahedron res = new Dodecahedron();
            var icosahedron = getIcosahedron();
            List<Point> centers = new List<Point>();
            for (int i = 0; i < icosahedron.Faces.Count; i++)
            {
                Face face = icosahedron.Faces[i];
                var c = face.getCenter();
                centers.Add(c);
            }

            //res.addFace(new Face().addEdge(new Line(centers[9], centers[0])).addEdge(new Line(centers[0], centers[1])).addEdge(new Line(centers[1], centers[10])).addEdge(new Line(centers[10], centers[14])).addEdge(new Line(centers[14], centers[9])));
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    res.addFace(new Face().addEdge(new Line(centers[i], centers[(i + 1) % 10]))
                        .addEdge(new Line(centers[(i + 1) % 10], centers[(i + 2) % 10]))
                        .addEdge(new Line(centers[(i + 2) % 10], centers[15 + (i / 2 + 1) % 5]))
                        .addEdge(new Line(centers[15 + (i / 2 + 1) % 5], centers[15 + i / 2]))
                        .addEdge(new Line(centers[15 + i / 2], centers[i])).addVerticles(new List<Point>
                        {
                            centers[i], centers[(i + 1) % 10], centers[(i + 2) % 10], centers[15 + (i / 2 + 1) % 5],
                            centers[15 + i / 2]
                        }));

                    continue;
                }

                res.addFace(new Face().addEdge(new Line(centers[i], centers[(i + 1) % 10]))
                    .addEdge(new Line(centers[(i + 1) % 10], centers[(i + 2) % 10]))
                    .addEdge(new Line(centers[(i + 2) % 10], centers[10 + (i / 2 + 1) % 5]))
                    .addEdge(new Line(centers[10 + (i / 2 + 1) % 5], centers[10 + i / 2]))
                    .addEdge(new Line(centers[10 + i / 2], centers[i]))).addVerticles(new List<Point>
                {
                    centers[i], centers[(i + 1) % 10], centers[(i + 2) % 10], centers[10 + (i / 2 + 1) % 5],
                    centers[10 + i / 2]
                });
            }

            res.addFace(new Face().addEdge(new Line(centers[15], centers[16]))
                .addEdge(new Line(centers[16], centers[17])).addEdge(new Line(centers[17], centers[18]))
                .addEdge(new Line(centers[18], centers[19])).addEdge(new Line(centers[19], centers[15]))
                .addVerticles(new List<Point> {centers[15], centers[16], centers[17], centers[18], centers[19]}));
            res.addFace(new Face().addEdge(new Line(centers[10], centers[11]))
                .addEdge(new Line(centers[11], centers[12])).addEdge(new Line(centers[12], centers[13]))
                .addEdge(new Line(centers[13], centers[14])).addEdge(new Line(centers[14], centers[10]))
                .addVerticles(new List<Point> {centers[10], centers[11], centers[12], centers[13], centers[14]}));

            return res;
        }

        ///
        /// <summary>
        /// Получение фигуры вращения
        /// </summary>
        /// <returns></returns>
        public static RotationShape getRotationShape(List<Point> general, int divisions, AxisType axis)
        {
            RotationShape res = new RotationShape();
            List<Point> genline = general;
            int GeneralCount = genline.Count();
            //Line axis;
            int Count = divisions;
            double angle = (360.0 / Count); //угол
            List<Line> edges1 = new List<Line>(); //дно и верхушка
            List<Line> edges2 = new List<Line>(); //
            List<Point> v = new List<Point>();
            List<Point> v1 = new List<Point>();
            res.addPoints(genline); //добавили образующую
            for (int i = 1; i < divisions; i++) //количество разбиений
            {
                res.addPoints(Geometry.RotatePoint(genline, axis, angle * i));
            }
            //

            //Фигура вращения задаётся тремя параметрами: образующей(набор точек), осью вращения и количеством разбиений
            //зададим ребра и грани
            for (int i = 0; i < divisions; i++)
            {
                for (int j = 0; j < GeneralCount; j++)
                {
                    int index = i * GeneralCount + j; //индекс точки
                    if (index < divisions * GeneralCount)
                    {
                        int e = (index + GeneralCount) % res.Points.Count;
                        if ((index + 1) % GeneralCount == 0)
                        {
                            // res.addFace(new Face().addEdge(new Line( res.Points[current], res.Points[e])));
                            res.addEdge(new Line(res.Points[index], res.Points[e]));
                        }
                        else
                        {
                            res.addEdge(new Line(res.Points[index], res.Points[index + 1]));
                            res.addEdge(new Line(res.Points[index], res.Points[e]));
                            int e1 = (index + 1 + GeneralCount) % res.Points.Count;
                            //добавим грань
                            //res.addFace(new Face().addEdge(new Line(res.Points[index], res.Points[index + 1])).addEdge(new Line(res.Points[index + 1], res.Points[e1])).addEdge(new Line(res.Points[e1], res.Points[e])).addEdge(new Line(res.Points[e], res.Points[index])).addVerticles(new List<Point> { res.Points[index], res.Points[index + 1], res.Points[e1], res.Points[e] }));
                            res.addFace(new Face().addEdge(new Line(res.Points[e], res.Points[e1]))
                                .addEdge(new Line(res.Points[e1], res.Points[index + 1]))
                                .addEdge(new Line(res.Points[index + 1], res.Points[index]))
                                .addEdge(new Line(res.Points[index], res.Points[e])).addVerticles(new List<Point>
                                    {res.Points[index], res.Points[index + 1], res.Points[e1], res.Points[e]}));
                            edges1.Add(new Line(res.Points[index],
                                res.Points[e1])); //res.Points[index], res.Points[e1])
                            v.AddRange(new List<Point> {res.Points[index], res.Points[e1]});
                            edges2.Add(new Line(res.Points[index + 1],
                                res.Points[e])); //res.Points[index+1], res.Points[e]
                            v1.AddRange(new List<Point> {res.Points[index + 1], res.Points[e]});
                        }
                    }
                }
            }

            res.addFace(new Face().addEdges(edges1).addVerticles(v));
            res.addFace(new Face().addEdges(edges2).addVerticles(v1));
            return res;
        }

        public static SurfaceSegment getSurfaceSegment(Func<double, double, double> fun, int x0, int x1, int y0, int y1,
            int splitting)
        {
            SurfaceSegment res = new SurfaceSegment(x0, x1, y0, y1, splitting);
            double stepX = Math.Abs(x1 - x0) * 1.0 / splitting;
            double stepY = Math.Abs(y1 - y0) * 1.0 / splitting;
            for (double x = x0; x < x1; x += stepX)
            {
                for (double y = y0; y < y1; y += stepY)
                {
                    var face = new Face();
                    face.addEdge(new Line(new Point(x, y, fun(x, y)), new Point(x + stepX, y, fun(x + stepX, y))));
                    face.addEdge(new Line(new Point(x + stepX, y, fun(x + stepX, y)),
                        new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY))));
                    face.addEdge(new Line(new Point(x + stepX, y + stepY, fun(x + stepX, y + stepY)),
                        new Point(x, y + stepY, fun(x, y + stepY))));
                    face.addEdge(new Line(new Point(x, y + stepY, fun(x, y + stepY)), new Point(x, y, fun(x, y))));
                    res.addFace(face);
                }
            }

            return res;
        }
    }
}