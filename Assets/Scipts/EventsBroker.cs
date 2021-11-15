using System;


public static class EventsBroker
{
    //���������� ����
    public static Action OnRestartGame;
    public static void RestartGame()
    {
        OnRestartGame?.Invoke();
    }

    //������� � ������� ����
    public static Action OnGameplay;
    public static void GameplayAction()
    {
        OnGameplay?.Invoke();
    }

    //��������� ������� ����
    /*public delegate void UpdateStateGameAction(GameState oldState, GameState newState);
    public static event UpdateStateGameAction OnUpdateStateGame;
    public static void UpdateState(GameState oldState, GameState newState)
    {
        OnUpdateStateGame?.Invoke(oldState, newState);
    }*/

}
