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
    public void Test1()
    {
        var first = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        var second = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
        var expected = new Matrix(new double[,]
            { { 30, 66, 102 }, { 36, 81, 126 }, { 42, 96, 150 } });
        var actual = first * second;

        var index = 0;
        for (var h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
        for (var w = 0; w < actual.Width; w++)
        {
            var a = expected.MatrixArray[h, w];
            var b = actual.MatrixArray[h, w];
            Assert.True(Math.Abs(a - b) < 0.00001f);
        }
    }

    //TODO: more tests
}
