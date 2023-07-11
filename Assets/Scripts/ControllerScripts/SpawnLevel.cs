using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] levels;

    private void Start()
    {
        SpawnNextLevel(0);
    }

    public void SpawnNextLevel(float offset)
    {
        Debug.Log(offset);
        Vector3 spawnLocation = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
        Instantiate(levels[Random.Range(0, levels.Length)], spawnLocation, transform.rotation);
    }
}
