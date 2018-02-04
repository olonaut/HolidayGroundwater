using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	private Rigidbody2D r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D>();
	}

	
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = (Input.GetAxis("Horizontal") * speed);
        r.velocity = new Vector2(moveHorizontal, r.velocity.y);

		if(Input.GetButton("Jump")){
			r.velocity = new Vector2(r.velocity.x, 15);
		}

	}
}
