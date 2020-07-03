using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundmove : MonoBehaviour {

	public float speed;	//smove peed input from editor inspector

	void Update () {
		transform.Translate (Vector3.left * speed);
		//3D vector constructor with going left property * speed
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

	}
}
