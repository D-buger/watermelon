using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TestCircle : MonoBehaviour
{
    public float radius;
    public Sprite sprite;
    public Color color;

    private MeshFilter meshRenderer;

    public bool isSprite = true;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshFilter>();
        isSprite = sprite == null ? false : true;
    }

    void Start()
    {
        Mesh mesh = new Mesh();
        if (isSprite)
            mesh = Meshes.SpriteCircleMesh(Vector2.zero, new Vector2(radius, 0), sprite);
        else
            mesh = Meshes.ColorCircleMesh(Vector2.zero, new Vector2(radius, 0), color);

        if(isSprite)
            gameObject.GetComponent<Renderer>().material.mainTexture = sprite.texture;
        

        meshRenderer.mesh = mesh;
    }
}
