namespace MathMTS.algebra.Interfaces;

public interface IPlane
{
    /// <summary>
    ///     The multiplicators of the directional vertices.
    /// </summary>
    double[] alphas { get; set; }
    /// <summary>
    ///     The vertices of the plane.
    ///     The first one is the start and the other two the directional vertices.
    /// </summary>
    Vector3D[] Vertices { get; set; }
    /// <summary>
    ///     Calculates the cross product of the two directional vertices.
    /// </summary>
    /// <returns>the normal vector of the plane</returns>
    Vector3D Normal();
}
