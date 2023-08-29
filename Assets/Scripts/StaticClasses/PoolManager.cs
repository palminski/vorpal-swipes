using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{


    public static Dictionary<string, Queue<GameObject>> poolDictionary;


    [RuntimeInitializeOnLoadMethod]
    static void Awake()
    {
        //create dictionary of pools
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

    }

    public static void AddNewPool(string tag, Queue<GameObject> pool)
    {
        poolDictionary.Add(tag, pool);
    }

    public static GameObject PullFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Yo, There is no pool with tag " + tag + ", Check your spelling!");
            return null;
        }


        GameObject pulledObject = poolDictionary[tag].Dequeue();

        if (pulledObject.activeSelf) {
            pulledObject.SetActive(false);
        }

        pulledObject.SetActive(true);
        pulledObject.transform.localScale = new Vector3(1, 1, 1);
        pulledObject.transform.position = position;
        pulledObject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(pulledObject);

        return pulledObject;
    }

    public static GameObject PullFromPool(string tag, Vector3 position, Quaternion rotation, Vector3 scale)
    {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Yo, There is no pool with tag " + tag + ", Check your spelling!");
            return null;
        }


        GameObject pulledObject = poolDictionary[tag].Dequeue();

        if (pulledObject.activeSelf) {
            pulledObject.SetActive(false);
        }

        pulledObject.SetActive(true);
        pulledObject.transform.localScale = scale;
        pulledObject.transform.position = position;
        pulledObject.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(pulledObject);

        return pulledObject;
    }

    public static GameObject PullWithoutRotation(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Yo, There is no pool with tag " + tag + ", Check your spelling!");
            return null;
        }


        GameObject pulledObject = poolDictionary[tag].Dequeue();

        pulledObject.SetActive(true);
        pulledObject.transform.localScale = new Vector3(1, 1, 1);
        pulledObject.transform.position = position;

        poolDictionary[tag].Enqueue(pulledObject);

        return pulledObject;
    }




}

