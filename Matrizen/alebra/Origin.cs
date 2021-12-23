using Matrizen.alebra.Interfaces;

namespace Matrizen.alebra
{
    public class Origin : IPoint
    {

        public Origin(int dimensions)
        {
            Coordinates = new double[dimensions];
        }
        public double[] Coordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IVector CreateVector(IPoint point)
        {
            throw new NotImplementedException();
        }

        public IVector CreateVector(IPoint start, IPoint end)
        {
            return new Vector(this.Coordinates);
        }
    }
}
