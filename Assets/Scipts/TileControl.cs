using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TileControl : MonoBehaviour
{
    private Rigidbody body;
    private TileSpawner tileSpawner;

    public Renderer rightPointSpawn;
    public Renderer forwardPointSpawn;

    [Inject]
    private void ConstructorLike(TileSpawner spawner)
    {
        tileSpawner = spawner;
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void RestartGame()
    {
        body.isKinematic = true;
    }

    private void OnTriggerExit(Collider other)
    {
        float timeToDisable = 1.5f;
        body.isKinematic = false;
        //Invoke("DisableAction", timeToDisable);
    }

    private void DisableAction()
    {
        //tileSpawner.
    }
}
