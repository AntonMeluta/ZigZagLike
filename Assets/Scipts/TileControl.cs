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
        //tileSpawner = spawner;
        print("ConstructorLike(TileSpawner spawner)");
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;
    }

    private void OnEnable()
    {
        body.isKinematic = true;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Start()
    {
        tileSpawner = FindObjectOfType<TileSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        float timeToDisable = 1;
        body.isKinematic = false;
        Invoke("DisableAction", timeToDisable);
    }

    private void DisableAction()
    {
        gameObject.SetActive(false);
        tileSpawner.RemoveTileFromList(this);
    }
}
