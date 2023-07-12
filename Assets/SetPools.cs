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
    void Start()
    {
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
            PoolManager.AddNewPool(objectPool.tag, pool);

            GameObject testRubble = PoolManager.PullFromPool("BlockRubble", new Vector3(0,13,0), transform.rotation);
            testRubble.GetComponent<BrokenBlock>().OnActivate(Color.green, new Vector2 (-100,200));
            GameObject testRubble2 = PoolManager.PullFromPool("BlockRubble", new Vector3(0,13,0), Quaternion.Euler(Vector3.forward * 180));
            testRubble2.GetComponent<BrokenBlock>().OnActivate(Color.green, new Vector2 (100,200));
        } 
    }

}
