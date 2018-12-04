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
    public Text highScoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPannel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;


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
            if (currentLevelIndex >= levels.Length - 1)
            {
                GameOver();
            } else {
                UpdateLives(1);
                loadLevelPannel.SetActive(true);
                loadLevelPannel.GetComponentInChildren<Text>().text = "Loading Level " + (currentLevelIndex + 2);
                gameOver = true;
                Invoke("LoadLevel", 3.0f);
            }
        }
    }

    void LoadLevel(){
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver = false;
        loadLevelPannel.SetActive(false);
    }

    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive (true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            highScoreText.text = "New High Score! " + score;
        }
        else
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
