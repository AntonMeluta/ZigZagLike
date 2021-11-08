using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameScreenView : MonoBehaviour
{
    private GameManager gamManager;
    private Button button;
    private ControllerMVC controllerMVC;
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

    public void SetController(ControllerMVC controller)
    {
        controllerMVC = controller;
    }

    public void OnClickUser()
    {
        controllerMVC.OnEventUi(this);
    }

    public void UpdateVelocityPlayer()
    {
        playerControl.UpdateVectorMoving();
    }
}
