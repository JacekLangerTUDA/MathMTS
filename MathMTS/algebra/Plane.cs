namespace MathMTS.algebra;

public class Plane : IPlane
{
    public Vector3D[] Vertices { get; set; } = new Vector3D[3];
    public double[] alphas { get; set; } = new double[2];

    public Plane(Vector3D start, Vector3D first, Vector3D second, double alpha, double beta)
    {
        Vertices[0] = start;
        Vertices[1] = first;
        Vertices[2] = second;
        alphas[0] = alpha;
        alphas[1] = beta;
    }
    /// <summary>
    /// Calculates the cross product of the two directional vertices.
    /// </summary>
    /// <returns>the normal vector of the plane</returns>
    public Vector3D Normal()
    {
        return Vertices[1].CorssProduct(Vertices[2]) as Vector3D;
    }

}
