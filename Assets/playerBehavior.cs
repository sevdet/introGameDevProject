using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

	private float speed;
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	private Vector2 pointOfCollision; // point the player collides with a wall so enemy can follow this point
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		speed = 4;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		rb.gravityScale = 0; // want collision but top down so no gravity

	}
	
	// Update is called once per frame
	void Update () {
		xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
		yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S/up/down key presses 

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed); 
	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "wall") {
			Debug.Log ("collided with wall");
			pointOfCollision = rb.transform.position;
		}
	}

}
