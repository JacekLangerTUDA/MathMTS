using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra
{
    public class PointR : Point
    {
        public override IVector CreateVector(IPoint point)
        {
            return new VectorR(this, this);
        }


        public override IVector CreateVector(IPoint start, IPoint end)
        {
            return new VectorR(end, this);
        }
    }
}
