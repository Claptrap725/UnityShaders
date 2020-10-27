using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVVisualizer : MonoBehaviour
{
    public bool draw = true;

    private void OnDrawGizmos()
    {
        if (!draw) return;

        Mesh mesh;
        var filter = GetComponent<MeshFilter>();
        mesh = filter.sharedMesh;

        Gizmos.color = Color.red;
        for (int i = 0; i < mesh.uv.Length; i++)
        {
            Vector3 pos = transform.position + (Vector3)mesh.uv[i];
            Gizmos.DrawSphere(pos + new Vector3(-0.5f, -0.5f), 0.01f);
        }
    }
}
