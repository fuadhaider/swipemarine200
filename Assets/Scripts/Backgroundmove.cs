/*Play scene
	Moving backdrop and Seabed,
	speed variable
	Quit option*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

	public float speed;	//moving speed, input on editor inspector
		// Backdrop 0.07
		// Seabed 0.09

	void Update () {
		transform.Translate (Vector3.left * speed);
		//3D vector constructor with going left property * speed
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit(); //quit game when clicking the back key on android
		}
	}
}
