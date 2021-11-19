using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsHelper
{
    class Tetrahedron : Shape
    {
        public override String getShapeName()
        {
            return "TETRAHEDRON";
        }
    }

    class Octahedron : Shape
    {
        public override String getShapeName()
        {
            return "OCTAHEDRON";
        }
    }

    class Hexahedron : Shape
    {
        public override String getShapeName()
        {
            return "HEXAHEDRON";
        }
    }

    class ObjectShape : Shape
    {
        public override String getShapeName()
        {
            return "OBJECT";
        }
    }

    class Icosahedron : Shape
    {
        public override String getShapeName()
        {
            return "ICOSAHEDRON";
        }
    }

    class Dodecahedron : Shape
    {
        public override String getShapeName()
        {
            return "DODECAHEDRON";
        }
    }

    /// <summary>
    /// Класс фигур вращения
    /// </summary>
    class RotationShape : Shape
    {
        List<Point> formingline;
        Line axiz;
        int Divisions;
        List<Point> allpoints;
        List<Line> edges;
        List<Line> edges1 = new List<Line>(); //ребра

        public RotationShape()
        {
            allpoints = new List<Point>();
            edges = new List<Line>();
        }

        public List<Line> Edges
        {
            get => edges;
        }

        public Shape addEdge(Line edge)
        {
            edges.Add(edge);
            return this;
        }

        public Shape addEdges(IEnumerable<Line> ed)
        {
            this.edges.AddRange(ed);
            return this;
        }

        public RotationShape(IEnumerable<Point> points) : this()
        {
            this.allpoints.AddRange(points);
        }

        public RotationShape(Line ax, int Div, IEnumerable<Point> line) : this()
        {
            this.axiz = ax;
            this.Divisions = Div;
            this.formingline.AddRange(line);
        }

        public RotationShape addPoint(Point p)
        {
            allpoints.Add(p);
            return this;
        }

        public RotationShape addPoints(IEnumerable<Point> points)
        {
            this.allpoints.AddRange(points);
            return this;
        }

        public List<Point> Points
        {
            get => allpoints;
        }

        public override String getShapeName()
        {
            return "ROTATIONSHAPE";
        }
    }

    class SurfaceSegment : Shape
    {
        int x0, x1, y0, y1;
        int splitting;

        public SurfaceSegment()
        {
        }

        public SurfaceSegment(int x0, int x1, int y0, int y1, int splitting)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.y0 = y0;
            this.y1 = y1;
            this.splitting = splitting;
        }

        public override String getShapeName()
        {
            return "SURFACESEGMENT";
        }
    }
}