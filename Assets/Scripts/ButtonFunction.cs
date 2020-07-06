/*Menu scene
	button function to navigate to play Scene
	play sound
	quit on clicking android back button*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour {
	public AudioClip play;	//AudioClip variable from editor input
	AudioSource playAS;

	void Start(){
		playAS = GetComponent<AudioSource>();
	}
	public void Reload(){
		SceneManager.LoadScene (1);	//Load scene 1 when reloading
		playAS.PlayOneShot(play);	//play sound upon clicking play button
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();	//quit on android back key
		}
	}

}
