using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallCounterModel
{
    private int countCrystalls;

    public Action<int> EventUpdate;

    public CrystallCounterModel()
    {
        countCrystalls = -1;
    }

    public void SkipValue()
    {
        countCrystalls = 0;
        EventUpdate?.Invoke(countCrystalls);
    }

    public void IncrementCrystallCount()
    {
        countCrystalls++;
        EventUpdate?.Invoke(countCrystalls);
    }
}
