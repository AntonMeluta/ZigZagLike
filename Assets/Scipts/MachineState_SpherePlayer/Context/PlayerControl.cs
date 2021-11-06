using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private TileSpawner tileSpawner;
    private GameManager gameManager;
    private MenuScreenView menuScreenView;
    private CrystallCounterView crystallCounterView;

    private bool isForwardMove;
    private Vector3 targetVelocity;

    private PlayerBaseState currentState;
    public readonly PlayerBaseState rightMoveState = new RightMoveState();
    public readonly PlayerBaseState forwardMoveState = new ForwardMoveState();
    public readonly PlayerBaseState fallState = new FallState();

    public float speedSphere = 2;

    [Inject]
    private void ConstructorLike(TileSpawner spawner, GameManager manager, 
        MenuScreenView menuView, CrystallCounterView crystallView)
    {
        gameManager = manager;
        tileSpawner = spawner;
        menuScreenView = menuView;
        crystallCounterView = crystallView;
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
        speedSphere = gameManager.gameSettings.speedPlayer;
        TransitionToState(forwardMoveState);        
    }

    private void RestartGame()
    {
        InstallPosition();
        TransitionToState(forwardMoveState);
    }

    public void PlayerFell()
    {
        EventsBroker.RestartGame();
        menuScreenView.ToSwithcScreen();
    }

    public void InstallPosition()
    {
        float deltaY = 3.1f;
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
            crystallCounterView.CrystallPickupEvent();
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
