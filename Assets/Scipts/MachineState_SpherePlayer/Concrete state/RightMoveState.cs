using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMoveState : PlayerBaseState
{
    private float distanceRay = 50;

    public override void EnterState(Rigidbody body)
    {
        body.isKinematic = false;
        body.useGravity = true;
    }

    public override void FixedUpdate(Transform pos, PlayerControl playerContext, Rigidbody body)
    {
        RaycastHit hit;
        if (Physics.Raycast(body.position, pos.TransformDirection(Vector3.down), out hit))
        {
            body.velocity = Vector3.right * playerContext.speedSphere;
        }
        else
        {
            playerContext.SendSoundFell();
            playerContext.TransitionToState(playerContext.fallState);
        }
    }
    
}
