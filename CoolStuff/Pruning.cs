using GraphicsHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = GraphicsHelper.Point;

namespace AdvancedGraphics
{
    public partial class Form1
    {
        // поиск нелицевых граней
        Shape findNonFacial(Shape shape, Camera camera)
        {
            Shape newShape;
            switch (shape.getShapeName())
            {
                case "TETRAHEDRON":
                    newShape = new Tetrahedron();
                    break;
                case "HEXAHEDRON":
                    newShape = new Hexahedron();
                    break;
                case "OCTAHEDRON":
                    newShape = new Octahedron();
                    break;
                case "ICOSAHEDRON":
                    newShape = new Icosahedron();
                    break;
                case "DODECAHEDRON":
                    newShape = new Dodecahedron();
                    break;
                case "SURFACESEGMENT":
                    newShape = new SurfaceSegment();
                    break;
                case "ROTATIONSHAPE":
                    newShape = new RotationShape();
                    break;
                case "OBJECT":
                    newShape = new ObjectShape();
                    break;
                default:
                    throw new Exception("Такой фигуры нет :с");
            }

            foreach (Face face in shape.Faces) // для каждой грани фигуры
            {
                Vector vectProec = new Vector(camera.toCameraView(face.getCenter())).normalize();


                /* вариант 2 */
                Vector vect1 = new Vector(face.Edges.First().getVectorCoordinates());
                Vector vect2 = new Vector(face.Edges.Last().getReverseVectorCoordinates());
                Vector vectNormal = vect1 * vect2;
                vectNormal = new Vector(camera.toCameraView(new Point(vectNormal.Xf, vectNormal.Yf, vectNormal.Zf)))
                    .normalize();
                double vectScalar = vectNormal.Xf * vectProec.Xf + vectNormal.Yf * vectProec.Yf +
                                    vectNormal.Zf * vectProec.Zf; // скалярное произведение

                if (vectScalar > 0)
                    newShape.addFace(face);
            }

            return newShape;
        }
    }
}