using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject enemyBullet;

    static public int leftBorder = 0;
    static public int rightBorder = 10;
    static public int usedScore = 0;

    public GameObject[] enemy_1;
    public GameObject[] enemy_2;
    public GameObject[] enemy_3;
    public GameObject[] enemy_4;
    public GameObject[] enemy_5;
    public GameObject[] enemy_6;
    public GameObject[] enemy_7;
    public GameObject[] enemy_8;
    public GameObject[] enemy_9;
    public GameObject[] enemy_10;
    public GameObject[] enemy_11;

    GameObject[][] array = new GameObject[11][];

	public float max_shoot_rate = 2f;
    public float shoot_rate;
    public static int ufo_score = 0;


    // Use this for initialization
    void Start () {
        array[0] = enemy_1;
        array[1] = enemy_2;
        array[2] = enemy_3;
        array[3] = enemy_4;
        array[4] = enemy_5;
        array[5] = enemy_6;
        array[6] = enemy_7;
        array[7] = enemy_8;
        array[8] = enemy_9;
        array[9] = enemy_10;
        array[10] = enemy_11;

		max_shoot_rate = PlayerPrefs.GetFloat("enemy_shot_rate");
		shoot_rate = max_shoot_rate;
		//Debug.Log(max_shoot_rate);
    }
	
	// Update is called once per frame
    void Update () {      
        changeBoarder();
        updateSize();

		shoot_rate -= Time.deltaTime;
        
		if (shoot_rate <= 0f)
        {
			shoot_rate = Random.Range(max_shoot_rate, 2* max_shoot_rate);
            shootBullet();
        }
        calculateScore();

        if (GameManager.gameOver)
        {
            leftBorder = 0;
            rightBorder = 10;
            EnemyMove.rightBoundary = 4.5f;
            EnemyMove.leftBoundary = -4.5f;
        }
        if (GameManager.enemyKilled % 55 == 0 && GameManager.enemyKilled != 0)
        {
            leftBorder = 0;
            rightBorder = 10;
            EnemyMove.rightBoundary = 4.5f;
            EnemyMove.leftBoundary = -4.5f;
        }
    }

    void updateSize()
    {
        for(int x=0; x<=10; x += 1)
        {
            int length = array[x].Length;
            for(int y=0; y<length; y += 1)
            {
                 if(array[x][y] == null)
                {
                    length -= 1;
                }
            }

            GameObject[] temp = new GameObject[length];
            for (int z=0; z<length; z+=1)
            {
                temp[z] = array[x][z];
            }

            array[x] = temp;
        }
    }

    void shootBullet()
    {
        int colNum = Random.Range(0, 11);
		Vector3 pos = new Vector3(0f, 0f, 0f);
		while (array[colNum].Length <= 0)
			colNum = Random.Range(0, 11);      
        pos = array[colNum][array[colNum].Length-1].transform.position;
        Instantiate(enemyBullet, pos, Quaternion.identity);
    }

    public void calculateScore()
    {
        int score = 0;
        for (int x = 0; x <= 10; x += 1)
        {
            if (array[x].Length == 0)
                score += 100;
            else if (array[x].Length == 1)
                score += 60;
            else if (array[x].Length == 2)
                score += 40;
            else if (array[x].Length == 3)
                score += 20;
            else if (array[x].Length == 4)
                score += 10;
        }
        GameManager.score = score + ufo_score + usedScore;
    }

    public void changeBoarder(){

        if (array[leftBorder].Length == 0){
            print(array[leftBorder].Length);
            leftBorder += 1;
            EnemyMove.leftBoundary -= 1;
        }

        if(array[rightBorder].Length == 0){
            print(array[rightBorder].Length);
            rightBorder -= 1;
            EnemyMove.rightBoundary += 1;
        }

        
    }
}
