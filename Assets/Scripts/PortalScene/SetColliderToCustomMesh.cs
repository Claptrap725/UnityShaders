using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
public class SetColliderToCustomMesh : MonoBehaviour
{
    MeshCollider meshCollider;
    MeshFilter meshFilter;

    private void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        meshCollider.sharedMesh = meshFilter.sharedMesh;
    }
}
