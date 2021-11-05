using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallSpawner : MonoBehaviour
{
    private List<GameObject> allCrystalls;

    private int countTilesInBlock;
    private int needIndexSpawn;
    private int callCounter;

    public GameObject crystallPrefab;

    private void Awake()
    {
        allCrystalls = new List<GameObject>();

        countTilesInBlock = 5;
        needIndexSpawn = 1;
        callCounter = 0;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void RestartGame()
    {
        foreach (GameObject crystall in allCrystalls)
            Destroy(crystall);        
        allCrystalls = new List<GameObject>();

        countTilesInBlock = 5;
        needIndexSpawn = 1;
        callCounter = 0;
    }

    public void SpawnCrystall(Transform pointSpawn)
    {
        callCounter++;

        if (callCounter == needIndexSpawn)
        {
            float deltaHeight = 3;
            Vector3 positionSpawn = pointSpawn.position;
            positionSpawn.y += deltaHeight;
            allCrystalls.Add(Instantiate(crystallPrefab, positionSpawn, Quaternion.identity));

            if (callCounter % (countTilesInBlock * countTilesInBlock) != 0)
                needIndexSpawn += (countTilesInBlock + 1);
            else
                needIndexSpawn++;
        }
    }
    
}
