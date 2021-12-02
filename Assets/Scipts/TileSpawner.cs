using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TileSpawner : MonoBehaviour
{
    private TagsObjectToPool tagsObjectToPool;

    private Transform pointSpawnForPlayer;
    private CrystallSpawner crystallSpawner;
    private GameManager gameManager;
    private ObjectPooler objectPooler;

    private List<TileControl> allTiles = new List<TileControl>();

    [Inject]
    private void ConstructorLike(CrystallSpawner spawner, GameManager gm, ObjectPooler pooler)
    {
        crystallSpawner = spawner;
        gameManager = gm;
        objectPooler = pooler;
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
                tagsObjectToPool = TagsObjectToPool.EasyLvlTile;
                break;
            case DifficultyLevel.Middle:
                tagsObjectToPool = TagsObjectToPool.MiddleLvlTile;
                break;
            case DifficultyLevel.Hard:
                tagsObjectToPool = TagsObjectToPool.HardLvlTile;
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
        objectPooler.ClearAllLists();

        allTiles = new List<TileControl>();
        gameManager.gameSettings.UpdateSpeedPlayer();

        switch (gameManager.gameSettings.difficultyLevel)
        {
            case DifficultyLevel.Easy:                
                tagsObjectToPool = TagsObjectToPool.EasyLvlTile;
                break;
            case DifficultyLevel.Middle:
                tagsObjectToPool = TagsObjectToPool.MiddleLvlTile;
                break;
            case DifficultyLevel.Hard:
                tagsObjectToPool = TagsObjectToPool.HardLvlTile;
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
    }

    public void StartGame()
    {
        StartCoroutine(SpawnTiles());
    }

    public void SpawnStartArea()
    {
        int lineCount = 3;

        GameObject currentObjectTile = objectPooler.GetPooledObject(tagsObjectToPool.ToString());
        currentObjectTile.transform.position = Vector3.zero;
        currentObjectTile.transform.rotation = Quaternion.identity;
        currentObjectTile.SetActive(true);
        allTiles.Add(currentObjectTile.GetComponent<TileControl>());

        for (int i = 0; i < lineCount; i++)
        {
            if (i != 0)
            {
                currentObjectTile = objectPooler.GetPooledObject(tagsObjectToPool.ToString());
                currentObjectTile.transform.position =
                    allTiles[allTiles.Count - lineCount].GetComponent<TileControl>().
                        forwardPointSpawn.bounds.center;
                currentObjectTile.transform.rotation = Quaternion.identity;
                currentObjectTile.SetActive(true);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
            for (int j = 0; j < lineCount - 1; j++)
            {
                currentObjectTile = objectPooler.GetPooledObject(tagsObjectToPool.ToString());
                currentObjectTile.transform.position =
                    allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center;
                currentObjectTile.transform.rotation = Quaternion.identity;
                currentObjectTile.SetActive(true);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
        }

        pointSpawnForPlayer = allTiles[lineCount * lineCount / 2].transform;
    }
    
    private IEnumerator SpawnTiles()
    {
        int firstPartySpawnCount = 50;

        while (true)
        {
            if (allTiles.Count < firstPartySpawnCount)
            {
                Vector3 targetPos = (Random.Range(0, 2) == 1) ?
                allTiles[allTiles.Count - 1].forwardPointSpawn.bounds.center :
                allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center;

                GameObject obj = objectPooler.GetPooledObject(tagsObjectToPool.ToString());
                obj.transform.position = targetPos;
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);
                allTiles.Add(obj.GetComponent<TileControl>());
                crystallSpawner.SpawnCrystall(allTiles[allTiles.Count - 1].transform);
            }
            yield return null;
        }
    }
}
