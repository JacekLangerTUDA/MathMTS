
using Matrizen.alebra.exceptions;

namespace Matrizen.alebra
{
    /// <summary>
    /// Vector class to provide functionality for vector operations.
    /// </summary>
    public class Vector
    {
        private double[] matrix;

        public double[] Values => matrix;

        public Vector(double[] matrix)
        {
            this.matrix = matrix;
        }
        /// <summary>
        /// 
        /// </summary>
        public Vector(Point start, Point end)
        {
            if (start.points.Length == end.points.Length)
            {
                throw new InvalidVectorOperationException("You can't create a vector of different dimensions");
            }

            for (int i = 0; i < start.points.Length; i++)
            {

            }
        }
    }
}
