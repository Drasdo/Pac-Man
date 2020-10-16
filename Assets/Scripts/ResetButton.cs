using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{

    public GameObject controller;

    public void Clicked()
    {
        // resets variables
        controller.GetComponent<Controller>().ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
