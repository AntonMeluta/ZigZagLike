using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TileSpawner : MonoBehaviour
{
    private Transform pointSpawnFoPlayer;
    private CrystallSpawner crystallSpawner;

    public List<TileControl> allTiles;
    public GameObject tilePrefab;
    

    [Inject]
    private void ConstructorLike(CrystallSpawner spawner)
    {
        crystallSpawner = spawner;
    }

    private void OnEnable()
    {
        EventsBroker.OnRestartGame += RestartGame;
    }

    private void Start()
    {
        allTiles = new List<TileControl>();
        SpawnStartArea();
        StartGame();
    }

    private void OnDisable()
    {
        EventsBroker.OnRestartGame -= RestartGame;
    }

    private void RestartGame()
    {
        foreach (TileControl tile in allTiles)
            Destroy(tile.gameObject);
        allTiles = new List<TileControl>();
        StopAllCoroutines();

        SpawnStartArea();
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(SpawnTiles());
    }

    private void SpawnStartArea()
    {
        int lineCount = 3;

        GameObject currentObjectTile = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
        allTiles.Add(currentObjectTile.GetComponent<TileControl>());

        for (int i = 0; i < lineCount; i++)
        {
            if (i != 0)
            {
                currentObjectTile = Instantiate(tilePrefab,
                        allTiles[allTiles.Count - lineCount].GetComponent<TileControl>().
                        forwardPointSpawn.bounds.center, Quaternion.identity);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
            for (int j = 0; j < lineCount - 1; j++)
            {
                currentObjectTile = Instantiate(tilePrefab,
                    allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center, Quaternion.identity);
                allTiles.Add(currentObjectTile.GetComponent<TileControl>());
            }
        }

        pointSpawnFoPlayer = allTiles[lineCount * lineCount / 2].transform;
    }

    public Transform GetPoinSpawn()
    {
        return pointSpawnFoPlayer;
    }
    
    private IEnumerator SpawnTiles()
    {
        int firstPartySpawnCount = 50;

        while (true)
        {
            if (allTiles.Count < firstPartySpawnCount)
                yield return null;
            else
                yield return new WaitForSeconds(0.2f);

            Vector3 targetPos = (Random.Range(0, 2) == 1) ?
                allTiles[allTiles.Count - 1].forwardPointSpawn.bounds.center :
                allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center;

            GameObject obj = Instantiate(tilePrefab, targetPos, Quaternion.identity);
            allTiles.Add(obj.GetComponent<TileControl>());
            crystallSpawner.SpawnCrystall(allTiles[allTiles.Count - 1].transform);
            
            /*if (tiles.Count > 0)
            {

            }
            else
            {
                GameObject obj = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
                lastTile = obj.GetComponent<TileControl>();
            }*/
        }
    }
}
