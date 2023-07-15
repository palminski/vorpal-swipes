using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPosition : MonoBehaviour
{
    
    private PlayerMovement playerMovement;

    public Transform leftStartingPosition;
    public Transform rightStartingPosition;


    // Start is called before the first frame update
    void Start()
    {
        
        playerMovement = GetComponent<PlayerMovement>();
        if (StaticVars.entryPosition == "left") {
            if (leftStartingPosition) transform.position = leftStartingPosition.position;
            playerMovement.Leap(new Vector2(1,0));
        }
        else if (StaticVars.entryPosition == "right") {
            if (rightStartingPosition) transform.position = rightStartingPosition.position;
            playerMovement.Leap(new Vector2(-1,0));
        }
        StaticVars.setEntryPosition("center");
    }


}
