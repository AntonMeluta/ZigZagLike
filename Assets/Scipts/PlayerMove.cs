using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private bool isForwardMove;
    private Vector3 targetVelocity;

    public float speedSphere = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isForwardMove = true;
        targetVelocity = Vector3.forward;
    }


    private void FixedUpdate()
    {
        rb.velocity = targetVelocity * speedSphere;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            UpdateVectorMoving();
    }

    public void UpdateVectorMoving()
    {
        isForwardMove = !isForwardMove;
        if (isForwardMove)
        {
            //targetVelocity = (globalForwardTarget.position - transform.position).normalized;
            targetVelocity = Vector3.forward;
        }
        else
        {
            //targetVelocity = (globalRightTarget.position - transform.position).normalized;
            targetVelocity = Vector3.right;

        }
    }
}
