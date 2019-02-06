using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {
    
	float moveSpeed = 3f;   
    public List<int> UFO_Scores = new List<int>();

	// Use this for initialization
	void Start () {      
        UFO_Scores[0] = 100;
        UFO_Scores[1] = 150;
        UFO_Scores[2] = 200;
        UFO_Scores[3] = 250;
        UFO_Scores[4] = 300;

		if(Random.Range(1f, 2f) > 1.5f)
		{
			this.transform.position = new Vector3(-10f, 6f, 0);
		}
		else
		{
			this.transform.position = new Vector3(10f, 6f, 0);
			moveSpeed = -moveSpeed;
		}

		Destroy(this.gameObject, 10f);      
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

	}
}
