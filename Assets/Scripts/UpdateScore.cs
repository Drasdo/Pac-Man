using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public int currentScore = 5000;
    private int timer = 0;
    public bool levelOver = false;
    private Text[] score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponents<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //Score lowers by 10 every second not completed
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
    // resets score
    public void Reset()
    {
        currentScore = 5000;
        timer = 0;
        score[0].text = "Score: " + currentScore;
        levelOver = false;
    }
}
