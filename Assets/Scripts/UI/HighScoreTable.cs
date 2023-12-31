using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreTable : MonoBehaviour
{



    private Transform entryContainer;
    private Transform entryTemplate;

    [SerializeField]
    private TextMeshProUGUI lastScoreText;

    [SerializeField]
    private float scoreSpacing;


    private void Awake() {
        entryContainer = transform.Find("highScoreEntries");
        entryTemplate = entryContainer.Find("highScoreEntryTemplate");




        if (StaticVars.lastScore != 0) {
            lastScoreText.text = "Last Score: " + StaticVars.lastScore;
        }
        else {
            lastScoreText.text = "";
        }
        

        entryTemplate.gameObject.SetActive(false);

        

        string[] highScoreArray = PlayerPrefs.GetString("highScores","1000###1000###1000###1000###1000").Split(new string[]{"###"}, System.StringSplitOptions.None);
        

        for (int i = 0; i < highScoreArray.Length; i++) {



            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -scoreSpacing *i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            entryTransform.Find("rank").GetComponent<TextMeshProUGUI>().text = rank.ToString();
            entryTransform.Find("score").GetComponent<TextMeshProUGUI>().text = highScoreArray[highScoreArray.Length -1 -i];
        }
        
    }



    public void HideTable() {
        gameObject.SetActive(false);
    }
}
