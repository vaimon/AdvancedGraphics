using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    /// <summary>
    /// Грань фигуры, состоящая из конечного числа отрезков
    /// </summary>
    public class Face
    {
        List<Line> edges;
        Vector normVector;
        public List<Point> verticles;

        public Face()
        {
            edges = new List<Line>();
            verticles = new List<Point>();
            normVector = new Vector(0, 0, 0);
        }

        public Face(IEnumerable<Line> edges) : this()
        {
            this.edges.AddRange(edges);
        }

        public Face addEdge(Line edge)
        {
            edges.Add(edge);
            recalculateNormVector();
            return this;
        }
        public Face addEdges(IEnumerable<Line> edges)
        {
            this.edges.AddRange(edges);
            recalculateNormVector();
            return this;
        }
        public Face addVerticle(Point p)
        {
            verticles.Add(p);
            return this;
        }
        public Face addVerticles(IEnumerable<Point> points)
        {
            this.verticles.AddRange(points);
            return this;
        }

        public List<Point> Verticles { get => verticles; }
        void recalculateNormVector()
        {

        }

        public Vector NormVector
        {
            get
            {
                Vector a = new Vector(edges.First().getVectorCoordinates()), b = new Vector(edges.Last().getReverseVectorCoordinates());
                normVector = (b * a).normalize();
                return normVector;
            }
        }

        public List<Line> Edges { get => edges; }

        /// <summary>
        /// Получение центра тяжести грани
        /// </summary>
        /// <returns><c>Point</c> - центр тяжести</returns>
        public Point getCenter()
        {
            double x = 0, y = 0, z = 0;
            foreach (var line in edges)
            {
                x += line.Start.Xf;
                y += line.Start.Yf;
                z += line.Start.Zf;
            }
            return new Point(x / edges.Count, y / edges.Count, z / edges.Count);
        }
    }
}
