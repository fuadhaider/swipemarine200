/*Play scene
	It sets rocks on a random y axis,
	moves the rocks,
	adds score & Top score,
	Calling Interstitial ad function,
	plays audio when submarine goes through the rocks
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public float rockSpeed;
	public AudioClip playerPass;	//AudioClip variable from editor input
	AudioSource rockAS;
	public AdMobManager adMobManager;

	void Start () {
		rockAS = GetComponent<AudioSource>();
		transform.position =
		new Vector3 (
			transform.position.x,
			// transform.position.y+1, 0  //static
        // transform.position.y +
				Random.Range(-4f,6f),0  //random
        );  //-4,7; 0,2
    }

	void Update () {
		transform.Translate (Vector3.left * rockSpeed);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			int score = PlayerPrefs.GetInt ("Score");
			int highScore = PlayerPrefs.GetInt ("HighScore");
			PlayerPrefs.SetInt ("Score", ++score);
			// if (score == 2) {
			//
			// }
			if (score != 0 && score % 3 == 0) {
				PlayerPrefs.SetInt("HighScore", highScore + 3 );
				Debug.Log("inter ad req ________");
				adMobManager.RequestInterstitial(); // Calling Interstitial Ad
			}
			rockAS.PlayOneShot (playerPass);
		}
	}
}
