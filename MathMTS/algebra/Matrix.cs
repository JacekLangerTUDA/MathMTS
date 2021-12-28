using MathMTS.algebra.exceptions;

namespace MathMTS.algebra;

/// <summary>
///     Matrix class for matrix operations.
/// </summary>
public class Matrix
{
    /// <summary>
    ///     matrix for storing values.
    /// </summary>
    private readonly double[,] matrix;
    /// <summary>
    ///     the height of the matrix
    /// </summary>
    private int _height;
    /// <summary>
    ///     the width of the matrix
    /// </summary>
    private int _width;

    /// <summary>
    ///     Constructor that creates a zero matrix of the given size.
    /// </summary>
    /// <param name="height">the height</param>
    /// <param name="width">the width</param>
    public Matrix(int height, int width)
    {
        _height = height;
        _width = width;

        matrix = new double[height, width];
    }
    /// <summary>
    ///     constructor that takes a multidimensional array to set as the matrix
    /// </summary>
    /// <param name="values"></param>
    public Matrix(double[,] values)
    {
        matrix = values;
        _width = values.GetLength(1); // the second index, (the second array)
        _height = values.Length / _width;
    }
    /// <summary>
    ///     The public matrix.
    /// </summary>
    public double[,] MatrixArray
    {
        get => matrix;
        set => value = matrix;
    }

    /// <summary>
    ///     the height of the matrix.
    /// </summary>
    public int Height
    {
        get => _height;
        set => _height = value;
    }

    /// <summary>
    ///     the width of the matrix.
    /// </summary>
    public int Width
    {
        get => _width;
        set => _width = value;
    }

    /// <summary>
    ///     adds two matrizes and returns a new matrix as a result
    /// </summary>
    /// <param name="first">the first matrix</param>
    /// <param name="second">the second matrix</param>
    /// <returns>new matrix with added values</returns>
    public static Matrix operator +(Matrix first, Matrix second)
    {

        if (first.Height != second.Height
            || first.Width != second.Width)
            throw new InvalidMatrixOperationException(
                "you can not add two matricies of different size");
        var temp = first.MatrixArray;
        for (var h = 0; h < first.Height; h++)
        for (var w = 0; w < first.Width; w++)
        {
            temp[h, w] += second.MatrixArray[h, w];
        }

        return new Matrix(temp);
    }

    /// <summary>
    ///     Multiplies the values with the provided alpha.
    /// </summary>
    /// <param name="alpha">multiplikator </param>
    /// <param name="mat">the matrix</param>
    /// <returns>new matrix with values of old multiplied by alpha</returns>
    public static Matrix operator *(double alpha, Matrix mat)
    {
        var values = mat.MatrixArray;
        for (var i = 0; i < values.Rank; i++)
        for (var j = 0; j < values.GetLength(i); j++)
        {
            values[i, j] *= alpha;
        }
        return new Matrix(values);
    }

    /// <summary>
    ///     multiplicates two matrices.
    /// </summary>
    /// <param name="first">the first matrix</param>
    /// <param name="second">the second matrix</param>
    /// <returns>Matrix of the width of second and height of first</returns>
    public static Matrix operator *(Matrix first, Matrix second)
    {
        if (first.Width != second.Height)
            throw new InvalidMatrixOperationException("you can not multiply these matrices");

        var temp = new Matrix(new double[first.Height, second.Width]);

        for (var i = 0; i < temp.MatrixArray.Length; i++)
        {
            double val = 0;
            var hIndex = i / temp.Width;
            for (var w = 0; w < first.Width; w++)
            {
                val += first.MatrixArray[hIndex, w] * second.MatrixArray[w, i % temp._width];
            }
            temp.MatrixArray[hIndex, i % temp.Width] = val;
        }

        return temp;
    }

    /// <summary>
    ///     Calculates the determinante of the matrix.
    /// </summary>
    /// <returns>Determinante</returns>
    public double Determinante()
    {
        // only square matrices have a determinant!
        if (this.Height != this.Width)
            throw new InvalidMatrixOperationException(
                $"Invalid matrix, a {this.Width}x{this.Height} matrix has no determinant");

        double a, b, determinante = 0;
        for (var w = 0; w < this.Width; w++)
        {
            // set a and b to the first elements of the respective row and column
            a = this.MatrixArray[0, w];
            b = this.MatrixArray[this.Height - 1, w];
            // start at the second element
            for (var h = 1; h < this.Height; h++)
            {
                // move to the right and down start at the left side when the outer bound is reached
                a *= this.MatrixArray[h, (h + w) % this.Width];
                // move to the right and up start at the left side when the outer bound is reached
                b *= this.MatrixArray[this.Height - h - 1, (h + w) % this.Width];
            }
            determinante += a - b;
        }
        return determinante;
    }
}
