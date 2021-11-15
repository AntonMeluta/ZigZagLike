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
    private DataManager dataManager;
    private AudioController audioController;

    private bool isForwardMove;
    private Vector3 targetVelocity;

    private PlayerBaseState currentState;
    public readonly PlayerBaseState rightMoveState = new RightMoveState();
    public readonly PlayerBaseState forwardMoveState = new ForwardMoveState();
    public readonly PlayerBaseState fallState = new FallState(); 
    public readonly PlayerBaseState idleState = new IdleState();

    public float speedSphere = 2;

    [Inject]
    private void ConstructorLike(TileSpawner spawner, GameManager manager, 
        MenuScreenView menuView, CrystallCounterView crystallView,
        DataManager dm, AudioController ac)
    {
        gameManager = manager;
        tileSpawner = spawner;
        menuScreenView = menuView;
        crystallCounterView = crystallView;
        dataManager = dm;
        audioController = ac;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
        EventsBroker.OnGameplay += ActionGameplay;
        InstallPosition();
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
        EventsBroker.OnGameplay -= ActionGameplay;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedSphere = gameManager.gameSettings.speedPlayer;
        TransitionToState(idleState);        
    }

    private void RestartGame()
    {
        InstallPosition();        
        TransitionToState(idleState);
    }

    private void ActionGameplay()
    {
        speedSphere = gameManager.gameSettings.speedPlayer;
        TransitionToState(forwardMoveState);
    }

    public void SendSoundFell()
    {
        audioController.PlaySoundEffect(SoundEffect.LossSound);
    }
    
    public void PlayerFell()
    {
        TransitionToState(idleState);        
        dataManager.SaveCountSessions();
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
            crystallCounterView.UpdateValueOnScreen();
            audioController.PlaySoundEffect(SoundEffect.PickupCrystall);
            other.GetComponent<CrystallControl>().CollisionWithPlayer();
        }
    }
    
    private void FixedUpdate()
    {
        currentState.FixedUpdate(transform, this, rb);
    }
    
    public void UpdateVectorMoving()
    {
        if (currentState == idleState || currentState == fallState)
            return;

        PlayerBaseState nextState = (currentState == forwardMoveState)
            ? rightMoveState : forwardMoveState;
        TransitionToState(nextState);
        audioController.PlaySoundEffect(SoundEffect.movePlayer);
    }
}
