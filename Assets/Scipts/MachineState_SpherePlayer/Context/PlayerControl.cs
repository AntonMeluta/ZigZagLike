using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool isForwardMove;
    private Vector3 targetVelocity;

    private PlayerBaseState currentState;
    public readonly PlayerBaseState rightMoveState = new RightMoveState();
    public readonly PlayerBaseState forwardMoveState = new ForwardMoveState();
    public readonly PlayerBaseState fallState = new FallState();

    public float speedSphere = 2;
    public GameManager gameManager;

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TransitionToState(forwardMoveState);        
    }

    private void RestartGame()
    {
        isForwardMove = true;
        targetVelocity = Vector3.forward;
    }

    public void GetPointSpawn(Transform tileTransform)
    {
        Vector3 vectorSpawnOnStart = tileTransform.position;
        vectorSpawnOnStart.y += 3;
        transform.position = vectorSpawnOnStart;
    }

    public void TransitionToState(PlayerBaseState state)
    {
        if (currentState == state)
            return;

        currentState = state;
        currentState.EnterState(rb);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CrystallControl>())
        {
            print("—Œ¡–¿À»  –»—“¿ÀÀ, œ≈–≈ƒ¿“‹ ÀŒ√» ” ¬Œ VIEW MVC");
            other.GetComponent<CrystallControl>().CollisionWithPlayer();
        }
    }
    
    private void FixedUpdate()
    {
        currentState.FixedUpdate(rb, this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            UpdateVectorMoving();
    }
    
    public void UpdateVectorMoving()
    {
        TransitionToState(currentState = (currentState == forwardMoveState) 
            ? rightMoveState : forwardMoveState);
    }
}
