using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colide)
    {
        // Pacman eats the pellet
        if (colide.name == "pacman")
        {
            Destroy(gameObject);
        }
    }
}
