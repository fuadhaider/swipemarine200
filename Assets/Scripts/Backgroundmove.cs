using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmove : MonoBehaviour {

	public float speed;

	void Update () {
		transform.Translate (Vector3.left * speed);
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	
	}
}
