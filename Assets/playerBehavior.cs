using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

	public Rigidbody2D playerRB;
	SpriteRenderer playerSprite;
	public float speed;
	Vector2 direction;
	Vector2 movement;
	public Vector2 playerStartingPosition;

	// Use this for initialization
	void Start () {
		playerRB = this.GetComponent<Rigidbody2D> ();
		playerSprite = this.GetComponent<SpriteRenderer> ();
		speed = 4;
	}
	
	// Update is called once per frame
	void Update () {
		move ();

	}

	void move() {
		direction = Vector2.zero;

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			direction.x = 1;
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			direction.x = -1;
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			direction.y = 1;
		}

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			direction.y = -1;
		}

		transform.Translate(direction * speed * Time.deltaTime);
	}
		
}
