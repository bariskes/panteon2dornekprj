using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDictionary : MakeSingleton<PoolDictionary>
{
    //game objects queue
    [HideInInspector]
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    private List<Pool> _pool;
    // starts objectpool
    public void setPool(List<Pool> pool,Transform parent)
    {
        _pool = pool;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool item in _pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < item.size; i++)
            {
                GameObject gmObj = Instantiate(item.prefab);
                gmObj.SetActive(false);
              //  gmObj.transform.SetParent(parent);
                objectPool.Enqueue(gmObj);
            }
            poolDictionary.Add(item.tag, objectPool);
        }

    }
    // calls object from pool
    public GameObject SpawnFromPool(string tag, Vector2 position,Transform parent)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;
        GameObject spawnObj = poolDictionary[tag].Dequeue();
        //makes selected gameobject active
        spawnObj.SetActive(true);
        if (parent != null)
        {
          //  spawnObj.transform.SetParent(parent);
        }
        spawnObj.transform.position = position;
        poolDictionary[tag].Enqueue(spawnObj);
        return spawnObj;


    }



}
