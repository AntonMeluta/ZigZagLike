using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTilesFall : MonoBehaviour
{
    public Transform player;
    
    private void Update()
    {
        transform.position = player.position;
    }
}
