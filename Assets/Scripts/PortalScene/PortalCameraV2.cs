using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PortalCameraV2 : MonoBehaviour
{
    public Transform portal;
    public float FOVScale = 1;
    public float FOVOffset = 1;
    public float NearPlaneOffset = 0;
    Camera cam;

    private void OnEnable()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        transform.forward = (portal.position - Camera.main.transform.position).normalized;

        float disToPortal = Vector3.Distance(portal.position, Camera.main.transform.position);
        Vector3 localForward = transform.parent.InverseTransformDirection(transform.forward);
        transform.localPosition = -localForward * disToPortal;

        float disToParent = Vector3.Distance(transform.parent.position, transform.position);
        cam.nearClipPlane = disToParent + NearPlaneOffset;
        if (cam.nearClipPlane < 0.01f)
            cam.nearClipPlane = 0.01f;

        cam.fieldOfView = (1 / (disToPortal + FOVOffset)) * FOVScale;
    }
}
