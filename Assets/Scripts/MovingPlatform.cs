using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject[] Waypoints;
    public GameObject Player;
    public AudioSource ElevatorMusic, stop;
    public int current = 0;
    public float Speed;

    public float pauseDuration = 3f;
    private float pauseTimer = 0f;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
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

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Speed * Time.fixedDeltaTime);

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
        if(collision.gameObject.CompareTag("Player"))
        {
            ElevatorMusic.Play();
            

            Player = collision.gameObject;

            Player.transform.parent = transform;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            ElevatorMusic.Stop();
            Player.transform.parent = null;

        }
    }
}
