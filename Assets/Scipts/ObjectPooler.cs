using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private List<GameObject> pooledObjects;

    public List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        pooledObjects = new List<GameObject>();
        
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tagPooletObj)
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tagPooletObj)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tagPooletObj)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }

        return null;
    }

    public void ClearAllLists()
    {
        foreach (GameObject obj in pooledObjects)
        {
            obj.SetActive(false);
        }
    }


}

[System.Serializable]
public struct ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;
    public TagsObjectToPool typeObjectToPool;
}

public enum TagsObjectToPool
{
    EasyLvlTile,
    MiddleLvlTile,
    HardLvlTile,
    CrystallPickuped
}
