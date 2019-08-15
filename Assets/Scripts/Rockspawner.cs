using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockspawner : MonoBehaviour {
	public float startTime;
	public float frequency;
	public GameObject rock;

	void Start () {
		InvokeRepeating ("Spawnrock",startTime,frequency);
	}
	
	void Spawnrock () {
		Instantiate (rock,transform.position,Quaternion.identity);
	}
}
