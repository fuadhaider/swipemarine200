using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

	int bgNumber = 2;
	public AudioClip sonar;
	AudioSource sonarAS;

	void Start(){
		sonarAS = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
	
		float bgWidth = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += bgWidth * bgNumber;

		collider.transform.position = pos;

		if (collider.gameObject.tag == "BG") {
			sonarAS.PlayOneShot (sonar);

		}	
	}
}
