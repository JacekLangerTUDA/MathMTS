using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra
{
    /// <summary>
    /// Point in Rx where x is the dimensions the point covers.
    /// </summary>
    public abstract class Point : IPoint
    {
        private double[] coordinates;
        public double[] Coordinates { get => coordinates; set => coordinates = value; }

        /// <summary>
        /// Constructor for this class, expects an array of double that 
        /// represents the points in a Rx where each value represents another dimension.
        /// x,y,z for example would be the R3.
        /// </summary>
        /// <param name="points"></param>
        public Point(params double[] points)
        {
            this.Coordinates = points;
        }

        public abstract IVector CreateVector(IPoint point);

        public abstract IVector CreateVector(IPoint start, IPoint end);
    }
}
