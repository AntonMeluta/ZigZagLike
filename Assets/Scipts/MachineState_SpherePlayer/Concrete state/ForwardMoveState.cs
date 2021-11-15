using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMoveState : PlayerBaseState
{
    public override void EnterState(Rigidbody body)
    {
        body.isKinematic = false;
        body.useGravity = true;
    }

    public override void FixedUpdate(Transform pos, PlayerControl playerContext, Rigidbody body)
    {
        RaycastHit hit;
        if (Physics.Raycast(pos.position, pos.TransformDirection(Vector3.down), out hit))
        {
            body.velocity = Vector3.forward * playerContext.speedSphere;
        }
        else
        {
            playerContext.SendSoundFell();
            playerContext.TransitionToState(playerContext.fallState);
        }
    }
    
}
