using System;


public static class EventsBroker
{
    public static Action RestartGameAction;
    public static void OnRestartGame()
    {
        RestartGameAction?.Invoke();
    }
}
