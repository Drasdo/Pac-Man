using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    public GameObject pellets;
    public GameObject gameover;
    public GameObject ghosts;
    public GameObject pacman;
    public GameObject button;
    public GameObject score;
    public GameObject time;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Clicked()
    {
        controller.GetComponent<Controller>().ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
