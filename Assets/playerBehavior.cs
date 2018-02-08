using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

	private float speed;
	private float xAxis;
	private float yAxis;
	private bool moving;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		speed = 4;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.gravityScale = 0;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

	}
	
	// Update is called once per frame
	void Update () {
		xAxis = Input.GetAxis ("Horizontal");
		yAxis = Input.GetAxis ("Vertical");

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);
	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "prototypeMazeWall") {
			Debug.Log ("collided with wall");
		}
	}

}
