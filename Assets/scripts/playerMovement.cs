using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	public float speed;
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	public Rigidbody2D rb;
	//private int goalCount; // number of sparklies the player collects, win when 5 are collected
	public bool isWASDPlayer;

	// Use this for initialization
	void Start () {

		//goalCount = 0;
		speed = 3;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		rb.gravityScale = 0; // want collision but top down so no gravity

	}

	// Update is called once per frame
	void Update () {
		
		if (isWASDPlayer) {
			xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D key presses for player 1
			yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S key presses for player 1

			transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);
		}
		else {
			xAxis = Input.GetAxis ("Horizontal2"); // handle direction for left/right key presses for player 2
			yAxis = Input.GetAxis ("Vertical2"); // handle direction for up/down key presses for player 2

			transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);
		}

	}


	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "enemy") {
			Destroy (this.gameObject);
			Debug.Log ("lost");
		}
	}
}
