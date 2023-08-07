using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPools : MonoBehaviour
{

    [System.Serializable]
    public class ObjectPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<ObjectPool> objectPools;


    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod]
    void Start()
    {

        PoolManager.poolDictionary.Clear();
        //for each object pool we have made we will loop through and make a pool containing however many copies of the object
        foreach (ObjectPool objectPool in objectPools)
        {

            Queue<GameObject> pool = new Queue<GameObject>();
            for (int i = 0; i < objectPool.size; i++)
            {
                GameObject obj = Instantiate(objectPool.prefab);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
            //add the newly made pool to our dictionary
            PoolManager.AddNewPool(objectPool.tag, pool);
        }
    }
}
