using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PortalCamera : MonoBehaviour
{
    public Transform portal;
    public float FOVScale = 1;
    Camera cam;

    private void OnEnable()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        cam.fieldOfView = (1 / (Vector3.Distance(portal.position, Camera.main.transform.position) + 1)) * FOVScale;
        transform.forward = (portal.position - Camera.main.transform.position).normalized;
    }
}
