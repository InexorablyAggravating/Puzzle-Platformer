using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject Collectibles;

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
        
    }
}
