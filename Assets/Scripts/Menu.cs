using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject Collectibles;

    public GameObject OptionsScreen;

    public string LevelSelect;

    public Text CountingDowm;

    public float TimeRemaining = 20f;

    private int _count = 0;
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            countingUp.text = value.ToString();
        }
    }

    private int _highScore = 0;
    public int HighScore
    {
        get => _highScore;
        set
        {
            _highScore = value;
            highScore.text = value.ToString();
        }
    }
    
    
    [FormerlySerializedAs("Countingup")] [SerializeField]
    private Text countingUp;
    [FormerlySerializedAs("HighScore")] [SerializeField]
    private Text highScore;
    public static Menu instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        countingUp.text = Count.ToString();
        highScore.text = HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeRemaining > 0)
        {
            TimeRemaining -= 1 * Time.deltaTime;
            CountingDowm.text = TimeRemaining.ToString("0");
        }
        else
        {
            TimeRemaining = 0;
            CountingDowm.text = TimeRemaining.ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LevelSelect);
    }
    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        OptionsScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
