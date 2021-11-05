using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystallCounterView : MonoBehaviour
{
    private CrystallCounterController crystallCounterController;

    public Text textCounter;

    public void SetController(CrystallCounterController controller)
    {
        crystallCounterController = controller;
        crystallCounterController.CrystallPickuped();
    }

    public void CrystallPickupEvent()
    {
        crystallCounterController.CrystallPickuped();
    }

    public void UpdateValueOnScreen(int newValue)
    {
        textCounter.text = "Score: " + newValue;
    }
}
