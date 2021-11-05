using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Rigidbody body);

    public abstract void FixedUpdate(Transform transform, PlayerControl playerContext, Rigidbody body);

    //public abstract void OnCollisionExit(PlayerControl playerContext);
}
