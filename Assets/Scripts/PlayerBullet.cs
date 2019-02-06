using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
    


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 15f * Time.deltaTime, 0f);

        if(this.transform.position.y >= 9.0f)
        {
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
			GameManager.enemyKilled += 1;
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }      
		if (collision.gameObject.tag == "shield")
        {
            collision.gameObject.GetComponent<shield>().takeDamage();
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
		if (collision.gameObject.tag == "UFO")
        {         
			int ufo_score;
			int score_index = Random.Range(0, collision.gameObject.transform.GetComponent<UFO>().UFO_Scores.Count);
			ufo_score = collision.gameObject.transform.GetComponent<UFO>().UFO_Scores[score_index];         
			Destroy(collision.gameObject);         
			PlayerPrefs.SetInt("score", GameManager.score + ufo_score);
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
    }
}
