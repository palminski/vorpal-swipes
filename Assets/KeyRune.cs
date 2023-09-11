using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRune : MonoBehaviour
{
    [SerializeField]
    private Sprite inactiveSprite;

    [SerializeField]
    private string requiredKey;

    [SerializeField]
    private int requiredScore = 200000;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (!ControllerScript.Controller.CollectedItems.Contains(requiredKey)) {
            sr.sprite = inactiveSprite;
        }
        if (ControllerScript.Controller.Score < requiredScore) {
            Object.Destroy(this.gameObject);
        }
    }


}
