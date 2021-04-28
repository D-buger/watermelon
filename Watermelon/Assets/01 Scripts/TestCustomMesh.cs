using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Unity������ opengló�� GL_TRIANGLE_STRIP, GL_TRIANGLE_FAN�� �������� �ʴµ���.
// ����. GL_TRIANGLES �ﰢ�� ���ո� �����ϴ°���.

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class TestCustomMesh : MonoBehaviour
{
    // ���ؽ� list
    public List<Vector3> listVertex = new List<Vector3>();

    // ���� ���� list
    public List<Color> listColor = new List<Color>();

    // ���� �ε��� ���� list
    public List<int> listTriangle = new List<int>();

    // UV ���� list
    public List<Vector2> listUV = new List<Vector2>();

    // �޽�
    private Mesh mesh;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // ���͸��� ����
        meshRenderer.material = new Material(Shader.Find("UI/Default"));

        // ���͸��� ����
        meshRenderer.material.SetColor("_Color", Color.white);
        meshRenderer.material.SetTexture("_MainTex", Resources.Load("Textures/Heart") as Texture);

        // Vertex ����(����, UV���� ����) ����
        AddVertex(new Vector3(-1, -1, 0), Color.red, new Vector2(0, 0));        ///< ����
        AddVertex(new Vector3(1, -1, 0), Color.white, new Vector2(1, 0));      ///< ����
        AddVertex(new Vector3(-1, 1, 0), Color.white, new Vector2(0, 1));      ///< �»�
        AddVertex(new Vector3(1, 1, 0), Color.white, new Vector2(1, 1));      ///< ���

        // Triangle ���� ����
        AddTriangle(0, 2, 1);
        AddTriangle(2, 3, 1);

        // �Ž� ����
        ApplyMesh();
    }

    // Vertex ����(����, UV���� ����) ����
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

    // Triangle ���� ����
    void AddTriangle(int idx1, int idx2, int idx3)
    {
        listTriangle.Add(idx1);
        listTriangle.Add(idx2);
        listTriangle.Add(idx3);
    }

    void ApplyMesh()
    {
        // �޽� ������ ���� ����
        // Mesh mesh = new Mesh(); 

        // MeshFilter�� ���� �޽� ������ ȹ��
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        // ���������� �÷�, �ε���, UV���� �迭�� ����
        mesh.vertices = listVertex.ToArray();
        mesh.colors = listColor.ToArray();
        mesh.triangles = listTriangle.ToArray();
        mesh.uv = listUV.ToArray();

        // �븻 ���� ���
        mesh.RecalculateNormals();

        // MeshFilter�� ����� �޽� �����͸� ����
        // GetComponent<MeshFilter>().mesh = mesh;
    }
}