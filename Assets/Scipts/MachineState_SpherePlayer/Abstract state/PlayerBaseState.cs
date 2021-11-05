using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Rigidbody body);

    public abstract void FixedUpdate(Rigidbody body, PlayerControl playerContext);

    //public abstract void OnCollisionExit(PlayerControl playerContext);
}
