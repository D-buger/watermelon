using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Unity에서는 opengl처럼 GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN을 지원하지 않는듯함.
// 오직. GL_TRIANGLES 삼각형 조합만 지원하는갑다.

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TestCustomMesh : MonoBehaviour
{
    // 버텍스 list
    public List<Vector3> listVertex = new List<Vector3>();

    // 색상 정보 list
    public List<Color> listColor = new List<Color>();

    // 정점 인덱스 정보 list
    public List<int> listTriangle = new List<int>();

    // UV 정보 list
    public List<Vector2> listUV = new List<Vector2>();

    // 메쉬
    private Mesh mesh;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // 메터리얼 생성
        meshRenderer.material = new Material(Shader.Find("UI/Default"));

        // 메터리얼 설정
        meshRenderer.material.SetColor("_Color", Color.white);
        meshRenderer.material.SetTexture("_MainTex", Resources.Load("Textures/Heart") as Texture);

        // Vertex 정보(색상, UV정보 포함) 적재
        AddVertex(new Vector3(-1, -1, 0), Color.red, new Vector2(0, 0));        ///< 좌하
        AddVertex(new Vector3(1, -1, 0), Color.white, new Vector2(1, 0));      ///< 우하
        AddVertex(new Vector3(-1, 1, 0), Color.white, new Vector2(0, 1));      ///< 좌상
        AddVertex(new Vector3(1, 1, 0), Color.white, new Vector2(1, 1));      ///< 우상

        // Triangle 정보 적재
        AddTriangle(0, 2, 1);
        AddTriangle(2, 3, 1);

        // 매쉬 생성
        ApplyMesh();
    }

    // Vertex 정보(색상, UV정보 포함) 적재
    void AddVertex(Vector3 vtVertex, Color color = default(Color), Vector2 vtUV = default(Vector2))
    {
        listVertex.Add(
            new Vector3(
                transform.position.x + vtVertex.x,
                transform.position.y + vtVertex.y,
                transform.position.z + vtVertex.z));

        listColor.Add(color);

        listUV.Add(vtUV);
    }

    // Triangle 정보 적재
    void AddTriangle(int idx1, int idx2, int idx3)
    {
        listTriangle.Add(idx1);
        listTriangle.Add(idx2);
        listTriangle.Add(idx3);
    }

    void ApplyMesh()
    {
        // 메쉬 데이터 새로 생성
        // Mesh mesh = new Mesh(); 

        // MeshFilter로 부터 메쉬 데이터 획득
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        // 정점정보와 컬러, 인덱스, UV정보 배열을 셋팅
        mesh.vertices = listVertex.ToArray();
        mesh.colors = listColor.ToArray();
        mesh.triangles = listTriangle.ToArray();
        mesh.uv = listUV.ToArray();

        // 노말 벡터 계산
        mesh.RecalculateNormals();

        // MeshFilter에 저장된 메쉬 데이터를 적재
        // GetComponent<MeshFilter>().mesh = mesh;
    }
}