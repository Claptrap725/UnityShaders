using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshStepper : MonoBehaviour
{
    private void Start()
    {
        var mesh = GetComponent<MeshFilter>().mesh;

        var sub = mesh.GetSubMesh(0);
       
    }
}
