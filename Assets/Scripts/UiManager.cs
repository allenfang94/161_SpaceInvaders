using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    
	public GameObject score;
	public GameObject lives;
	public GameObject GameOver;
	public GameObject Pause_UI;
	Text score_text;
	Text lives_text;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		GameOver.SetActive(false);
		Pause_UI.SetActive(false);
		score_text = score.GetComponent<Text>();
		lives_text = lives.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		score_text.text = ("Score: " + GameManager.score.ToString());
		lives_text.text = ("Lives: " + GameManager.playerLives.ToString());

		if(GameManager.gameOver || GameManager.enemyKilled == 55)
		{
			GameOver.SetActive(true);
			Time.timeScale = 0;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Pause_UI.activeSelf == true)
			{
				Pause_UI.SetActive(false);
				Time.timeScale = 1;
			}
			else
			{
				Pause_UI.SetActive(true);
				Time.timeScale = 0;
			}
		}
	}

	public void startGame()
	{
		SceneManager.LoadScene("InGame");
	}

    public void quitGame()
	{
		Application.Quit();
	}

    public void continueGame()
	{
		Pause_UI.SetActive(false);
        Time.timeScale = 1;
	}
}
