using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour
{
    private Rigidbody body;

    public Renderer rightPointSpawn;
    public Renderer forwardPointSpawn;

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
        body.isKinematic = false;
    }
}
