using System;


public static class EventsBroker
{
    //Перезапуск игры
    public static Action OnRestartGame;
    public static void RestartGame()
    {
        OnRestartGame?.Invoke();
    }

    //Переход в главное меню
    public static Action OnGameplay;
    public static void GameplayAction()
    {
        OnGameplay?.Invoke();
    }

    //Изменение статуса игры
    /*public delegate void UpdateStateGameAction(GameState oldState, GameState newState);
    public static event UpdateStateGameAction OnUpdateStateGame;
    public static void UpdateState(GameState oldState, GameState newState)
    {
        OnUpdateStateGame?.Invoke(oldState, newState);
    }*/

}
