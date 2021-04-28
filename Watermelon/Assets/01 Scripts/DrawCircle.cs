using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class DrawCircle : DrawShape
{
    public Color fillColor = Color.white;
    public Sprite fillSprite;

    private MeshFilter meshFilter;
    private CircleCollider2D circleCollider;
    
    private LineRenderer outLineRenderer;

    private List<Vector2> vertices = new List<Vector2>(2) { Vector2.zero };

    public override bool ShapeFinishied => vertices.Count >= 2;

    private bool simulating;
    public override bool SimulatingPhysics
    {
        get => simulating;
        set => simulating = value;
    }

    public override void AddVertex(Vector2 vertex)
    {
        if (ShapeFinishied)
            return;

        vertices.Add(vertex);
        UpdateShape(vertex);
    }

    public override void UpdateShape(Vector2 newVertex)
    {
        if (vertices.Count < 2)
            return;

        vertices[vertices.Count - 1] = newVertex;

        //TODO : 게임오브젝트의 위치 지정

        //변형에 따라 메쉬 업데이트
        Vector2 v0 = vertices[0];
        Vector2 v1 = vertices[vertices.Count - 1];
        meshFilter.mesh = Meshes.ColorCircleMesh(v0, v1, fillColor);

        //outline
        outLineRenderer.positionCount = meshFilter.mesh.vertices.Length;
        outLineRenderer.SetPositions(meshFilter.mesh.vertices);
    }
}
