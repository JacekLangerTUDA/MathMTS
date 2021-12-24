using MathMTS.algebra;
using NUnit.Framework;

namespace MathMtsTests;

public class MatrixTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void MultiplyTest()
    {
        Matrix first = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        Matrix second = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        Matrix expected = new Matrix(new double[,] { { 30, 66, 102 }, { 36, 81, 126 }, { 42, 96, 150 } });
        Matrix actual = first * second;

        int index = 0;
        for (int h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
        {
            for (int w = 0; w < actual.Width; w++)
            {
                Assert.AreEqual(expected.MatrixArray[h, w], actual.MatrixArray[h, w]);
            }
        }
    }
}
