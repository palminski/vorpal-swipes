using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseChildEnemyColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomInt = Random.Range(0,2);
        if (randomInt == 0) {
            Enemy[] enemies = GetComponentsInChildren<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                enemy.SwapStartingColor();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
