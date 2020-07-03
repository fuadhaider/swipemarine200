using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

	public float rockSpeed;
	public AudioClip playerPass;
	AudioSource rockAS;
	public AdMobManager adMobManager;	// 5

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
			if (score != 0 && score % 3 == 0) {
				PlayerPrefs.SetInt("HighScore", highScore + 3 );

				// interstitial
				// AdMobManager amm = new AdMobManager();
				// amm.RequestInterstitial();	// 1
				// AdMobManager.RequestInterstitial();	// 2
				// AdObject.GetComponent<AdMobManager>().RequestInterstitial();	// 3
				// AdMobManager ad = AdObject.GetComponent<AdMobManager>();
				// ad.RequestInterstitial();  // 4
				Debug.Log("inter ad req ________");
				adMobManager.RequestInterstitial(); // Calling Interstitial Ad

			}
			rockAS.PlayOneShot (playerPass);
		}
	}
}
