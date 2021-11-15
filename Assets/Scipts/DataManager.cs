using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private const string KeyBestScore = "BestScore";
    private const string KeyCountSessions = "CounterSessions";

    private int bestScore;
    private int countSessions;

    private void Awake()
    {
        LoadData();
    }

    public int BestScore
    {
        get
        {
            return bestScore;
        }
    }

    public int CountSessions
    {
        get
        {
            return countSessions;
        }
    }

    public void LoadData()
    {
        bestScore = PlayerPrefs.GetInt(KeyBestScore, 0);
        countSessions = PlayerPrefs.GetInt(KeyCountSessions, 0);
    }

    public void SaveScore(int value)
    {
        if (value > bestScore)
        {
            bestScore = value;
            PlayerPrefs.SetInt(KeyBestScore, bestScore);
        }
    }

    public void SaveCountSessions()
    {
        countSessions++;
        PlayerPrefs.SetInt(KeyCountSessions, countSessions);
    }

}
