using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingUV : MonoBehaviour
{
    
    public Vector2 movement;
    Mesh OldMesh;
    Mesh mesh;
    MeshFilter filter;


    private void Start()
    {
        filter = GetComponent<MeshFilter>();
        OldMesh = filter.sharedMesh;
        mesh = filter.mesh;
    }

    private void Update()
    {
        var UVs = new Vector2[mesh.vertexCount];
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            UVs[i] = movement * Time.deltaTime * 0.1f + mesh.uv[i];
        }

        mesh.uv = UVs;
    }

    private void OnDisable()
    {
        Destroy(mesh);
        filter.mesh = OldMesh;
    }
}
