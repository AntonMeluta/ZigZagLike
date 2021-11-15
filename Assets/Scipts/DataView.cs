using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DataView : MonoBehaviour
{
    private DataManager dataManager;

    public Text bestScoreText;
    public Text countSessionsText;

    [Inject]
    private void ConstructorLike(DataManager dm)
    {
        dataManager = dm;
    }

    private void OnEnable()
    {
        bestScoreText.text = "Best Score: " + dataManager.BestScore;
        countSessionsText.text = "Games Played: " + dataManager.CountSessions;
    }
}
