using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CrystallSpawner : MonoBehaviour
{
    private List<GameObject> allCrystalls;
    private GameManager gameManager;

    private int countTilesInBlock;
    private int needIndexSpawn;
    private int callCounter;

    public GameObject crystallPrefab;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

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
        switch (gameManager.gameSettings.waySpawnÑrystals)
        {
            case WaySpawnÑrystals.randomSpawn:
                RandomMethodSpawn(pointSpawn);
                break;
            case WaySpawnÑrystals.order:
                OrderMethodSpawn(pointSpawn);
                break;
            default:
                break;
        }
    }

    private void RandomMethodSpawn(Transform pointSpawn)
    {
        int borderRandom = 10;
        int chanceOfSuccess = Random.Range(0, borderRandom);

        if (chanceOfSuccess > borderRandom / 2 + 1)
        {
            float deltaHeight = 3;
            Vector3 positionSpawn = pointSpawn.position;
            positionSpawn.y += deltaHeight;
            allCrystalls.Add(Instantiate(crystallPrefab, positionSpawn, Quaternion.identity));
        }
    }

    private void OrderMethodSpawn(Transform pointSpawn)
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
