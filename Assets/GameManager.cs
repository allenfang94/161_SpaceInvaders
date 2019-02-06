using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int playerLives = 3;
    public static int score = 0;
    public static bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(playerLives <= 0)
        {
            gameOver = true;
        }
    }
}
