using UnityEngine;


public class FallState : PlayerBaseState
{
    private float deltaTimeCounter;
    private float timeToRestart = 1;

    public override void EnterState(Rigidbody body)
    {
        deltaTimeCounter = 0;
        body.useGravity = true;
    }

    public override void FixedUpdate(Rigidbody body, PlayerControl playerContext)
    {
        deltaTimeCounter += Time.deltaTime;
        if (deltaTimeCounter > timeToRestart)
            EventsBroker.RestartGame();
    }
    
}
