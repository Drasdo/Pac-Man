using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    private float speed = 0.16f;
    public Vector2 destination = Vector2.zero;
    public int lives = 3; 

    void Start()
    {
        destination = transform.position;
        
    }

    void Update()
    {
        
        // Pacman moves to current destination
        Vector2 position = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(position);
        // Changes the direction pacman is facing
        Vector2 direction = destination - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirY", direction.y);
        GetComponent<Animator>().SetFloat("DirX", direction.x);
        //Sets new desination with arrow keys
        if ((Vector2)transform.position == destination)
        {
            // Up
            if (Input.GetKey(KeyCode.UpArrow) && wallCheck(Vector2.up))
            {
                destination = (Vector2)transform.position + Vector2.up;
            }
            //right
            if (Input.GetKey(KeyCode.RightArrow) && wallCheck(Vector2.right))
            {
                destination = (Vector2)transform.position + Vector2.right;
            }
            //down
            if (Input.GetKey(KeyCode.DownArrow) && wallCheck(Vector2.down))
            {
                destination = (Vector2)transform.position + Vector2.down;
            }    
            //left
            if (Input.GetKey(KeyCode.LeftArrow) && wallCheck(Vector2.left))
            {
                destination = (Vector2)transform.position + Vector2.left;
            } 
        }
    }
    //Checks to see if pacman will hit a wall
    bool wallCheck(Vector2 direction)
    {
        Vector2 location = transform.position;
        RaycastHit2D touch = Physics2D.Linecast(location + direction, location);
        return (touch.collider == GetComponent<Collider2D>());
    }
}
