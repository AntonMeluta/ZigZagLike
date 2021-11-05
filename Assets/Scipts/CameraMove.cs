using Zenject;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 deltaToPlayer;
    private Vector3 vectorNew;

    private Transform playerPosition;

    [Inject]
    private void ConstructorLike(PlayerControl player)
    {
        playerPosition = player.transform;
    }

    private void Awake()
    {
        deltaToPlayer = playerPosition.position - transform.position;
    }

    private void LateUpdate()
    {
        vectorNew = playerPosition.position - deltaToPlayer;
        vectorNew.y = transform.position.y;
        transform.position = vectorNew;
    }
}
