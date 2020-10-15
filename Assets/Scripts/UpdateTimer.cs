using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTimer : MonoBehaviour
{
    public int currentTime = 0;
    public int timer = 0;
    public bool levelOver = false;
    //public GameObject gameover; 
    Text[] time;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponents<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(levelOver);
        if (levelOver == false)
        {
            if (timer == 60)
            {
                currentTime += 1;
                time[0].text = "Time: " + currentTime;
                timer = 0;
            }
            timer += 1;
        }
        else
        {
            time[0].text = "Time: " + currentTime;
        }

    }

    public void Reset()
    {
        currentTime = 0;
        timer = 0;
        time[0].text = "Time: " + currentTime;
        levelOver = false;
    }
}