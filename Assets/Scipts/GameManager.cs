using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameState currentState = GameState.menu;

    private void Start()
    {
        UpdateGameState(GameState.game);
    }
    
    //�������� ���� ���������� ������ �� �������
    /*private void InitGameData()
    {
        StatsManager.LoadResult();
        StatsManager.Load�omplexityValue();
    }*/

    //���������� ����� ����� ��� ������ � ���������� ��������� ����
    public void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.menu:
                Time.timeScale = 0;
                break;
            case GameState.game:
                Time.timeScale = 1;                
                break;
            default:
                break;
        }

        EventsBroker.UpdateState(prevGameState, currentState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Time.timeScale = (Time.timeScale == 1) ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.R))
            EventsBroker.OnRestartGame();
    }

}
