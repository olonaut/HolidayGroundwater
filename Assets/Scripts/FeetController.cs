using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour {

	public bool canJump = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("I just collided with " + other.ToString());
		if(other.gameObject.CompareTag("JumpSurface")){
			canJump = true;
		}
	}

}
