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

        if(this.transform.position.y >= 5.0f)
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
            PlayerController.canShoot = true;
            Destroy(gameObject);
        }
    }
}
