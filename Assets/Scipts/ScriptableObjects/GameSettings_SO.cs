using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSettings", menuName = "GameSettings", order = 1)]
public class GameSettings_SO : ScriptableObject
{
    public DifficultyLevel difficultyLevel;
    public WaySpawn—rystals waySpawn—rystals;
    public int speedPlayer = 10;

    public void UpdateSpeedPlayer()
    {
        speedPlayer = (int)difficultyLevel;
    }
}
