using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public int cur = 0;
    public GameObject gameover;
    public GameObject ghosts;
    public GameObject button;
    public GameObject pacman;
    public GameObject score;
    public GameObject time;
    public int lives;
    public GameObject controller; 
    public float speed = 0.2f;


    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position == new Vector3(12f, 18.5f, 0f) ||
            transform.position == new Vector3(13f, 18.5f, 0f) ||
            transform.position == new Vector3(15f, 18.5f, 0f) ||
            transform.position == new Vector3(16f, 18.5f, 0f))
        {
            cur = 0;
        }

        // Waypoint not reached yet? then move closer
            if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;

        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            lives = pacman.GetComponent<PacmanMove>().lives;
            if (lives == 0)
            {
                //Destroy(co.gameObject);
                pacman.SetActive(false);
                gameover.SetActive(true);
                ghosts.SetActive(false);
                button.SetActive(true);
                score.GetComponent<UpdateScore>().levelOver = true;
                score.GetComponent<UpdateScore>().currentScore = 0;
                time.GetComponent<UpdateTimer>().levelOver = true;

            }
            else
            {
                controller.GetComponent<Controller>().LoseLife();
            }
            
        }
            

        

    }
}
