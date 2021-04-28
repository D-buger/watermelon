using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Meshes
{
    public static Mesh ColorCircleMesh(Vector2 v0, Vector2 v1, Color fillColor)
    {
        var radius = Vector2.Distance(v0, v1);

        const float segmentOffset = 40f;
        const float segmentMultiplier = 2 * Mathf.PI;
        int numSeg = (int)(radius * segmentMultiplier + segmentOffset);
        

        //������ ������ ��� �迭 ����, �Ű� ����(ù ��° ����, ������ ������ ���� ����)
        //.Select(����) 
        //��) Enumerable.Range(1, 10).Select(x => x * x) �� �� 1 4 9 ...100 (10 * 10)���� �����ȴ�.
        //���� return�Ǵ� �ڷ����� IEnumerable<�ڷ���> ������, ToArray�� ���� �迭ȭ��Ų��.
        
        //�� �ѷ��� ������ �迭�� �޴´�.
        var circleVertices = Enumerable.Range(0, numSeg)
            .Select(i =>
            {
                var theta = 2 * Mathf.PI * i / numSeg; //���� = 2 * �� * i / ��ü ����
                return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius; //��Ÿ�� ���� �غ�(x)�� ����(y)
            })
            .ToArray();

        // �ش� �������� ��� �ﰢ���� ã�´�.
        var triangles = new Triangulator(circleVertices).Triangulate();

        var colors = Enumerable.Repeat(fillColor, circleVertices.Length).ToArray();

        var mesh = new Mesh
        {
            name = "Circle",
            vertices = circleVertices.ToVector3(),
            triangles = triangles,
            colors = colors
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        return mesh;

    }
    public static Mesh SpriteCircleMesh(Vector2 v0, Vector2 v1, Sprite sprite)
    {
        var radius = Vector2.Distance(v0, v1);

        const float segmentOffset = 40f;
        const float segmentMultiplier = 2 * Mathf.PI;
        int numSeg = (int)(radius * segmentMultiplier + segmentOffset);
        
        var circleVertices = Enumerable.Range(0, numSeg)
            .Select(i =>
            {
                var theta = 2 * Mathf.PI * i / numSeg; 
                return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;
            })
            .ToArray();
        
        var triangles = new Triangulator(circleVertices).Triangulate();

        var mesh = new Mesh
        {
            name = "Circle",
            vertices = circleVertices.ToVector3(),
            triangles = triangles
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        return mesh;

    }
    static Mesh SpriteToMesh(Sprite sprite)
    {
        Mesh mesh = new Mesh();
        mesh.vertices = System.Array.ConvertAll(sprite.vertices, i => (Vector3)i);
        mesh.uv = sprite.uv;
        mesh.triangles = System.Array.ConvertAll(sprite.triangles, i => (int)i);

        return mesh;
    }
}