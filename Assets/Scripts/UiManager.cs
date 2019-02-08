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

		if(GameManager.gameOver)
		{
            EnemyShoot.usedScore = 0;
			GameOver.SetActive(true);
			PlayerPrefs.SetInt("win", 0);
			Time.timeScale = 0;
            EnemyShoot.ufo_score = 0;
		}

		if(GameManager.enemyKilled % 55 == 0 && GameManager.enemyKilled != 0) //test
		{
            EnemyShoot.usedScore = GameManager.score;
            EnemyShoot.ufo_score = 0;
            EnemyMove.leftBoundary = -4.5f;
            EnemyMove.rightBoundary = 4.5f;
            EnemyShoot.leftBorder = 0;
            EnemyShoot.rightBorder = 10;
            PlayerPrefs.SetInt("score", GameManager.score);         
            PlayerPrefs.SetInt("lives", GameManager.playerLives + 1);         
			PlayerPrefs.SetFloat("enemy_move_rate", GameManager.enemy_move_rate/2);  
			PlayerPrefs.SetFloat("enemy_shot_rate", GameManager.enemy_shot_rate/2);
            PlayerPrefs.SetInt("kills", 0);   
			SceneManager.LoadScene("InGame");


			PlayerPrefs.SetFloat("next_enemies_y", PlayerPrefs.GetFloat("next_enemies_y") - 1);

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
        EnemyMove.leftBoundary = -4.5f;
        EnemyMove.rightBoundary = 4.5f;
        EnemyShoot.leftBorder = 0;
        EnemyShoot.rightBorder = 10;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("kills", 0);
		PlayerPrefs.SetFloat("next_enemies_y", 0);
		PlayerPrefs.SetFloat("enemy_move_rate", 0.8f);
		PlayerPrefs.SetFloat("enemy_shot_rate", 2f);
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
