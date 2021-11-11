using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameState currentState;

    public GameSettings_SO gameSettings;

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void Start()
    {
        UpdateGameState(GameState.menu);
    }

    private void RestartGame()
    {
        UpdateGameState(GameState.menu);
    }
    
    //Загрузка всех сохранённых данных из реестра
    /*private void InitGameData()
    {
        StatsManager.LoadResult();
        StatsManager.LoadСomplexityValue();
    }*/

    //Глобальная точка входа для работы с изменением состояния игры
    public void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.menu:
                Time.timeScale = 1;
                break;
            case GameState.game:
                Time.timeScale = 1;                
                break;
            default:
                break;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.R))
            EventsBroker.OnRestartGame();
    }

}
