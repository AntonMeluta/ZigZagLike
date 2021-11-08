using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMVC
{
    private ModelMVC modelMVC;

    public ControllerMVC(ModelMVC model)
    {
        modelMVC = model;
        EventsBroker.OnRestartGame += ResetValuesInModels;
    }

    private void ResetValuesInModels()
    {

    }

    public void OnEventUi(CrystallCounterView view)
    {
        modelMVC.EventUpdate += view.UpdateValueOnScreen;
        modelMVC.IncrementCrystallCount();
        Debug.Log("OnEventUi(CrystallCounterView view)");
    }

    public void OnEventUi(GameScreenView view)
    {
        modelMVC.TapOnScreen += view.UpdateVelocityPlayer;
        modelMVC.OnTapSceen();
        Debug.Log("OnEventUi(GameScreenView view)");
    }

    public void OnEventUi(MenuScreenView view)
    {
        modelMVC.TapOnScreen += view.ToSwithcScreen;
        modelMVC.OnTapSceen();
        Debug.Log("OnEventUi(MenuScreenView view)");
    }

}
