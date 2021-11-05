using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMoveState : PlayerBaseState
{
    public override void EnterState(Rigidbody body)
    {
        
    }

    public override void FixedUpdate(Transform pos, PlayerControl playerContext, Rigidbody body)
    {
        RaycastHit hit;
        if (Physics.Raycast(pos.position, pos.TransformDirection(Vector3.down), out hit))
        {
            Debug.DrawLine(pos.position, pos.TransformDirection(Vector3.down), Color.yellow);
            body.velocity = Vector3.forward * playerContext.speedSphere;
        }
        else
        {
            Debug.DrawLine(pos.position, pos.TransformDirection(Vector3.down), Color.red);
            playerContext.TransitionToState(playerContext.fallState);
        }
    }
    
}
