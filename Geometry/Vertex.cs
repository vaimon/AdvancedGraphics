namespace GraphicsHelper
{
    public class Vertex : Point
    {
        public TexturePoint texturePoint;
        public Vector normVector;
        
        public Vertex(int x, int y, int z) : base(x, y, z) { }

        public Vertex(double x, double y, double z) : base(x, y, z) { }

        public Vertex(Point p) : base(p) { }

        public Vertex(Point p, Vector normVector, TexturePoint texturePoint) : base(p)
        {
            this.normVector = normVector;
            this.texturePoint = texturePoint;
        }
    }
}