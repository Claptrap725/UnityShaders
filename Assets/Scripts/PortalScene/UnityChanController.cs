using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    private float idleTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Pain");
            animator.SetFloat("WalkSpeed", 0);
            animator.SetFloat("IdleTime", 0);
            return;
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("pain"))
        {
            Vector3 movement = Vector3.zero;

            if (!Input.GetMouseButton(1))
            {
                if (Input.GetKey(KeyCode.W))
                    movement += new Vector3(0, 0, 1);
                if (Input.GetKey(KeyCode.S))
                    movement += new Vector3(0, 0, -1);
                if (Input.GetKey(KeyCode.A))
                    movement += new Vector3(-1, 0, 0);
                if (Input.GetKey(KeyCode.D))
                    movement += new Vector3(1, 0, 0);
            }

            movement.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
                movement *= 4;
            else
                movement *= 2;

            animator.SetFloat("WalkSpeed", movement.magnitude / 2);

            if (movement != Vector3.zero)
            {
                transform.eulerAngles = new Vector3(0, Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg, 0);
                transform.position += movement * Time.fixedDeltaTime;
                idleTimer = 0;
            }
            else
            {
                idleTimer += Time.fixedDeltaTime;
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("IdleAnim"))
                    idleTimer = 0;
            }

            animator.SetFloat("IdleTime", idleTimer);
        }
    }
}
