/*Play scene
	Looping background, Seabed and rocks
	playing sonar sound*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour {

	float bgNumber = 2;
	float rockNumber = 10;
	public AudioClip sonar;	//AudioClip variable from editor input
	AudioSource sonarAS;

	void Start(){
		sonarAS = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider){

		float bgWidth = ((BoxCollider2D)collider).size.x;

		Vector2 pos = collider.transform.position;

		if (collider.gameObject.tag == "BG") {
			pos.x += bgWidth * bgNumber;
		}
		else if (collider.gameObject.tag == "Rock") {
			pos.x += 3 * rockNumber;
			pos.y = Random.Range(-4f,6f); //random
			sonarAS.PlayOneShot (sonar); //sonar sound
		}

		collider.transform.position = pos;

		// if (collider.gameObject.tag == "BG") {
		// 	sonarAS.PlayOneShot (sonar); //sonar sound
		// }
	}
}
