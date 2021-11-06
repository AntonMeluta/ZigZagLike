using System;

public class GameScreenModel
{
    public Action TapOnScreen;

    public void OnTapScreen()
    {
        TapOnScreen?.Invoke();
    }
}
