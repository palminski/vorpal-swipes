using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class ObjectPool {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    public List<ObjectPool> objectPools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        //create dictionary of pools
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //for each object pool we have made we will loop through and make a pool containing however many copies of the object
        foreach (ObjectPool objectPool  in objectPools)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            for (int i = 0; i < objectPool.size; i++)
            {
                GameObject obj = Instantiate(objectPool.prefab);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
            //add the newly made pool to our dictionary
            poolDictionary.Add(objectPool.tag, pool);
        } 
    }

    public GameObject PullFromPool(string tag, Vector3 position, Quaternion rotation) {

        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Yo, There is no pool with tag " + tag + ", Check your spelling!");
            return null;
        }

        GameObject pulledObject = poolDictionary[tag].Dequeue();

        pulledObject.SetActive(true);
        pulledObject.transform.position = position;
        pulledObject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(pulledObject);

        return pulledObject;
    }

}
