using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    public SpawnLevel spawnLevel;
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -32)
        {
            
            spawnLevel.SpawnNextLevel();
            Destroy(gameObject);
        }
    }
}
