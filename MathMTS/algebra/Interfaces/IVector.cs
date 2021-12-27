using MathMTS.algebra.exceptions;

namespace MathMTS.algebra.Interfaces;

/// <summary>
/// Vector interface that defines operations
/// </summary>
public interface IVector
{
    /// <summary>
    /// The dimensions of the vector.
    /// </summary>
    int Dimension { get; set; }
    /// <summary>
    /// the values for each dimension of the vector.
    /// </summary>
    double[] Values { get; }

    /// <summary>
    /// Calculates the length of the vector.
    /// </summary>
    /// <returns></returns>
    double GetLength();
    /// <summary>
    /// Normalizes the vector to a length of 1.
    /// </summary>
    /// <returns></returns>
    IVector Normalize();

    /// <summary>
    /// Multiplies two vectors and returns the scalar.
    /// </summary>
    /// <param name="first">the first vector</param>
    /// <param name="second">the second vector</param>
    /// <returns>the scalar resulting from the multiplication</returns>
    /// <exception cref="InvalidVectorOperationException">if vectors of different dimensions</exception>
    public static double operator *(IVector first, IVector second)
    {
        if (first.Dimension != second.Dimension)
            throw new InvalidVectorOperationException(
                "it is not possible to multiply two vectors of different dimensions");
        double scalar = 0;
        for (int i = 0; i < first.Values.Length; i++)
        {
            scalar += first.Values[i] * second.Values[i];
        }
        return scalar;
    }
    /// <summary>
    /// Multiplies the values of a vector with an alpha.
    /// </summary>
    /// <param name="alpha">the multiplicator</param>
    /// <param name="vector">the vector</param>
    /// <returns>vector adjusted by alpha</returns>
    public static IVector operator *(double alpha, IVector vector)
    {
        for (int i = 0; i < vector.Values.Length; i++)
        {
            vector.Values[i] *= alpha;
        }
        return vector;
    }
    /// <summary>
    /// adds two vectors and returns the result.
    /// </summary>
    /// <param name="first">the first vector</param>
    /// <param name="second">the second vector</param>
    /// <returns>result of operation</returns>
    /// <exception cref="InvalidVectorOperationException"> if vectors of different dimensions</exception>
    public static IVector operator +(IVector first, IVector second)
    {
        if (first.Dimension != second.Dimension)
            throw new InvalidVectorOperationException(
                "it is not possible to multiply two vectors of different dimensions");

        for (int i = 0; i < first.Values.Length; i++)
        {
            first.Values[i] += second.Values[i];
        }
        return first;
    }

    /// <summary>
    /// Subtract two vectors to get a new vector.
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public static IVector operator -(IVector first, IVector second) => first + (-1 * second);

    /// <summary>
    /// Returns the cross product of two vectors
    /// </summary>
    /// <param name="other"></param>
    /// <returns>the normal vector of two vectors</returns>
    public IVector CorssProduct(ref IVector buffer, IVector other);

    /// <summary>
    /// Calculate the length of the  Vector.
    /// </summary>
    /// <returns>a scalar representing the length of the vector</returns>
    public double Length();

}
