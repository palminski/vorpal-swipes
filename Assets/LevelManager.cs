using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    
    private int levelPoolSize;

    private GameObject[] levelPool;

    private int currentLevelIndex = 0;

    public Transform levelSpawnPoint;



    private void InitializeLevelPool() {

        levelPoolSize = levelPrefabs.Length;

        levelPool = new GameObject[levelPoolSize];

        for (int i = 0; i < levelPoolSize; i++) {
            GameObject level = Instantiate(levelPrefabs[i], transform);
            level.SetActive(false);
            levelPool[i] = level;
        }
    }

    private void ActivateNextLevel() {

        int randomIndex = Random.Range(0, levelPoolSize);

        while (levelPool[randomIndex].activeSelf) {
            randomIndex = Random.Range(0, levelPoolSize);
        }

        levelPool[randomIndex].SetActive(true);
        levelPool[randomIndex].transform.position = levelSpawnPoint.position;
    }

    private void Start() {
        InitializeLevelPool();
        ActivateNextLevel();
    }

}
