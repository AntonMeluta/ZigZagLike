using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 deltaToPlayer;
    private Vector3 vectorNew;

    public Transform player;
    
    private void Awake()
    {
        deltaToPlayer = player.position - transform.position;
    }

    private void LateUpdate()
    {
        vectorNew = player.position - deltaToPlayer;
        vectorNew.y = transform.position.y;
        transform.position = vectorNew;
    }
}
