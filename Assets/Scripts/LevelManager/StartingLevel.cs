using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StartingLevel : MonoBehaviour
{

    [SerializeField]
    private Tilemap tilemap;

    private LevelScript levelScript;

    

    // Start is called before the first frame update
    void Start()
    {
        levelScript = GetComponent<LevelScript>();
        tilemap.CompressBounds();
        Debug.Log("Tile map Size: " + tilemap.size);
        levelScript.SpawnLevel();
    }

}
