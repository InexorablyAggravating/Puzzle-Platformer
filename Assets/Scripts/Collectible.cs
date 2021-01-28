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
                Menu.instance.Collectibles.SetActive(true);
                Count++;
                Menu.instance.Countingup.text = Count.ToString();

                HighScore += 100;

                Menu.instance.HighScore.text = HighScore.ToString();

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
