using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public float rockSpeed;
	public AudioClip playerPass;
	AudioSource rockAS;

	void Start () {
		rockAS = GetComponent<AudioSource>();
		transform.position = 
		new Vector3 (
			transform.position.x,
			transform.position.y+Random.Range(-4f,7f),0
		);
	}
	
	void Update () {
		transform.Translate (Vector3.left*rockSpeed);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1);
			rockAS.PlayOneShot (playerPass);

		}
	}
}
