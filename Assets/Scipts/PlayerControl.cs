using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool isForwardMove;
    private Vector3 targetVelocity;

    public float speedSphere = 2;

    private void OnEnable()
    {
        EventsBroker.RestartGameAction += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.RestartGameAction -= RestartGame;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isForwardMove = true;
        targetVelocity = Vector3.forward;
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
        rb.velocity = targetVelocity * speedSphere;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            UpdateVectorMoving();
    }

    public void UpdateVectorMoving()
    {
        isForwardMove = !isForwardMove;
        if (isForwardMove)
        {
            //targetVelocity = (globalForwardTarget.position - transform.position).normalized;
            targetVelocity = Vector3.forward;
        }
        else
        {
            //targetVelocity = (globalRightTarget.position - transform.position).normalized;
            targetVelocity = Vector3.right;

        }
    }
}
