using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    private void OnTriggerExit(Collider other)
    {
        float timeToDisable = 1;
        body.isKinematic = false;
        Invoke("DisableAction", timeToDisable);
    }

    private void DisableAction()
    {
        gameObject.SetActive(false);
    }
}
