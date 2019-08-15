using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;
	Text text;

	static public void AddPoint(){
		score++;

		if (score > highScore) {
			highScore = score;
		}
	}

	void start(){
		PlayerPrefs.GetInt ("highScore",0);
	
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("highScore", highScore);
	}
	/*void awake () {
		text = GetComponent<Text> ();
		//score = 0;
		//PlayerPrefs.SetInt ("Score", 0);

	}*/


	
	// Update is called once per frame
	void Update () {
		//ScoreManager.text = "Score: " + score ;
		//text.text = "Score: "+score+ "\nHigh Score: "+highScore;
	}
}
