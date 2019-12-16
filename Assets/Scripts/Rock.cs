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
      //       transform.position.y+1, 0  //static
        transform.position.y+Random.Range(-4f,7f),0  //random
        );  //0,2
    }
	
	void Update () {
		transform.Translate (Vector3.left * rockSpeed);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			int score = PlayerPrefs.GetInt ("Score");
			int highScore = PlayerPrefs.GetInt ("HighScore");
			PlayerPrefs.SetInt ("Score", ++score);
			if (score % 15 == 0) {
				PlayerPrefs.SetInt("HighScore", highScore + score );
			}
			rockAS.PlayOneShot (playerPass);
		}
	}
}
