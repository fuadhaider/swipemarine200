using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bf : MonoBehaviour {
	public AudioClip play;
	AudioSource playAS;
	void Start(){
		playAS = GetComponent<AudioSource>();
	}
	public void Reload(){
		SceneManager.LoadScene (1);
		playAS.PlayOneShot(play);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
		
}
