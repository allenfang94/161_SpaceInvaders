using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private int direction = 1;
    public float speed = 0.1f;
	public float max_rate = 0.8f;
    public float rate = 0;
	static public float leftBoundary = -4.5f;
    static public float rightBoundary = 4.5f;

    public List<GameObject> children = new List<GameObject>();

    // Use this for initialization
    void Start() {
		this.gameObject.transform.Translate(gameObject.transform.position.x, GameManager.next_enemies_y, 0f);

		int children_num = gameObject.transform.childCount;
		for (int i = 0; i < children_num; ++i)
		{
			children[i] = transform.GetChild(i).gameObject;
		}
		max_rate = GameManager.enemy_move_rate;
    }

    // Update is called once per frame
    void Update() {
        rate -= Time.deltaTime;
        if (rate <= 0f)
        {
			rate = max_rate;
            transform.position = new Vector3(transform.position.x + direction * 0.5f, transform.position.y, transform.position.z);

			if (transform.position.x >= rightBoundary || transform.position.x <= leftBoundary)
            {
                direction *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);
            }
        }

        if(transform.position.y <= -3f)
        {
			GameManager.gameOver = true;
        }      
	}
}
