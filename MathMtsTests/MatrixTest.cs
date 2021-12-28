using System;
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
    public void Multiply3x3Test()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });
        var second = new Matrix(new double[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        });
        var expected = new Matrix(new double[,]
        {
            { 30, 36, 42 },
            { 66, 81, 96 },
            { 102, 126, 150 }
        });
        var actual = first * second;

        var index = 0;
        for (var h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
        for (var w = 0; w < actual.Width; w++)
        {
            var a = expected.MatrixArray[h, w];
            var b = actual.MatrixArray[h, w];
            Assert.True(Math.Abs(a - b) < 0.0001f);
        }
    }

    [Test]
    public void Multiply5x3Test()
    {
        var first = new Matrix(new double[,]
        {
            { 1, 2, -3, 2, 1 },
            { 1, 0, 2, 1, 2 },
            { -1, 2, 3, 4, 5 }
        });
        var second = new Matrix(new double[,]
        {
            { 1, 2, 3 },
            { 3, -2, 1 },
            { 2, 2, 0 },
            { -1, 5, 3 },
            { 3, 3, 1 }
        });
        var expected = new Matrix(new double[,]
        {
            { 2, 5, 12 },
            { 10, 17, 8 },
            { 22, 35, 16 }
        });
        var actual = first * second;

        var index = 0;
        for (var h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
        for (var w = 0; w < actual.Width; w++)
        {
            var a = expected.MatrixArray[h, w];
            var b = actual.MatrixArray[h, w];
            Assert.True(Math.Abs(a - b) < 0.0001f);
        }
    }

    //TODO: more tests
    [Test]
    public void AdditionTest()
    {
        var first = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 } });
        var second = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 } });
        var expected = new Matrix(new double[,] { { 2, 2, 2 }, { 2, 2, 2 } });
        var actual = first + second;

        for (var h = 0; h < first.Height; h++)
        for (var w = 0; w < first.Width; w++)
        {
            Assert.AreEqual(expected.MatrixArray.GetValue(h, w),
                actual.MatrixArray.GetValue(h, w));
        }
    }
    //TODO: more tests
    [Test]
    public void DeterminantenTest()
    {
        var first = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
        var second =
            new Matrix(new double[,]
                { { 1, 2, 3, 4 }, { 1, 2, 1, 5 }, { 3, 2, 1, 6 }, { 4, 2, 2, 1 } });
        Assert.True(0 == first.Determinante());
        Assert.True(Math.Abs(72 - second.Determinante()) < 0.001f);
    }
}
