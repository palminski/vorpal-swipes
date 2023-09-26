using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class LevelScript : MonoBehaviour
{

 

    [SerializeField]
    private Tilemap tilemap;

    private LevelScript followingLevel;

    
    private Transform spawnPoint;

   


    void Awake()
    {
        spawnPoint = transform.Find("SpawnPoint");
        
        tilemap.CompressBounds();
        
    }

    

    void Update()
    {
        if (spawnPoint.position.y <= -17) {
            DeleteLevel();
        }
        
    }

    public void SpawnLevel()
    {
        
        Vector3 spawnLocation = new Vector3(0, spawnPoint.position.y, 0);
        followingLevel = Instantiate(ControllerScript.Controller.Levels[Random.Range(0, ControllerScript.Controller.Levels.Length)], spawnLocation, transform.rotation).GetComponent<LevelScript>();
    }

    public void DeleteLevel()
    {
        //add points and increase speed
        ControllerScript.Controller.IncreaseScore(1000);
        ControllerScript.Controller.BumpSinkSpeed();

        Destroy(gameObject);
        followingLevel.SpawnLevel();
    }
}