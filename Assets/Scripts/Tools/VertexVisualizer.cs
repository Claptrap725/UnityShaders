using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexVisualizer : MonoBehaviour
{
    public bool draw = true;

    private void OnDrawGizmos()
    {
        if (!draw) return;

        Mesh mesh;
        var filter = GetComponent<MeshFilter>();
        mesh = filter.sharedMesh;

        Gizmos.color = Color.green + new Color(0, 0, 0, -0.5f);
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            Vector3 pos = transform.position + mesh.vertices[i];
            Gizmos.DrawSphere(pos, 0.03f);
        }
    }
}
