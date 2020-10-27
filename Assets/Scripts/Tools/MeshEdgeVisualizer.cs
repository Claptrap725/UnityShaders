using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEdgeVisualizer : MonoBehaviour
{
    public bool draw = true;

    private void OnDrawGizmos()
    {
        if (!draw) return;

        Mesh mesh;
        var filter = GetComponent<MeshFilter>();
        mesh = filter.sharedMesh;

        Gizmos.color = Color.cyan + new Color(0, 0, 0, -0.5f);
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Gizmos.DrawLine(mesh.vertices[mesh.triangles[i]] + transform.position, mesh.vertices[mesh.triangles[i + 1]] + transform.position);
            Gizmos.DrawLine(mesh.vertices[mesh.triangles[i + 1]] + transform.position, mesh.vertices[mesh.triangles[i + 2]] + transform.position);
            Gizmos.DrawLine(mesh.vertices[mesh.triangles[i + 2]] + transform.position, mesh.vertices[mesh.triangles[i]] + transform.position);
        }
    }
}
