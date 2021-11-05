using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TriggerTilesFall : MonoBehaviour
{
    private Transform playerPosition;

    [Inject]
    private void ConstructorLike(PlayerControl player)
    {
        playerPosition = player.transform;
    }

    private void Update()
    {
        transform.position = playerPosition.position;
    }
}
