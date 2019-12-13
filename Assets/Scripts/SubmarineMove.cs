using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineMove : MonoBehaviour {

	bool dead = false;
	Rigidbody2D rb;
	// public float maxTime;	//maximun allowed swipe time
	// float startTime;
	// float endTime;
	float swipeTime;
	Vector2 startPos;
	Vector2 endPos;
	bool swipeStarted = false;
	float swipeDis;
	public float swipeSpeed;
	public AudioClip deadSound;
	AudioSource playerAS;

	void Awake () {
		PlayerPrefs.SetInt ("Score", 0);
		rb = GetComponent<Rigidbody2D>();
		playerAS = GetComponent<AudioSource>();
	}

  void Update()
  {
		// if (Input.GetMouseButtonDown(0)) {
    //     startTime = Time.time;
    //     startPos = Input.mousePosition;
		// }
		// else if (Input.GetMouseButtonUp(0)) {
    //     startTime = Time.time;
    //     endPos = Input.mousePosition;
		// 
    //     swipeDis = (endPos - startPos).magnitude;
    //     swipeTime = endTime - startTime;
		// 
    //     if (swipeTime < maxTime)
    //     {
    //         swipe();
    //     }
		// }
    if (Input.touchCount > 0 && !dead)
    {
        Touch touch = Input.GetTouch(0);
		
        if (touch.phase == TouchPhase.Began)
        { //first touch
          // startTime = Time.time;
          startPos = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved)
        {  //latest moved position
            // endTime = Time.time;
					
						endPos = touch.position;
            swipeDis = (endPos - startPos).magnitude;
						// (a-b).magnitude is the distance between them
            // swipeTime = endTime - startTime;
		
            // if (swipeTime < maxTime)
            // {
                swipe();
            // }
						startPos = endPos;

        }
        else if (touch.phase == TouchPhase.Ended)
        {  //finger removed
            // endTime = Time.time;
            endPos = touch.position;
		
            swipeDis = (endPos - startPos).magnitude;
            // swipeTime = endTime - startTime;
		
            // if (swipeTime < maxTime)
            // {
                swipe();
            // }
        }
    }
  }
		
	void swipe(){
		if (endPos.y > startPos.y) {
			rb.AddForce (new Vector2 (0 , swipeSpeed * swipeDis * Time.deltaTime));
			// Time.deltaTime moves item by time rather than by frame.
			// it is a fragment of a second or the time passed since the last frame.
			//1st rb.AddForce(transform.up * swipeSpeed*swipeDis*Time.deltaTime);
			//2nd swipespeed:.05, deltatime:75
			//rb.velocity = new Vector2 (rb.velocity.x, swipeDis * swipeSpeed*Time.deltaTime);
			//2nd swipespeed:.05, deltatime:1
		} 
		else {
			rb.AddForce (new Vector2 (0 , -swipeSpeed * swipeDis * Time.deltaTime));
			//rb.AddForce(-transform.up * swipeSpeed*swipeDis*Time.deltaTime);
			//rb.velocity = new Vector2 (rb.velocity.x, -swipeDis * swipeSpeed*Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt ("Score"));
		Application.LoadLevel (Application.loadedLevel);
		playerAS.PlayOneShot(deadSound);
		dead = true;
	} 
}
