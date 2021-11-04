using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForTilesControl : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = player.position;
    }
}
