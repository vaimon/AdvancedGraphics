using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Объёмная фигура, состоящая из граней
    /// </summary>
    public class Shape
    {
        List<Face> faces;
        List<Point> verticles;

        public Shape()
        {
            faces = new List<Face>();
            verticles = new List<Point>();
        }

        public Shape(IEnumerable<Face> faces) : this()
        {
            this.faces.AddRange(faces);
        }

        public Shape addFace(Face face)
        {
            faces.Add(face);
            return this;
        }

        public Shape addFaces(IEnumerable<Face> faces)
        {
            this.faces.AddRange(faces);
            return this;
        }

        public List<Face> Faces
        {
            get => faces;
        }

        public Shape(IEnumerable<Point> verticles) : this()
        {
            this.verticles.AddRange(verticles);
        }

        public Shape addVerticle(Point verticle)
        {
            verticles.Add(verticle);
            return this;
        }

        public Shape addVerticles(IEnumerable<Point> verticles)
        {
            this.verticles.AddRange(verticles);
            return this;
        }

        public List<Point> Verticles
        {
            get => verticles;
        }

        /// <summary>
        /// Преобразует все точки в фигуре по заданной функции
        /// </summary>
        /// <param name="f">Функция, преобразующая точку фигуры</param>
        public void transformPoints(Func<Point, Point> f)
        {
            foreach (var face in Faces)
            {
                foreach (var line in face.Edges)
                {
                    line.start = f(line.start);
                    line.end = f(line.end);
                }

                face.verticles = face.verticles.Select(x => f(x)).ToList();
            }
        }


        /// <summary>
        /// Виртуальный метод, чтобы наследники могли возвращать какую-то инфу для сохранения в файл
        /// </summary>
        /// <returns></returns>
        public virtual String getAdditionalInfo()
        {
            return "";
        }

        /// <summary>
        /// Виртуальный метод, чтобы наследники могли возвращать свои имена
        /// </summary>
        /// <returns></returns>
        public virtual String getShapeName()
        {
            return "SHAPE";
        }

        // читает модель многогранника из файла
        public static Shape readShape(string fileName)
        {
            Shape res = new Shape();
            StreamReader sr = new StreamReader(fileName);
            List<Line> edgs = new List<Line>();
            List<Point> verts = new List<Point>();
            // название фигуры
            string line = sr.ReadLine();
            if (line != null)
            {
                switch (line)
                {
                    case "TETRAHEDRON":
                        res = new Tetrahedron();
                        break;
                    case "HEXAHEDRON":
                        res = new Hexahedron();
                        break;
                    case "OCTAHEDRON":
                        res = new Octahedron();
                        break;
                    case "ICOSAHEDRON":
                        res = new Icosahedron();
                        break;
                    case "DODECAHEDRON":
                        res = new Dodecahedron();
                        break;
                    case "SURFACESEGMENT":
                        res = new SurfaceSegment();
                        break;
                    case "ROTATIONSHAPE":
                        res = new RotationShape();
                        break;
                    case "OBJECT":
                        res = new ObjectShape();
                        break;
                    default:
                        throw new Exception("Такой фигуры нет :с");
                }
            }

            line = sr.ReadLine();
            if (line != null)
            {
                // какая-то доп информация
                res.getAdditionalInfo();
            }

            line = sr.ReadLine();
            // считываем данные о каждой грани
            while (line != null)
            {
                string[] lineParse = line.Split(); // делим грань на ребра
                foreach (string pointLine in lineParse)
                {
                    if (pointLine == "")
                        break;
                    string[] str = pointLine.Split(';'); // делим на точки начала и конца ребер
                    var startPoint = str[0].Split(','); // начало ребра
                    var endPoint = str[1].Split(','); // конец ребра
                    // добавляем новое ребро текущей грани
                    edgs.Add(new Line(
                        new Point(int.Parse(startPoint[0]), int.Parse(startPoint[1]), int.Parse(startPoint[2])),
                        new Point(int.Parse(endPoint[0]), int.Parse(endPoint[1]), int.Parse(endPoint[2]))));
                    verts.Add(new Point(int.Parse(startPoint[0]), int.Parse(startPoint[1]), int.Parse(startPoint[2])));
                    verts.Add(new Point(int.Parse(endPoint[0]), int.Parse(endPoint[1]), int.Parse(endPoint[2])));
                }

                List<Point> v = Distinct(verts);
                res.addFace(new Face(edgs).addVerticles(v)); // добавляем целую грань фигуры
                edgs = new List<Line>();
                verts.Clear();
                v.Clear();
                line = sr.ReadLine();
            }

            sr.Close();
            return res;
        }

        public static List<Point> Distinct<Point>(List<Point> l)
        {
            List<Point> uniq = new List<Point>();
            foreach (Point p in l)
            {
                if (!uniq.Contains(p))
                    uniq.Add(p);
            }

            return uniq;
        }

        // сохраняет модель многогранника в файл
        public void saveShape(string fileName)
        {
            // очистка файла
            File.WriteAllText(fileName, String.Empty);
            // запись в файл
            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(this.getShapeName()); // название фигуры
            sw.WriteLine(this.getAdditionalInfo()); // дополнительная информация
            foreach (Face face in this.Faces)
            {
                foreach (Line edge in face.Edges)
                {
                    sw.Write(edge.Start.X + "," + edge.Start.Y + "," + edge.Start.Z + ";" + edge.End.X + "," +
                             edge.End.Y + "," + edge.End.Z + " ");
                }

                sw.WriteLine();
            }

            sw.Close();
        }

        public override string ToString()
        {
            return $"{getShapeName()} ({faces.Count})";
        }
    }
}