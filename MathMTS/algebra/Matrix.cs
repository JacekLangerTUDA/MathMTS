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
      this.width = values.GetLength(0);
      this.height = values.Length / width;
    }

    /// <summary>
    /// Calculate the scalar pruduct of two vectors.
    /// </summary>
    /// <param name="first">the first vector</param>
    /// <param name="second">the second vector</param>
    /// <returns>the scalar product</returns>
    public static double CalculateScalar(double[] first, double[] second)
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
      double[][] snd = InitArray(second.Height, second.Width);
      double[][] fst = InitArray(first.Width, first.Height);   // first matrix is going to be flipped so we can just multiply the arrays

      int heigth, width;
      heigth = 0;
      width = 0;

      // invert the first matrix so its written downwards instead of sideways.
      foreach (var row in first.MatrixArray)
      {
        fst[heigth++][width] = row;
        if (heigth % first.height == 0 && heigth > 0)
        {
          width++;
          heigth = 0;
        }
      }
      //Convert the the second multi dimensional into jagged array
      heigth = 0;
      width = 0;

      foreach (var row in second.MatrixArray)
      {

        snd[heigth][width++] = row;

        if (width % second.width == 0)
        {
          width = 0;
          heigth++;
        }
      }


      double[,] temp = new double[first.width, second.height];

      for (int h = 0; h < first.height; h++)    // move down the array 
      {
        for (int w = 0; w < second.height; w++)   // move the array to the side
        {
          temp[h, w] = CalculateScalar(fst[h], snd[w]);
        }
      }

      return new Matrix(temp);
    }

    /// <summary>
    /// Initialize an empty multidimensional array with 0 values.
    /// </summary>
    /// <param name="width">the length of each array</param>
    /// <param name="height">the length of the multidimensional array</param>
    /// <returns>new multidimensional array</returns>
    private static double[][] InitArray(int width, int height)
    {
      var temp = new double[height][];

      for (int i = 0; i < height; i++)
      {
        temp[i] = new double[width];
      }
      return temp;

    }
  }
}
