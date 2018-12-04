using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public Text highscoreText;

    // Use this for initialization
    void Start()
    {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("HIGHSCORE");
       
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit Button Pushed");
	}
	
	// Update is called once per frame
	public void StartGame () {
        SceneManager.LoadScene("SampleScene");
    }
}
