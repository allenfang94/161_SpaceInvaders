using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

	public int health = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0)
		{
			Destroy(this.gameObject);
		}
	}

	public void takeDamage()
	{
		health -= 1;
	}
}
