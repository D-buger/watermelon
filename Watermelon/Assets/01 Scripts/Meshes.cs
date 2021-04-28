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
        

        //순차적 정수가 담긴 배열 생성, 매개 변수(첫 번째 정수, 생성할 순차적 정수 개수)
        //.Select(조건) 
        //예) Enumerable.Range(1, 10).Select(x => x * x) 일 때 1 4 9 ...100 (10 * 10)까지 생성된다.
        //원래 return되는 자료형은 IEnumerable<자료형> 이지만, ToArray를 통해 배열화시킨다.
        
        //원 둘레의 점들을 배열로 받는다.
        var circleVertices = Enumerable.Range(0, numSeg)
            .Select(i =>
            {
                var theta = 2 * Mathf.PI * i / numSeg; //각도 = 2 * π * i / 전체 갯수
                return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius; //세타에 대한 밑변(x)과 높이(y)
            })
            .ToArray();

        // 해당 도형에서 모든 삼각형을 찾는다.
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