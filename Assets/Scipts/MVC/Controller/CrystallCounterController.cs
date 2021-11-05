using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallCounterController
{
    private CrystallCounterModel crystallCounterModel;

    public CrystallCounterController(CrystallCounterModel model)
    {
        crystallCounterModel = model;
    }

    public void CrystallPickuped()
    {
        crystallCounterModel.IncrementCrystallCount();
    }
}
