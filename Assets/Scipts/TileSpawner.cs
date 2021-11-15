using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TileSpawner : MonoBehaviour
{
    private Transform pointSpawnForPlayer;
    private CrystallSpawner crystallSpawner;
    private GameManager gameManager;

    private List<TileControl> allTiles = new List<TileControl>();
    private GameObject prefabTile;

    public GameObject tilePrefabHardDiffiulty;
    public GameObject tilePrefabMiddleDiffiulty;
    public GameObject tilePrefabEasyDiffiulty;

    [Inject]
    private void ConstructorLike(CrystallSpawner spawner, GameManager gm)
    {
        crystallSpawner = spawner;
        gameManager = gm;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void Start()
    {
        switch (gameManager.gameSettings.difficultyLevel)
        {
            case DifficultyLevel.Easy:
                prefabTile = tilePrefabEasyDiffiulty;
                break;
            case DifficultyLevel.Middle:
                prefabTile = tilePrefabMiddleDiffiulty;
                break;
            case DifficultyLevel.Hard:
                prefabTile = tilePrefabHardDiffiulty;
                break;
            default:
                break;
        }

        SpawnStartArea();
        StartGame();
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void RestartGame()
    {
        if (allTiles.Count > 0)
        {
            foreach (TileControl tile in allTiles)
                Destroy(tile.gameObject);
        }        

        allTiles = new List<TileControl>();
        gameManager.gameSettings.UpdateSpeedPlayer();

        switch (gameManager.gameSettings.difficultyLevel)
        {
            case DifficultyLevel.Easy:                
                prefabTile = tilePrefabEasyDiffiulty;
                break;
            case DifficultyLevel.Middle:
                prefabTile = tilePrefabMiddleDiffiulty;
                break;
            case DifficultyLevel.Hard:
                prefabTile = tilePrefabHardDiffiulty;
                break;
            default:
                break;
        }
                StopAllCoroutines();

        SpawnStartArea();
        StartGame();
    }

    public void RemoveTileFromList(TileControl tile)
    {
        allTiles.Remove(tile);
        print("allTiles.Count = " + allTiles.Count);
    }

    public void StartGame()
    {
        StartCoroutine(SpawnTiles());
    }

    public void SpawnStartArea()
    {
        int lineCount = 3;

        GameObject currentObjectTile = Instantiate(prefabTile, Vector3.zero, Quaternion.identity);
        allTiles.Add(currentObjectTile.GetComponent<TileControl>());

        for (int i = 0; i < lineCount; i++)
        {
            if (i != 0)
            {
                currentObjectTile = Instantiate(prefabTile,
                        allTiles[allTiles.Count - lineCount].GetComponent<TileControl>().
                        forwardPointSpawn.bounds.center, Quaternion.identity);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
            for (int j = 0; j < lineCount - 1; j++)
            {
                currentObjectTile = Instantiate(prefabTile,
                    allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center, Quaternion.identity);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
        }

        pointSpawnForPlayer = allTiles[lineCount * lineCount / 2].transform;
    }
    
    private IEnumerator SpawnTiles()
    {
        int firstPartySpawnCount = 50;
        //float delaySlow = 0.3f;

        while (true)
        {

            if (allTiles.Count < firstPartySpawnCount)
            {
                Vector3 targetPos = (Random.Range(0, 2) == 1) ?
                allTiles[allTiles.Count - 1].forwardPointSpawn.bounds.center :
                allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center;

                GameObject obj = Instantiate(prefabTile, targetPos, Quaternion.identity);
                allTiles.Add(obj.GetComponent<TileControl>());
                crystallSpawner.SpawnCrystall(allTiles[allTiles.Count - 1].transform);
            }

            yield return null;

        }
    }
}
