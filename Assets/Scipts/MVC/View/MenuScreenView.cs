using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuScreenView : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    private ControllerMVC controllerMVC;

    public GameObject thisScreen;
    public GameObject gameplayScreen;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
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

    public void ToSwithcScreen()
    {
        if (gameplayScreen.activeInHierarchy)
        {
            thisScreen.SetActive(true);
            gameplayScreen.SetActive(false);
            gameManager.UpdateGameState(GameState.menu);
        }
        else
        {
            thisScreen.SetActive(false);
            gameplayScreen.SetActive(true);
            gameManager.UpdateGameState(GameState.game);
        }        
    }
}
