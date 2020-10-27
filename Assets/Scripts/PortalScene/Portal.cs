using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects;

public class Portal : MonoBehaviour
{
    public Portal link;
    public Transform lastObj;
    public float teleportOffset = 0.3f;
    Vector3 pos;
    bool cooldown;

    private void Start()
    {
        pos = link.transform.position - transform.position;
        pos = pos.normalized * (pos.magnitude - teleportOffset);
    }

    private void FixedUpdate()
    {
        cooldown = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerEnter(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnTriggerExit(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!cooldown)
        {
            Transform top = other.transform;
            while (top.transform.parent != null)
                top = top.transform.parent;

            if (lastObj != top)
            {
                SimpleCameraController camera = top.GetComponentInParent<SimpleCameraController>();
                if (camera != null)
                {
                    camera.m_TargetCameraState.x += pos.x;
                    camera.m_TargetCameraState.y += pos.y;
                    camera.m_TargetCameraState.z += pos.z;
                }
                else
                    top.position += pos;
                link.lastObj = top;
                cooldown = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Transform top = other.transform;
        while (top.transform.parent != null)
            top = top.transform.parent;

        if (lastObj == top)
            lastObj = null;
    }
    
}
