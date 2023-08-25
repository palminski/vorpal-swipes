
using UnityEngine;
using TMPro;

public class TitleScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI TitleText;
    // Start is called before the first frame update
    void Awake()
    {

        TitleText = GetComponent<TextMeshProUGUI>();

        if (StaticVars.lastScore != 0) {
            TitleText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
