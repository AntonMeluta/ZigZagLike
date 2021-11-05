using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMoveState : PlayerBaseState
{
    private float distanceRay = 10;

    public override void EnterState(Rigidbody body)
    {
        body.useGravity = false;
    }

    public override void FixedUpdate(Rigidbody body, PlayerControl playerContext)
    {
        RaycastHit hit;
        if (Physics.Raycast(body.position, Vector3.down, out hit, distanceRay))
        {
            body.velocity = Vector3.forward * playerContext.speedSphere;
        }
        else
        {
            playerContext.TransitionToState(playerContext.fallState);
        }
    }
    
}
