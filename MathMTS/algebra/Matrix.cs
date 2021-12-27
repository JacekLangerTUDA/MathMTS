using System.Data;
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
    private int height;
    /// <summary>
    ///     the width of the matrix
    /// </summary>
    private int width;

    /// <summary>
    ///     Constructor that creates a zero matrix of the given size.
    /// </summary>
    /// <param name="height">the height</param>
    /// <param name="width">the width</param>
    public Matrix(int height, int width)
    {
        this.height = height;
        this.width = width;

        matrix = new double[height, width];
    }
    /// <summary>
    ///     constructor that takes a multidimensional array to set as the matrix
    /// </summary>
    /// <param name="values"></param>
    public Matrix(double[,] values)
    {
        matrix = values;
        width = values.GetLength(1);        // the second index, (the second array)
        height = values.Length / width;
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
        get => height;
        set => height = value;
    }

    /// <summary>
    ///     the width of the matrix.
    /// </summary>
    public int Width
    {
        get => width;
        set => width = value;
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
                temp[h,w] += second.MatrixArray[h,w];

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
            values[i, j] *= alpha;
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

        for (int i = 0; i < temp.MatrixArray.Length; i++)
        {
            double val = 0;
            int hIndex = i / temp.Width;
            for (int w = 0; w < first.Width; w++)
            {
                val += first.MatrixArray[hIndex, w] * second.MatrixArray[w, i% temp.width];
            }
            temp.MatrixArray[hIndex, i % temp.Width] = val;
        }

        return temp;
    }

    /// <summary>
    ///     Calculates the determinante of the matrix.
    /// </summary>
    /// <returns>Determinante</returns>
    private double Determinante()
    {
        return -1;
    }
}
