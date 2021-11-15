using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameScreenView : MonoBehaviour
{
    private GameManager gamManager;
    private Button button;
    private PlayerControl playerControl;    

    [Inject]
    private void ConstructorLike(PlayerControl pc, AudioController ac)
    {
        playerControl = pc;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UpdateVelocityPlayer);
    }

    public void UpdateVelocityPlayer()
    {
        playerControl.UpdateVectorMoving();
    }
}
