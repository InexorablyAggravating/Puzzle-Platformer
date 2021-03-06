using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] Waypoints;
    public GameObject Player;
    public int current = 0;
    public float Speed;

    public float pauseDuration = 3f;
    private float pauseTimer = 0f;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindWithTag(UnityTags.PLAYER);
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                paused = false;
                pauseTimer = 0f;
            }
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Speed * Time.deltaTime);

        if (transform.position == Waypoints[current].transform.position)
        {
            current++;
            paused = true;
            if (current == Waypoints.Length)
            {
                current = 0;
            }
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
