using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private int direction = 1;
    public float speed = 0.1f;
    public float rate = 0.4f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        rate -= Time.deltaTime;
        if (rate <= 0f)
        {
            rate = 0.75f;
            transform.position = new Vector3(transform.position.x + direction * 0.5f, transform.position.y, transform.position.z);

            if (transform.position.x >= 3.5f || transform.position.x <= -3.5f)
            {
                direction *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
            }
        }

        if(transform.position.y <= -2.5f)
        {
            GameManager.gameOver = false;
        }

	}
}
