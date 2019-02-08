using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int score;   
    public static int playerLives = 3;
	public static int enemyKilled = 0;
	public static float enemy_move_rate;
    public static float enemy_shot_rate;
    public static float next_enemies_y = 0;
	public static bool gameOver = false;

	public GameObject UFO;
	public float UFO_rate = 10;

	// Use this for initialization
	void Start () {      
		score = PlayerPrefs.GetInt("score");
		playerLives = PlayerPrefs.GetInt("lives");
		enemyKilled = PlayerPrefs.GetInt("kills");
		enemy_move_rate = PlayerPrefs.GetFloat("enemy_move_rate");
		enemy_shot_rate = PlayerPrefs.GetFloat("enemy_shot_rate");
		next_enemies_y = PlayerPrefs.GetFloat("next_enemies_y");
      
		gameOver = false;

        Screen.SetResolution(1920, 1080, true);
    }
	
	// Update is called once per frame
	void Update () {

        if(playerLives <= 0)
        {
            gameOver = true;
        }

		UFO_rate -= Time.deltaTime;
		if (UFO_rate <= 0f)
        {
			UFO_rate = Random.Range(15f, 20f);
			Instantiate(UFO);
        }
    }
}
