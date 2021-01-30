using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] Waypoints;
    public GameObject Player;
    int current = 0;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindWithTag(UnityTags.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Speed * Time.deltaTime);
        if(transform.position == Waypoints[current].transform.position)
        {
            current++;
        }

        if(current == Waypoints.Length)
        {
            current = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
