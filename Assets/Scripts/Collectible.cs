using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private bool Sphere;

    [SerializeField]
    private bool Cube;

    public int Count;

    public int HighScore;

    public static Collectible instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Sphere)
            {
                Menu.instance.Count++;
                Menu.instance.HighScore += 100;
                Inventory.Instance.HasKey = true;

                Destroy(gameObject);
                Debug.Log("Collected");
            }

            if (Cube)
            {
                Destroy(gameObject);
                Debug.Log("Collected");
            }

        }
    }

}
