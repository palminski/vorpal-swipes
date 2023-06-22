using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    public GameObject levelSpawner;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -32)
        {
            
            levelSpawner.GetComponent<SpawnLevel>().SpawnNextLevel();
            Destroy(gameObject);
        }
    }
}
