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

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            countingUp.text = value.ToString();
        }
    }

    [FormerlySerializedAs("Countingup")]
    [SerializeField]
    private Text countingUp;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        countingUp.text = Count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
