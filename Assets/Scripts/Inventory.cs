using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public bool HasRedKey;

    private int _count = 0;

    private int _count2 = 0;

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            countingUp.text = value.ToString();
        }
    }

    public int Count2
    {
        get => _count2;
        set
        {
            _count2 = value;
            countingUp2.text = value.ToString();
        }
    }

    [FormerlySerializedAs("Countingup")]
    [SerializeField]
    private Text countingUp;

    [FormerlySerializedAs("Countingup2")]
    [SerializeField]
    private Text countingUp2;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        countingUp.text = Count.ToString();
        countingUp2.text = Count2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
