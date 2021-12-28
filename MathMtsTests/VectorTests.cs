using MathMTS.algebra;
using MathMTS.algebra.Interfaces;
using NUnit.Framework;

namespace MathMtsTests;

public class VectorTests
{


    [Test]
    public void CrosproductTest()
    {
        var vector3D = new Vector3D(1, 2, 3);
        var other = new Vector3D(1, 2, 3);

        IVector vectorR = new VectorR(new double[] { 1, 2, 3 });
        IVector another = new VectorR(new double[] { 1, 2, 3 });
        IVector buffer = new VectorR(new double[3]);

        Assert.AreEqual(vector3D.Values, vectorR.Values);
        Assert.AreEqual(vectorR.CorssProduct(ref buffer, another).Values,
            vector3D.CrossProduct(other).Values);
        another = new VectorR(new double[3] { 2, 2, 2 });
        other = new Vector3D(2, 2, 2);
        IVector actual = vector3D.CrossProduct(other);
        Assert.AreEqual(vectorR.CorssProduct(ref buffer, another).Values, actual.Values);
    }
}
