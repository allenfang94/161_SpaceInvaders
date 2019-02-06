using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, -10f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.playerLives -= 1;
            Destroy(this.gameObject);
            print("Touched: ");
            print(GameManager.playerLives);
        }
    }
}
