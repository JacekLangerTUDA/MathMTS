namespace MathMTS.algebra.Interfaces
{
    public interface IPoint
    {
        /// <summary>
        /// the coordinates of the point
        /// </summary>
        double[] Coordinates { get; set; }
        /// <summary>
        /// Creates a Vectro from that points to the point and starts at the origin 0-Point
        /// </summary>
        /// <param name="point">the point</param>
        /// <returns></returns>
        IVector CreateVector(IPoint point);

        /// <summary>
        /// Creates a Vectro from that points to the point and starts at another point.
        /// </summary>
        /// <param name="start">the start point</param>
        /// <param name="end">the end point</param>
        /// <returns></returns>
        IVector CreateVector(IPoint start, IPoint end);
    }
}
