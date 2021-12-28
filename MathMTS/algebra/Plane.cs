using MathMTS.algebra.Interfaces;

namespace MathMTS.algebra;

public class Plane : IPlane
{
    /// <summary>
    ///     Creates a new plane which has the start point and the directional
    ///     vertices set to the provided vertices. The size
    ///     of the plane is dependent on the alpha and beta provided.
    /// </summary>
    /// <param name="start">the start of the plane</param>
    /// <param name="first">first directional vector</param>
    /// <param name="second">second directional vector</param>
    /// <param name="alpha">multiplier for the first directional vector</param>
    /// <param name="beta">multiplier for the second directional vector</param>
    public Plane(Vector3D start, Vector3D first, Vector3D second, double alpha, double beta)
    {
        this.Vertices[0] = start;
        this.Vertices[1] = first;
        this.Vertices[2] = second;
        this.alphas[0] = alpha;
        this.alphas[1] = beta;
    }

    public Vector3D[] Vertices { get; set; } = new Vector3D[3];
    public double[] alphas { get; set; } = new double[2];

    /// <summary>
    ///     Calculates the cross product of the two directional vertices.
    /// </summary>
    /// <returns>the normal vector of the plane</returns>
    public Vector3D Normal() => this.Vertices[1].CrossProduct(this.Vertices[2]);
}
