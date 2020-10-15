using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHighscore : MonoBehaviour
{
    public int highScore;
    Text[] highScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        highScoreTxt = GetComponents<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highScoreTxt[0].text = "Highscore: " + highScore;
    }
}
