using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private int direction = 1;
    public float speed = 0.1f;
    public float rate = 0.4f;
	public float Boundary = 4.5f;

	public List<GameObject> children = new List<GameObject>();

    // Use this for initialization
    void Start() {
		this.gameObject.transform.Translate(gameObject.transform.position.x, GameManager.next_enemies_y, 0f);

		int children_num = gameObject.transform.childCount;
		for (int i = 0; i < children_num; ++i)
		{
			children[i] = transform.GetChild(i).gameObject;
		}      
    }

    // Update is called once per frame
    void Update() {
        rate -= Time.deltaTime;
        if (rate <= 0f)
        {
            rate = 0.75f;
            transform.position = new Vector3(transform.position.x + direction * 0.5f, transform.position.y, transform.position.z);

			if (transform.position.x >= Boundary || transform.position.x <= -Boundary)
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
