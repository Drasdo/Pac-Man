using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] pellets;
    public GameObject pelletsPrefab;
    public GameObject gameover;
    public GameObject ghosts;
    public GameObject pacman;
    public GameObject button;
    public GameObject score;
    public GameObject highScore;
    public GameObject time;
    public GameObject[] lifeIcons;
    public int currentHighScore;
    public int currentScore;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        lifeIcons = GameObject.FindGameObjectsWithTag("Lives");
        currentHighScore = highScore.GetComponent<UpdateHighscore>().highScore;
    }

    // Update is called once per frame
    void Update()
    {
        pellets = GameObject.FindGameObjectsWithTag("Pellet");

        if (pellets.Length == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameover.SetActive(true);
        ghosts.SetActive(false);
        pacman.SetActive(false);
        button.SetActive(true);
        score.GetComponent<UpdateScore>().levelOver = true;
        time.GetComponent<UpdateTimer>().levelOver = true;
        currentScore = score.GetComponent<UpdateScore>().currentScore;
        if (currentScore > currentHighScore)
        {
            highScore.GetComponent<UpdateHighscore>().highScore = currentScore;
            currentHighScore = currentScore;
        }
        
    }

    public void ResetGame()
    {
        score.GetComponent<UpdateScore>().Reset();
        time.GetComponent<UpdateTimer>().Reset();
        pacman.transform.position = new Vector2(14.5f, 15.5f);
        ghosts.transform.GetChild(0).gameObject.transform.position = new Vector2(12f, 18.5f);
        ghosts.transform.GetChild(1).gameObject.transform.position = new Vector2(13f, 18.5f);
        ghosts.transform.GetChild(2).gameObject.transform.position = new Vector2(15f, 18.5f);
        ghosts.transform.GetChild(3).gameObject.transform.position = new Vector2(16f, 18.5f);
        gameover.SetActive(false);
        ghosts.SetActive(true);
        pacman.SetActive(true);
        button.SetActive(false);
        pacman.GetComponent<PacmanMove>().destination = new Vector2(14.5f, 15.5f);
        pacman.GetComponent<PacmanMove>().lives = 3;
        Instantiate(pelletsPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        foreach (GameObject lifeIcon in lifeIcons)
        {
            lifeIcon.SetActive(true);
        }
    }
    public void LoseLife()
    {
        lives = pacman.GetComponent<PacmanMove>().lives;
        pacman.GetComponent<PacmanMove>().lives -= 1;
        pacman.transform.position = new Vector2(14.5f, 15.5f);
        pacman.GetComponent<PacmanMove>().destination = new Vector2(14.5f, 15.5f);
        ghosts.transform.GetChild(0).gameObject.transform.position = new Vector2(12f, 18.5f);
        ghosts.transform.GetChild(1).gameObject.transform.position = new Vector2(13f, 18.5f);
        ghosts.transform.GetChild(2).gameObject.transform.position = new Vector2(15f, 18.5f);
        ghosts.transform.GetChild(3).gameObject.transform.position = new Vector2(16f, 18.5f);
        lifeIcons[lives - 1].SetActive(false);
    }

}
