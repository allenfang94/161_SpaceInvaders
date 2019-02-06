using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject enemyBullet;

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

    private float rate = 2f;


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
    }
	
	// Update is called once per frame
	void Update () {
        updateSize();

        rate -= Time.deltaTime;

        if (rate <= 0f)
        {
            rate = Random.Range(2f, 8f);
            shootBullet();
        }
        calculateScore();
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
        Vector3 pos = array[colNum][array[colNum].Length-1].transform.position;
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
        
        GameManager.score = score;
    }
}
