using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystallCounterView : MonoBehaviour
{
    private ControllerMVC controllerMVC;

    public Text textCounter;

    private void Start()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        textCounter.text = "Score: " + 0;
    }

    public void SetController(ControllerMVC controller)
    {
        controllerMVC = controller;
        controllerMVC.OnEventUi(this);
    }

    public void CrystallPickupEvent()
    {
        controllerMVC.OnEventUi(this);
    }

    public void UpdateValueOnScreen(int newValue)
    {
        textCounter.text = "Score: " + newValue;
    }
}
