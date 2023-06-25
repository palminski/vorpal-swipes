using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject[] levels;

    private void Start()
    {
        Debug.Log(levels.Length);
        SpawnNextLevel();
    }

    public void SpawnNextLevel()
    {
        Debug.Log(Random.Range(0, levels.Length));
        Instantiate(levels[Random.Range(0, levels.Length)], transform.position, transform.rotation);
    }
}
