using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    public GameObject level;

    private void Start()
    {
        Instantiate(level, transform.position, transform.rotation);
    }
    public void SpawnNextLevel()
    {
        Instantiate(level, transform.position, transform.rotation);
    }
}
