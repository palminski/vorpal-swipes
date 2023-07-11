using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    public SpawnLevel spawnLevel;
    




    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -(spawnLevel.transform.position.y))
        {


            float offset = transform.position.y + spawnLevel.transform.position.y;
            spawnLevel.SpawnNextLevel(offset);
            Destroy(gameObject);
        }
    }
}
