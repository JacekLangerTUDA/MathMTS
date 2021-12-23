using Matrizen.alebra;
using Xunit;

namespace AlgebraTest
{
    public class UnitTest1
    {
        [Fact]
        public void MultiplicationTest()
        {
            Matrix first = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix second = new Matrix(new double[,] { { 6, 9, 2, 5 }, { 7, 0, 3, 6 }, { 8, 1, 4, 7 } });

            var exp = new double[,] { { 44, 12, 20, 38 }, { 107, 42, 47, 92 } };
            Matrix expected = new Matrix(exp);
            Assert.Equal(expected, first * second);
        }
        [Fact]
        public void AdditionTest()
        {
            Matrix expected = new Matrix(new double[,] { { 2, 2 }, { 2, 2 } });
            Matrix second = new Matrix(new double[,] { { 1, 1 }, { 1, 1 } });
            Matrix first = new Matrix(new double[,] { { 1, 1 }, { 1, 1 } });
            Assert.Equal(expected, second + first);
        }
    }
}