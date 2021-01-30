using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] Waypoints;
    public GameObject Player;
    int current = 0;
    float rotspeed;
    public float Speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindWithTag(UnityTags.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Waypoints[current].transform.position, transform.position) < WPradius)
        {
            current = Random.Range(0, Waypoints.Length);
            {
                if(current >= Waypoints.Length)
                {
                    current = 0;
                }
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Time.deltaTime * Speed);
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
