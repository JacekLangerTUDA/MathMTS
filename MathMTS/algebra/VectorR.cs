using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra
{
    public class VectorR : Vector
    {
        public VectorR(double[] matrix) : base(matrix)
        {
        }

        public VectorR(IPoint start, IPoint end) : base(start, end)
        {
        }
    }
}
