using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerBehavior : MonoBehaviour {

	public float speed;
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	private Vector2 pointOfCollision; // point the player collides with a wall so enemy can follow this point
	public Rigidbody2D rb;
	private Vector2 startPosition;
	private int goalCount; // number of sparklies the player collects, win when 5 are collected
	public Animator animationController;


	// Use this for initialization
	void Start () {
		
		goalCount = 0;
		startPosition = new Vector2(-8.16f,-4.39f);
		speed = 3;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		rb.gravityScale = 0; // want collision but top down so no gravity

	}
	
	// Update is called once per frame
	void Update () {

		animationController.Play ("player_idle");

		xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
		yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S/up/down key presses 

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed); 

		if (goalCount == 5) {
			Debug.Log ("won");
			SceneManager.LoadScene ("winScene");
		}

	}
		

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "wall") {
			Debug.Log ("collided with wall at " + rb.transform.position);
			pointOfCollision = rb.transform.position;
		}

		if (coll.gameObject.tag == "goal") {
			Destroy (coll.gameObject);
			Debug.Log ("collected a sparkly");
			goalCount += 1;
		}

		if (coll.gameObject.tag == "enemy") {
			Debug.Log ("lost");
			SceneManager.LoadScene ("loseScene");
		}
	}
}
