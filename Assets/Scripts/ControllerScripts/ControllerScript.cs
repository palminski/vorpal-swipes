using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{

    public static ControllerScript Controller { get; private set; }

    //Modifyable Val
    [SerializeField]
    private HighScoreTable highScoreTable;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private float startingSinkSpeed = 0.5f;

    [SerializeField, Range(0, 0.1f)]
    private float sinkSpeedIncrease;

    [SerializeField, Range(0, 0.5f)]
    private float maxSinkSpeed;

    [SerializeField, Range(0, 20)]
    private float playerMaxHeightAllowed;

    [SerializeField, Range(0, 1)]
    private float lerpEase = 0.1f;



    [SerializeField]
    private Animator transition;

    [SerializeField]
    private float transitionTime = 1;


    //Private Variables to be checked for elsewhere
    public int Score { get; private set; }
    public float SinkSpeed { get; private set; }
    public float finalSinkSpeed { get; private set; }

    public HashSet<string> CollectedItems { get; private set; }

    public int CollectedCoins { get; private set; }

    public bool playerAboveMaxPoint { get; private set; }


    public GameObject[] Levels;

    private GameObject pauseMenu;

    GameObject player;

    private Rigidbody2D playerRB;


    [System.Serializable]
    private class Collection
    {
        public List<string> collectedItems;
        public int collectedCoins;
    }

    //Audio Effects
    private GameObject soundEffectManager;
    private SoundEffectManager SFXManager;


    private void Awake()
    {
        Controller = this;
        Score = 0;
        SinkSpeed = 0;
        player = GameObject.FindWithTag("Player");
        if (player) playerRB = player.GetComponent<Rigidbody2D>();
        pauseMenu = GameObject.FindWithTag("PauseMenu");

        soundEffectManager = GameObject.FindGameObjectWithTag("SoundEffectManager");
        if (soundEffectManager) SFXManager = soundEffectManager.GetComponent<SoundEffectManager>();


        //default collection
        Collection collection = new Collection { collectedItems = new List<string>(), collectedCoins = 0 };

        //if saved data this is now the collection
        if (PlayerPrefs.HasKey("collection"))
        {
            collection = JsonUtility.FromJson<Collection>(PlayerPrefs.GetString("collection"));
        }



        //Now we uset his data to set our variables
        CollectedItems = new HashSet<string>(collection.collectedItems);
        CollectedCoins = collection.collectedCoins;




    }

    private void FixedUpdate()
    {
        if (SinkSpeed > maxSinkSpeed)
        {
            SinkSpeed = maxSinkSpeed;
        }
        if (player)
        {
            if (player.transform.position.y > playerMaxHeightAllowed)
            {
                playerAboveMaxPoint = true;
            }
            else
            {
                playerAboveMaxPoint = false;
            }

            //Check to make sure final sink speed is at least sink speed
            if (finalSinkSpeed < SinkSpeed && SinkSpeed > 0)
            {
                finalSinkSpeed = SinkSpeed;
            }

            //if player is approaching the top of the screen we need to start adjusting out final sink speed to increase
            if (playerAboveMaxPoint)
            {
                if (playerRB.velocity.y > 0.5)
                {
                    finalSinkSpeed = Mathf.Lerp(finalSinkSpeed, SinkSpeed + playerRB.velocity.y * Time.fixedDeltaTime, lerpEase);
                    
                }
                else
                {
                    finalSinkSpeed = Mathf.Lerp(finalSinkSpeed, SinkSpeed, lerpEase);
                    
                }
            }
            else
            {
                finalSinkSpeed = Mathf.Lerp(finalSinkSpeed, SinkSpeed, 0.03f);
            }
        }



    }

    public void GameOver()
    {
        if (Score >= 50000 && !CollectedItems.Contains("VetranProof")) addCollectableItem("VetranProof");
        SaveData();
        UpdateHighScores(Score);
        StaticVars.UpdateLastScore(Score);
        LoadNextLevel("GameOverScreen");

        if (player)
        {
            player.GetComponent<PlayerDeath>().KillPlayer();
        }

    }

    public void IncreaseScore(int points)
    {
        Score += points;
    }

    public int addCoins(int value)
    {
        CollectedCoins = Mathf.Clamp(CollectedCoins + value, 0, 9999);
        return CollectedCoins;
    }

    public void addCollectableItem(string collectableString)
    {
        CollectedItems.Add(collectableString);
        SaveData();
    }

    public void debugFunction()
    {

        CollectedItems.Clear();
        addCoins(9999);
        SaveData();
    }

    public void UpdateSinkSpeed(float speedToAdd)
    {
        if (SinkSpeed < maxSinkSpeed)
        {
            //for now it will not scroll until the sink speed is initially set
            if (SinkSpeed != 0) SinkSpeed += speedToAdd;
        }
        else
        {
            SinkSpeed = maxSinkSpeed;
        }
    }

    public void BumpSinkSpeed()
    {
        if (SinkSpeed < maxSinkSpeed)
        {
            //for now it will not scroll until the sink speed is initially set
            if (SinkSpeed != 0) SinkSpeed += sinkSpeedIncrease;
        }
        else
        {
            SinkSpeed = maxSinkSpeed;
        }
    }
    public void StartGame()
    {
        SinkSpeed = startingSinkSpeed;
        if (highScoreTable) highScoreTable.HideTable();
        if (mainMenu) mainMenu.SetActive(false);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
            if (pauseMenu)
            {
                pauseMenu.SetActive(true);
            }
        }
    }

    public void UpdateHighScores(int newScore)
    {
        int[] highScoreArray = System.Array.ConvertAll(PlayerPrefs.GetString("highScores", "1000###1000###1000###1000###1000").Split("###"), int.Parse);

        if (highScoreArray[0] < newScore)
        {
            highScoreArray[0] = newScore;
            System.Array.Sort(highScoreArray);
            PlayerPrefs.SetString("highScores", string.Join("###", highScoreArray));
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        if (player) StaticVars.SetLastColor(player.GetComponent<SpriteRenderer>().color);
        StartCoroutine(LoadLevel(sceneName));
    }

    public void SaveData()
    {
        Collection collection = new Collection { collectedItems = new List<string>(CollectedItems), collectedCoins = CollectedCoins };
        string json = JsonUtility.ToJson(collection);
        PlayerPrefs.SetString("collection", json);
    }

    IEnumerator LoadLevel(string sceneName)
    {
        //play animation
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //loadScene
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (SFXManager && PlayerPrefs.GetInt("allowSFX", 1) != 0) SFXManager.playEffect(audioClip);
    }
}


