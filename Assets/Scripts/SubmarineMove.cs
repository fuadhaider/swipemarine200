using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMove : MonoBehaviour {

	bool dead = false;	// submarine is not dead
	Rigidbody2D rb;	// submarine
	Vector2 startPos, endPos;	// swipe positions
	float swipeDis;
	public float swipeSpeed;
	public AudioClip deadSound;
	AudioSource playerAS;

	void Awake () {
		PlayerPrefs.SetInt ("Score", 0);	// set current score 0
		rb = GetComponent<Rigidbody2D>();
		playerAS = GetComponent<AudioSource>();
	}

  void Update() {
    if (Input.touchCount > 0 && !dead) {
      Touch touch = Input.GetTouch(0);
	    if (touch.phase == TouchPhase.Began) {	// first touch
        startPos = touch.position;
      }
      else if (touch.phase == TouchPhase.Moved) {  // latest touch position
				endPos = touch.position;
        swipeDis = (endPos - startPos).magnitude;
				// (a-b).magnitude is the distance between them
        swipe();
				startPos = endPos;
      }
      else if (touch.phase == TouchPhase.Ended) {  // finger removed
        endPos = touch.position;
        swipeDis = (endPos - startPos).magnitude;
        swipe();
      }
    }
  }

	void swipe(){
		if (endPos.y > startPos.y) {
			rb.AddForce (new Vector2 (0 , swipeSpeed * swipeDis * Time.deltaTime));
			// Time.deltaTime moves item by time rather than by frame.
			// it is a fragment of a second or the time passed since the last frame.
		}
		else {
			rb.AddForce (new Vector2 (0 , -swipeSpeed * swipeDis * Time.deltaTime));
		}
	}

	void OnCollisionEnter2D(Collision2D col) {	// after death
		Application.LoadLevel (Application.loadedLevel);	// load new game
		playerAS.PlayOneShot(deadSound);
		dead = true;
	}
}
