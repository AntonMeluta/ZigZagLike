using System;

public class ModelMVC
{
    private int countCrystalls;

    public Action<int> EventUpdate;
    public Action TapOnScreen;

    public ModelMVC()
    {
        countCrystalls = -1;
    }

    public void ResetValues()
    {
        countCrystalls = 0;
    }

    public void IncrementCrystallCount()
    {
        countCrystalls++;
        EventUpdate?.Invoke(countCrystalls);
        EventUpdate = null;
    }

    public void OnTapSceen()
    {
        TapOnScreen?.Invoke();
        TapOnScreen = null;
    }
}
