using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
        {
            Destroy(gameObject);
        }
    }
}
