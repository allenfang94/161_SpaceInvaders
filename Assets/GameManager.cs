using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int playerLives = 3;
    public static int score = 0;
    public static bool gameOver = false;
	public static int enemyKilled = 0;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("score", 0);
		PlayerPrefs.SetInt("lives", 3);
		PlayerPrefs.SetInt("kills", 0);
		PlayerPrefs.SetInt("gameover", 0);
		score = PlayerPrefs.GetInt("score");
		playerLives = PlayerPrefs.GetInt("lives");
		enemyKilled = PlayerPrefs.GetInt("kills");
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(playerLives);
        if(playerLives <= 0)
        {
            gameOver = true;
        }

		//Debug.Log(enemyKilled);
    }
}
