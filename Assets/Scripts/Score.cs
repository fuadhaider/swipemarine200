using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int score = 0;
    // static int stage = 0;
  static int highScore;	// =0;
	Text text;

	static public void AddPoint(){
		score++;
    if ((score % 3) == 0){
        // stage++;
				if (score > highScore) {
					PlayerPrefs.SetInt("highScore", score);
				}
    }
    // if (score > highScore){
    //     highScore = score;
    // }
  }
    
	void start(){
		PlayerPrefs.GetInt ("highScore",0);
        //param 1: get value of "highScore" key from player preference file
        //param 2: if not then set default 0
	}

	void OnDestroy(){
		PlayerPrefs.SetInt ("highScore", highScore);
        //set highScore value in player preference file at end
	}

	/*void awake () {
		text = GetComponent<Text> ();
		//score = 0;
		//PlayerPrefs.SetInt ("Score", 0);

	}*/

	// Update is called once per frame and update scores
	void Update () {
        //ScoreManager.text = "Score: " + score;
        //text.text = "Score: " + score + "\nHigh Score: " + highScore;
    }
}

/*old code*/
// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// 
// public class Score : MonoBehaviour {
// 
// 	static int score = 0;
//     //static int stage = 0;
//     static int highScore = 0;
// 	Text text;
// 
// 	static public void AddPoint(){
// 		score++;
//         if ((score % 3) == 0){
//             //stage++;
//             //PlayerPrefs.SetInt("highScore", highScore);
// 
//         }
//         if (score > highScore){
//             highScore = score;
//         }
//     }
// 
// 	void start(){
// 		PlayerPrefs.GetInt ("highScore",0);
//         //param 1: get value of "highScore" key from player preference file
//         //param 2: if not then set default 0
// 	}
// 
// 	void OnDestroy(){
// 		PlayerPrefs.SetInt ("highScore", highScore);
//         //set highScore value in player preference file at end
// 	}
// 
// 	/*void awake () {
// 		text = GetComponent<Text> ();
// 		//score = 0;
// 		//PlayerPrefs.SetInt ("Score", 0);
// 
// 	}*/
// 
// 	// Update is called once per frame and update scores
// 	void Update () {
//         //ScoreManager.text = "Score: " + score;
//         //text.text = "Score: " + score + "\nHigh Score: " + highScore;
//     }
// }
