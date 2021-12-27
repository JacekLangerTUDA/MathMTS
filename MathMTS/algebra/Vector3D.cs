using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra;

public class Vector3D : Vector
{
    /// <summary>
    ///     Constructor for this class, creates a new Vector3D with 0 Values for each dimension.
    /// </summary>
    public Vector3D() : this(0, 0, 0)
    {
    }

    /// <summary>
    ///     Constructor for the Vector3D, creates a new instance of a
    ///     Vector with 3 dimensions and values x,y,z the respective dimension.
    /// </summary>
    /// <param name="x">x value</param>
    /// <param name="y">y value</param>
    /// <param name="z">z value</param>
    public Vector3D(double x, double y, double z) : this(new[] { x, y, z })
    {
    }

    private Vector3D(double[] matrix) : base(matrix)
    {
        X = matrix[0];
        Y = matrix[1];
        Z = matrix[2];
    }

    private double x;

    public double X
    {
        get { return x; }
        set
        {
            x = value;
            this.Values[0] = value;
        }
    }
    private double y;

    public double Y
    {
        get => y;
        set
        {
            y = value;
            Values[1] = value;
        }
    }
    private double z;
    public double Z
    {
        get => z;
        set
        {
            z = value;
            Values[2] = value;
        }
    }


    public Vector3D CorssProduct(IVector other)
    {
        var temp = new Vector3D();

        temp.X = Y * other.Values[2] - Z * other.Values[1];
        temp.Y = Z * other.Values[0] - X * other.Values[2];
        temp.Z = X * other.Values[1] - Y * other.Values[0];

        return temp;
    }
}