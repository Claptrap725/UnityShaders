using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCube : MonoBehaviour
{
    private Mesh customMesh;

    private void OnValidate()
    {
        Start();
    }

    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        var verts = new Vector3[24];

        // front 
        verts[0] = new Vector3(-0.5f, -0.5f, -0.5f);
        verts[1] = new Vector3(-0.5f, 0.5f, -0.5f);
        verts[2] = new Vector3(0.5f, -0.5f, -0.5f);
        verts[3] = new Vector3(0.5f, 0.5f, -0.5f);
        // back
        verts[4] = new Vector3(-0.5f, 0.5f, 0.5f);
        verts[5] = new Vector3(-0.5f, -0.5f, 0.5f);
        verts[6] = new Vector3(0.5f, 0.5f, 0.5f);
        verts[7] = new Vector3(0.5f, -0.5f, 0.5f);
        // top
        verts[8] = new Vector3(-0.5f, 0.5f, -0.5f);
        verts[9] = new Vector3(-0.5f, 0.5f, 0.5f);
        verts[10] = new Vector3(0.5f, 0.5f, -0.5f);
        verts[11] = new Vector3(0.5f, 0.5f, 0.5f);
        // bottem
        verts[12] = new Vector3(-0.5f, -0.5f, 0.5f);
        verts[13] = new Vector3(-0.5f, -0.5f, -0.5f);
        verts[14] = new Vector3(0.5f, -0.5f, 0.5f);
        verts[15] = new Vector3(0.5f, -0.5f, -0.5f);
        // right
        verts[16] = new Vector3(0.5f, -0.5f, 0.5f);
        verts[17] = new Vector3(0.5f, -0.5f, -0.5f);
        verts[18] = new Vector3(0.5f, 0.5f, 0.5f);
        verts[19] = new Vector3(0.5f, 0.5f, -0.5f);
        // left
        verts[20] = new Vector3(-0.5f, -0.5f, -0.5f);
        verts[21] = new Vector3(-0.5f, -0.5f, 0.5f);
        verts[22] = new Vector3(-0.5f, 0.5f, -0.5f);
        verts[23] = new Vector3(-0.5f, 0.5f, 0.5f); 

        mesh.vertices = verts;

        // Indices
        // determines which vertices make up an individual triangle
        // this should always be a multiple of three
        // each triangle should be specified in _clock-wise_ order
        var indices = new int[36];

        for (int i = 0; i < 6; i++)
        {
            indices[0 + i * 6] = 0 + i * 4;
            indices[1 + i * 6] = 1 + i * 4;
            indices[2 + i * 6] = 2 + i * 4;
            indices[3 + i * 6] = 3 + i * 4;
            indices[4 + i * 6] = 2 + i * 4;
            indices[5 + i * 6] = 1 + i * 4;
        }
        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        var norms = new Vector3[24];

        for (int i = 0; i < 4; i++)
            norms[i] = Vector3.back;
        for (int i = 0; i < 4; i++)
            norms[i + 4] = Vector3.forward;
        for (int i = 0; i < 4; i++)
            norms[i + 8] = Vector3.up;
        for (int i = 0; i < 4; i++)
            norms[i + 12] = Vector3.down;
        for (int i = 0; i < 4; i++)
            norms[i + 16] = Vector3.right;
        for (int i = 0; i < 4; i++)
            norms[i + 20] = Vector3.left;

        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        var UVs = new Vector2[24];
        // front
        UVs[0] = new Vector2(0.375f, 0.5f);
        UVs[1] = new Vector2(0.375f, 0.25f);
        UVs[2] = new Vector2(0.625f, 0.5f);
        UVs[3] = new Vector2(0.625f, 0.25f);
        // back
        UVs[4] = new Vector2(0.625f, 1.0f);
        UVs[5] = new Vector2(0.625f, 0.75f);
        UVs[6] = new Vector2(0.375f, 1.0f);
        UVs[7] = new Vector2(0.375f, 0.75f);
        // top
        UVs[8] = new Vector2(0.625f, 0.25f);
        UVs[9] = new Vector2(0.625f, 0.0f);
        UVs[10] = new Vector2(0.375f, 0.25f);
        UVs[11] = new Vector2(0.375f, 0.0f);
        // bottem
        UVs[12] = new Vector2(0.625f, 0.75f);
        UVs[13] = new Vector2(0.625f, 0.5f);
        UVs[14] = new Vector2(0.375f, 0.75f);
        UVs[15] = new Vector2(0.375f, 0.5f);
        // right
        UVs[16] = new Vector2(0.875f, 0.5f);
        UVs[17] = new Vector2(0.625f, 0.5f);
        UVs[18] = new Vector2(0.875f, 0.75f);
        UVs[19] = new Vector2(0.625f, 0.75f);
        // left
        UVs[20] = new Vector2(0.375f, 0.5f);
        UVs[21] = new Vector2(0.125f, 0.5f);
        UVs[22] = new Vector2(0.375f, 0.75f);
        UVs[23] = new Vector2(0.125f, 0.75f);

        mesh.uv = UVs;

        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
        customMesh = mesh;
    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }
}
