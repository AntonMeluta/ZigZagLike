using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<TileControl> allTiles;

    public GameObject tilePrefab;
    public PlayerControl player;
    public CrystallSpawner crystallSpawner;

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

        player.GetPointSpawn(allTiles[lineCount * lineCount / 2].transform);

    }
    
    private IEnumerator SpawnTiles()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);

            GameObject obj1 = Instantiate(tilePrefab,
                allTiles[allTiles.Count - 1].forwardPointSpawn.bounds.center, Quaternion.identity);
            allTiles.Add(obj1.GetComponent<TileControl>());
            crystallSpawner.SpawnCrystall(allTiles[allTiles.Count - 1].transform);

            yield return new WaitForSeconds(1);

            GameObject obj2 = Instantiate(tilePrefab,
                allTiles[allTiles.Count - 1].rightPointSpawn.bounds.center, Quaternion.identity);
            allTiles.Add(obj2.GetComponent<TileControl>());
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
