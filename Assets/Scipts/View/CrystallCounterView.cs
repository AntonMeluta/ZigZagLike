using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystallCounterView : MonoBehaviour
{
    private int counterCrystalls;
    public Text textCounter;

    private void Start()
    {
        counterCrystalls = 0;
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void RestartGame()
    {
        counterCrystalls = 0;
        textCounter.text = "Score: " + counterCrystalls;
    }

    public void UpdateValueOnScreen()
    {
        counterCrystalls++;
        textCounter.text = "Score: " + counterCrystalls;
    }
}
