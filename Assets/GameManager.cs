using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int playerLives = 3;
    public static int score;

    public static bool gameOver = false;
	public static int enemyKilled = 0;
	public static float next_enemies_y = 0;

	// Use this for initialization
	void Start () {

		score = PlayerPrefs.GetInt("score");
		playerLives = PlayerPrefs.GetInt("lives");
		enemyKilled = PlayerPrefs.GetInt("kills");
      
		next_enemies_y = PlayerPrefs.GetFloat("next_enemies_y");
      
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(playerLives <= 0)
        {
            gameOver = true;
        }
    }
}
