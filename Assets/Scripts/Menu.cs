using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public GameObject Collectibles;
    public Text Countingup;
    public Text HighScore;
    public static Menu instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Countingup.text = Collectible.instance.Count.ToString();
        HighScore.text = Collectible.instance.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
