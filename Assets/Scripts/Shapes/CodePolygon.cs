using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePolygon : MonoBehaviour
{
    [Range(3,40)]
    public int sides = 6;
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
        var verts = new Vector3[1 + sides];

        verts[0] = new Vector3(0, 0, 0);

        for (int i = 0; i < sides; i++)
        {
            verts[i+1] = DegreesToVector(i*(360f/sides)) * 0.5f;
        }
        mesh.vertices = verts;

        // Indices
        // determines which vertices make up an individual triangle
        // this should always be a multiple of three
        // each triangle should be specified in _clock-wise_ order
        var indices = new int[3 * sides];

        for (int i = 0; i < sides; i++)
        {
            if (i + 1 < sides)
                indices[0 + i * 3] = 2 + i;
            else
                indices[0 + i * 3] = 1;

            indices[1 + i * 3] = 1 + i;
            indices[2 + i * 3] = 0;
        }



        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        // note that this data is interpolated across the surface of the triangle
        var norms = new Vector3[1 + sides];

        for (int i = 0; i < 1 + sides; i++)
            norms[i] = -Vector3.forward;
        

        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        var UVs = new Vector2[1 + sides];

        for (int i = 0; i < 1 + sides; i++)
            UVs[i] = verts[i] + new Vector3(0.5f, 0.5f);


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

    public static Vector2 DegreesToVector(float degrees)
    {
        return new Vector2(Mathf.Cos(degrees * Mathf.Deg2Rad), Mathf.Sin(degrees * Mathf.Deg2Rad));
    }
}
