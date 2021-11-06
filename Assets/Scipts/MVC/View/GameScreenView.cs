using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameScreenView : MonoBehaviour
{
    private GameManager gamManager;
    private Button button;
    private GameScreenController gameScreenController;
    private PlayerControl playerControl;    

    [Inject]
    private void ConstructorLike(PlayerControl pc)
    {
        playerControl = pc;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickUser);
    }

    public void SetController(GameScreenController controller)
    {
        gameScreenController = controller;
    }

    public void OnClickUser()
    {
        gameScreenController.UserTap();
    }

    public void UpdateVelocityPlayer()
    {
        playerControl.UpdateVectorMoving();
    }
}
