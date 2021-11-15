using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuScreenView : MonoBehaviour
{
    private GameManager gameManager;
    private AudioController audioController;
    private Button button;
    private PlayerControl playerControl;

    public GameObject thisScreen;
    public GameObject gameplayScreen;

    [Inject]
    private void ConstructorLike(GameManager gm, AudioController ac)
    {
        gameManager = gm;
        audioController = ac;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToSwithcScreen);
    }

    public void ToSwithcScreen()
    {
        if (gameplayScreen.activeInHierarchy)
        {
            thisScreen.SetActive(true);
            gameplayScreen.SetActive(false);
            EventsBroker.RestartGame();
            gameManager.UpdateGameState(GameState.menu);
        }
        else
        {
            thisScreen.SetActive(false);
            gameplayScreen.SetActive(true);
            audioController.PlaySoundEffect(SoundEffect.menuTap);
            EventsBroker.GameplayAction();
            gameManager.UpdateGameState(GameState.game);            
        }        
    }
}
