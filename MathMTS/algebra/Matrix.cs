using MathMTS.algebra.exceptions;

namespace MathMTS.algebra
{
    /// <summary>
    /// Matrix class for matrix operations.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// matrix for storing values.
        /// </summary>
        private double[,] matrix;
        /// <summary>
        /// the height of the matrix
        /// </summary>
        private int height;
        /// <summary>
        /// the width of the matrix
        /// </summary>
        private int width;
        /// <summary>
        /// The public matrix.
        /// </summary>
        public double[,] MatrixArray
        {
            get => matrix;
            set => value = matrix;
        }
        /// <summary>
        /// the height of the matrix.
        /// </summary>
        public int Height
        {
            get => height;
            set => height = value;
        }
        /// <summary>
        /// the width of the matrix.
        /// </summary>
        public int Width
        {
            get => width;
            set => width = value;
        }

        /// <summary>
        /// Constructor that creates a zero matrix of the given size.
        /// </summary>
        /// <param name="height">the height</param>
        /// <param name="width">the width</param>
        public Matrix(int height, int width)
        {
            this.height = height;
            this.width = width;

            this.matrix = new double[height, width];
        }
        /// <summary>
        /// constructor that takes a multidimensional array to set as the matrix
        /// </summary>
        /// <param name="values"></param>
        public Matrix(double[,] values)
        {
            matrix = values;
            this.height = values.Rank;
            this.width = values.GetLength(0);
        }

        /// <summary>
        /// Calculate the scalar pruduct of two vectors.
        /// </summary>
        /// <param name="first">the first vector</param>
        /// <param name="second">the second vector</param>
        /// <returns>the scalar product</returns>
        public static double calculateScalar(double[] first, double[] second)
        {

            double scalar = 0;
            for (int i = 0; i < first.Length; i++)
            {
                scalar += first[i] * second[i];
            }
            return scalar;
        }

        /// <summary>
        /// adds two matrizes and returns a new matrix as a result
        /// </summary>
        /// <param name="first">the first matrix</param>
        /// <param name="second">the second matrix</param>
        /// <returns>new matrix with added values</returns>
        public static Matrix operator +(Matrix first, Matrix second)
        {

            if (first.MatrixArray.Rank != second.MatrixArray.Rank
                || first.MatrixArray.GetLength(0) != second.MatrixArray.GetLength(0))
            {

                throw new InvalidMatrixOperationException("you can not add two matricies of different size");
            }
            var temp = first.MatrixArray;
            for (int i = 0; i < first.MatrixArray.Length; i++)
            {
                for (int j = 0; j < first.MatrixArray.GetLength(i); j++)
                {
                    temp[i, j] += second.MatrixArray[i, j];
                }
            }

            return new Matrix(temp);
        }
        /// <summary>
        /// Multiplies the values with the provided alpha.
        /// </summary>
        /// <param name="alpha">multiplikator </param>
        /// <param name="mat">the matrix</param>
        /// <returns>new matrix with values of old multiplied by alpha</returns>
        public static Matrix operator *(double alpha, Matrix mat)
        {
            var values = mat.MatrixArray;
            for (int i = 0; i < values.Rank; i++)
            {
                for (int j = 0; j < values.GetLength(i); j++)
                {
                    values[i, j] *= alpha;
                }
            }
            return new Matrix(values);
        }
        /// <summary>
        /// multiplicates two matrices.
        /// </summary>
        /// <param name="first">the first matrix</param>
        /// <param name="second">the second matrix</param>
        /// <returns>Matrix of the width of second and height of first</returns>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            var height = first.MatrixArray.Rank;
            var width = second.MatrixArray.GetLength(0);
            var inverted = InvertMatrix(second);


            //TODO: check who to acces whole rows in multidim arrays
            double[][] fst = new double[first.MatrixArray.Rank][];
            double[][] snd = new double[second.MatrixArray.Rank][];


            ///do we need to check for the size?? 
            for (int i = 0; i < fst.Length; i++)
            {
                for (int j = 0; j < second.MatrixArray.GetLength(i); j++)
                {
                    fst[i][j] = first.MatrixArray[i, j];
                    snd[i][j] = inverted.MatrixArray[i, j];
                }
            }

            double[,] temp = new double[height, width];

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    temp[h, w] = calculateScalar(fst[h], snd[w]);
                }
            }


            return new Matrix(temp);
        }

        /// <summary>
        /// Inverts the array in the matrix so it can be processed more easy in multiplication.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static Matrix InvertMatrix(Matrix matrix)
        {
            double[,] inverted = new double[matrix.MatrixArray.GetLength(0), matrix.MatrixArray.Rank];

            for (int h = 0; h < matrix.MatrixArray.GetLength(0); h++)
            {
                for (int d = 0; d < matrix.MatrixArray.Rank; d++)
                {
                    inverted[h, d] = matrix.MatrixArray[d, h];
                }
            }
            return new Matrix(inverted);
        }
    }
}
