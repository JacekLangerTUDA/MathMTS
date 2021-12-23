namespace Matrizen.alebra
{
    /// <summary>
    /// Point in Rx where x is the dimensions the point covers.
    /// </summary>
    public class Point
    {
        public double[] points { get; set; }

        /// <summary>
        /// Constructor for this class, expects an array of double that 
        /// represents the points in a Rx where each value represents another dimension.
        /// x,y,z for example would be the R3.
        /// </summary>
        /// <param name="points"></param>
        public Point(params double[] points)
        {
            this.points = points;
        }
    }
}
