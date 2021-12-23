namespace MathMTS.algebra
{
    public class Vector3D : Vector
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Vector3D(double x, double y, double z) : this(new double[] { x, y, z })
        {

        }
        private Vector3D(double[] matrix) : base(matrix)
        {
        }
    }
}
