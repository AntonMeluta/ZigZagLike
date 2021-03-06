using UnityEngine;


public class FallState : PlayerBaseState
{
    private float deltaTimeCounter;
    private float timeToRestart = 1;

    public override void EnterState(Rigidbody body)
    {
        deltaTimeCounter = 0;
        body.isKinematic = false;
        body.useGravity = true;
    }

    public override void FixedUpdate(Transform pos, PlayerControl playerContext, Rigidbody body)
    {
        deltaTimeCounter += Time.deltaTime;
        //body.velocity = Vector3.down * playerContext.speedSphere * 2;
        if (deltaTimeCounter > timeToRestart)
            playerContext.PlayerFell();
    }
    
}
