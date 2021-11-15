using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CrystallCounterView : MonoBehaviour
{
    private int counterCrystalls;
    private DataManager dataManager;

    public Text textCounter;

    [Inject]
    private void ConstructorLike(DataManager dm)
    {
        dataManager = dm;
    }

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
        dataManager.SaveScore(counterCrystalls);
    }
}
