using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public int currentScore = 5000;
    public int timer = 0;
    public bool levelOver = false;
    Text[] score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponents<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score[0].text = "Score: " + currentScore;
        if (levelOver == false)
        {
            if (timer == 60)
            {
                currentScore -= 10;

                timer = 0;
            }
            timer += 1;
        }

    }

    public void Reset()
    {
        currentScore = 5000;
        timer = 0;
        score[0].text = "Score: " + currentScore;
        levelOver = false;
    }
}
