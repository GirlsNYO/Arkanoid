using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int lives;
    public int score;
    public Text lives_text;
    public Text score_text;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int numberOfBricks;
	// Use this for initialization
	void Start () {
        lives_text.text = "Lives: " + lives;
        score_text.text = "Score:" + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag ("brick").Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        lives_text.text = "Lives: " + lives;
    }

    public void UpdateScore(int points)
    {
        score += points;
        score_text.text = "Score:" + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if(numberOfBricks <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive (true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
