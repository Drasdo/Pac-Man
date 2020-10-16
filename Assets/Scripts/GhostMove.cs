using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointNum = 0;
    public GameObject gameover;
    public GameObject ghosts;
    public GameObject button;
    public GameObject pacman;
    public GameObject score;
    public GameObject time;
    public int lives;
    public GameObject controller;
    private float speed = 0.2f;

    void FixedUpdate()
    {
        // checks if in start pos then reset way points
        if (transform.position == new Vector3(12f, 18.5f, 0f) ||
            transform.position == new Vector3(13f, 18.5f, 0f) ||
            transform.position == new Vector3(15f, 18.5f, 0f) ||
            transform.position == new Vector3(16f, 18.5f, 0f))
        {
            waypointNum = 0;
        }
        //check if reached waypoint yet, if not move to new waypoint
        if (transform.position != waypoints[waypointNum].position)
        {
            Vector2 position = Vector2.MoveTowards(transform.position, waypoints[waypointNum].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(position);
        }
        else
        {
            waypointNum = (waypointNum + 1) % waypoints.Length;
        }
        // changes direction ghost is facing
        Vector2 direction = waypoints[waypointNum].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", direction.x);
        GetComponent<Animator>().SetFloat("DirY", direction.y);
    }

    void OnTriggerEnter2D(Collider2D colide)
    {
        // collition with pacman
        if (colide.name == "pacman")
        {
            // checks lives
            lives = pacman.GetComponent<PacmanMove>().lives;
            // gameover
            if (lives == 0)
            {
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
                // lose a life
                controller.GetComponent<Controller>().LoseLife();
            }
            
        }
            

        

    }
}
