using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{

    public override void EnterState(Rigidbody body)
    {
        body.isKinematic = true;
        body.useGravity = false;
    }

    public override void FixedUpdate(Transform pos, PlayerControl playerContext, Rigidbody body)
    {
        
    }

}
