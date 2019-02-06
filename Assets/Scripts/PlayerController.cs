using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 7.5f;

    public static bool canShoot = true;
    public GameObject playerBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (this.transform.position.x > 7.5)
        {
            this.transform.position = new Vector3(7.5f, -4f, 0f);
        }
        else if (this.transform.position.x < -7.5)
        {
            this.transform.position = new Vector3(-7.5f, -4f, 0f);
        }

        if (canShoot && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            canShoot = false;
            Instantiate(playerBullet, this.transform.position, Quaternion.identity);
        }
    }
}
