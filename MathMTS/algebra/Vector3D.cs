using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra;

public class Vector3D : Vector
{

    private double x;
    private double y;
    private double z;
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
        this.X = matrix[0];
        this.Y = matrix[1];
        this.Z = matrix[2];
    }

    public double X
    {
        get => x;
        set
        {
            x = value;
            this.Values[0] = value;
        }
    }

    public double Y
    {
        get => y;
        set
        {
            y = value;
            this.Values[1] = value;
        }
    }
    public double Z
    {
        get => z;
        set
        {
            z = value;
            this.Values[2] = value;
        }
    }

    /// <summary>
    ///     Calculates the Angle between the Vector and another Vector.
    /// </summary>
    /// <param name="other">the other vector</param>
    /// <returns>the angle between the vertices</returns>
    public double Angle(IVector other)
        => Math.Acos(Math.Abs(this * other) / (Length() * other.Length()));

    public Vector3D CrossProduct(IVector other)
    {
        var temp = new Vector3D();

        temp.X = this.Y * other.Values[2] - this.Z * other.Values[1];
        temp.Y = this.Z * other.Values[0] - this.X * other.Values[2];
        temp.Z = this.X * other.Values[1] - this.Y * other.Values[0];

        return temp;
    }
}
