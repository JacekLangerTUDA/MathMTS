using System;
using MathMTS.algebra;
using NUnit.Framework;

namespace MathMtsTests
{
    public class MatrixTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Multiply3x3Test()
        {
            Matrix first = new Matrix(new double[,] { { 1, 2, 3 },
                                                            { 4, 5, 6 },
                                                            { 7, 8, 9 } });
            Matrix second = new Matrix(new double[,] { { 1, 2, 3 },
                                                            { 4, 5, 6 },
                                                            { 7, 8, 9 } });
            Matrix expected = new Matrix(new double[,] {
                                                            { 30, 36, 42 }, 
                                                            { 66, 81, 96 },
                                                            { 102, 126, 150 }});
            Matrix actual = first * second;

            int index = 0;  
            for (int h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
            {
                for (int w = 0; w < actual.Width; w++)
                {
                    var a = expected.MatrixArray[h, w];
                    var b = actual.MatrixArray[h, w];
                    Assert.True(Math.Abs(a - b) < 0.0001f);
                }
            }
        }

        [Test]
        public void Multiply5x3Test()
        {
            Matrix first = new Matrix(new double[,] { { 1, 2, -3 ,2,1},
                                                            { 1, 0, 2 ,1,2},
                                                            { -1, 2, 3 ,4,5} });
            Matrix second = new Matrix(new double[,] { { 1, 2, 3 },
                                                             { 3, -2, 1 },
                                                             { 2, 2, 0 },
                                                             { -1, 5, 3 },
                                                             { 3, 3, 1 } });
            Matrix expected = new Matrix(new double[,] { { 2, 5, 12 }, 
                                                                { 10, 17, 8 },
                                                                { 22, 35, 16 } });
            Matrix actual = first * second;
            
            int index = 0;  
            for (int h = 0; h < actual.MatrixArray.Length / actual.Width; h++)
            {
                for (int w = 0; w < actual.Width; w++)
                {
                    var a = expected.MatrixArray[h, w];
                    var b = actual.MatrixArray[h, w];
                    Assert.True(Math.Abs(a - b) < 0.0001f);
                }
            }
        }

        //TODO: more tests
        [Test]
        public void AdditionTest()
        {
            Matrix first = new Matrix(new double[,] {{1,1,1 },{1,1,1}});
            Matrix second = new Matrix(new double[,] {{1,1,1 },{1,1,1}});
            Matrix expected = new Matrix(new double[,] {{2,2,2 },{2,2,2}});
            Matrix actual = (first + second);

            for (int h = 0; h < first.Height; h++)
            {
                for (int w = 0; w < first.Width; w++)
                {
                    Assert.AreEqual(expected.MatrixArray.GetValue(h,w), 
                        actual.MatrixArray.GetValue(h,w));
                }
            }
        }
    }
}