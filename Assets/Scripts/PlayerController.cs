using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	private Rigidbody2D r;
	private bool isCtrlLocked;
	public BoxCollider2D digDownPosition, digLeftPosition, digRightPosition; // Get dig Positions from Character

	public FeetController feetController;

	void Start () {
		r = GetComponent<Rigidbody2D>();
		isCtrlLocked = false;
	}

	// Update is called once per frame
	void Update () {

		// If moving is possible
		if(!isCtrlLocked){
			// Multiply speed and axis tilt
			float moveHorizontal = (Input.GetAxis("Horizontal") * speed);
			r.velocity = new Vector2(moveHorizontal, r.velocity.y);


			if(Input.GetButton("Jump") && feetController.canJump){
				r.velocity = new Vector2(r.velocity.x, 15);
				feetController.canJump = false;
			}
			
			if(Input.GetButton("Fire1")){
				if(Input.GetAxis("Vertical") < 0 ){
					destoryBlockDown();
				}
				else if(Input.GetAxis("Horizontal") > 0){
					destoryBlockLeft();
				}
				else if(Input.GetAxis("Horizontal") < 0){
					destoryBlockRight();
				}	
			}
		}
	}

    private void destoryBlockDown()
    {
        Collider2D[] colliders = new Collider2D[10];
		digDownPosition.GetContacts(colliders);
		colliders[0].gameObject.SetActive(false);
    }

	private void destoryBlockLeft()
    {
        Collider2D[] colliders = new Collider2D[10];
		digLeftPosition.GetContacts(colliders);
		colliders[0].gameObject.SetActive(false);
    }

	private void destoryBlockRight()
    {
        Collider2D[] colliders = new Collider2D[10];
		digRightPosition.GetContacts(colliders);
		colliders[0].gameObject.SetActive(false);
    }

}
