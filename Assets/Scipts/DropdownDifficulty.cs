using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class DropdownDifficulty : MonoBehaviour
{
    private int indexFlag;
    private Dropdown dropdown;
    private GameManager gameManager;
    
    private readonly DifficultyLevel[] levelsDiff = {
    DifficultyLevel.Easy,
    DifficultyLevel.Middle,
    DifficultyLevel.Hard
    };

    [Inject]
    private void ConstructorLike(CrystallSpawner spawner, GameManager gm)
    {
        gameManager = gm;
    }

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(DropValue);
        FillingOptionsDropdown();        
    }

    private void FillingOptionsDropdown()
    {
        for (int i = 0; i < levelsDiff.Length; i++)
            dropdown.options.Add(new Dropdown.OptionData(levelsDiff[i].ToString()));
        indexFlag = levelsDiff.Length - 1;
        dropdown.value = indexFlag;
        gameManager.gameSettings.difficultyLevel = levelsDiff[indexFlag];
    }

    private void DropValue(int value)
    {
        indexFlag = value;
        gameManager.gameSettings.difficultyLevel = levelsDiff[indexFlag];
    }
}
