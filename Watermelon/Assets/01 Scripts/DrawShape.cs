using UnityEngine;

public abstract class DrawShape
{
    public abstract bool ShapeFinishied { get; }
    public abstract bool SimulatingPhysics { get; set; }
    public abstract void AddVertex(Vector2 vertex);
    public abstract void UpdateShape(Vector2 newVertex);
}
