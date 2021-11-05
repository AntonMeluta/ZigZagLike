using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private TileSpawner tileSpawner;
    private GameManager gameManager;

    private bool isForwardMove;
    private Vector3 targetVelocity;

    private PlayerBaseState currentState;
    public readonly PlayerBaseState rightMoveState = new RightMoveState();
    public readonly PlayerBaseState forwardMoveState = new ForwardMoveState();
    public readonly PlayerBaseState fallState = new FallState();

    public float speedSphere = 2;

    [Inject]
    private void ConstructorLike(TileSpawner spawner, GameManager manager)
    {
        gameManager = manager;
        tileSpawner = spawner;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
        InstallPosition();
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
        InstallPosition();
        TransitionToState(forwardMoveState);
    }

    public void PlayerFell()
    {
        //gameManager.
        EventsBroker.RestartGame();
    }

    public void InstallPosition()
    {
        float deltaY = 3.1f;
        //Vector3 vectorSpawnOnStart = tileSpawner.GetPoinSpawn().position;
        Vector3 vectorSpawnOnStart = Vector3.zero;
        vectorSpawnOnStart.y += deltaY;
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
        currentState.FixedUpdate(transform, this, rb);
    }

    private void Update()
    {
        print("currentState = " + currentState.ToString());
        if (Input.GetMouseButtonDown(0))
            UpdateVectorMoving();
    }
    
    public void UpdateVectorMoving()
    {
        TransitionToState(currentState = (currentState == forwardMoveState) 
            ? rightMoveState : forwardMoveState);
    }
}
