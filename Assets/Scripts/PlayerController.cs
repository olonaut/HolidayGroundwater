using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	private Rigidbody2D r;
	private bool isJumpLocked = false; // Lock jump to prevent spam. 
	public BoxCollider2D digDownPosition;

	void Start () {
		r = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        float moveHorizontal = (Input.GetAxis("Horizontal") * speed);
        r.velocity = new Vector2(moveHorizontal, r.velocity.y);

		if(Input.GetButton("Jump") && !isJumpLocked){
			r.velocity = new Vector2(r.velocity.x, 15);
			isJumpLocked = true;
		}

		if(Input.GetButton("Fire1")){
			if(Input.GetAxis("Vertical") < 0 ){
				destoryBlockDown();
			}
		}
	}

    void OnTriggerEnter2D(Collider2D other){
		Debug.Log("I just collided with " + other.ToString() + ". Fuck!");
		if(other.gameObject.CompareTag("JumpSurface")){
			isJumpLocked = false;
		}
	}

    private void destoryBlockDown()
    {
        throw new NotImplementedException();
    }

}
