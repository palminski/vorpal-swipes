
using UnityEngine;

using System.Collections;

public class TextScroll : MonoBehaviour
{


    [SerializeField]
    private float scrollDelay = 100;


    
    //======================================================

    void FixedUpdate() {
        if (scrollDelay > 0) {
                    scrollDelay--;
        }
        if (scrollDelay == 1) {
            ControllerScript.Controller.StartGame();
        }

    }


}
