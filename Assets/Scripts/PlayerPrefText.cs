using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour {

	public string name;
	
	// void start() {
	// 	PlayerPrefs.SetInt ("HighScore", 0);
	// }

	void Update () {
    GetComponent<Text>().text = PlayerPrefs.GetInt(name) + "";
    //get score and top score seperately and show in Text component
    // + ""; converts int into string
	}
}
