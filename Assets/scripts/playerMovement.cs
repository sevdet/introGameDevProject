using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Audio;

public class playerMovement : MonoBehaviour {

	public float speed; // speed of player
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	public Animator animationController; // controlling animation for when enemy picks up a powerup
	public Rigidbody2D rb;
	//bool isCollecting = false;
	public ParticleSystem particles; // this will come out when player is close to enemy

	// player starts randomly from any of the four positions below
	static Vector2 startPos1 = new Vector2(-8.36f,-4.38f);
	static Vector2 startPos2 = new Vector2 (-8.36f, 4.38f);
	static Vector2 startPos3 = new Vector2(8.53f, -4.38f);
	static Vector2 startPos4 = new Vector2 (8.4f, 4.38f);

	Vector2[] startPositions = { startPos1, startPos2, startPos3, startPos4 };


	// Use this for initialization
	void Start () {
		//goalCount = 0;
		speed = 3;
		animationController = this.GetComponent<Animator> ();
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		rb.gravityScale = 0; // want collision but it's topdown so there's no gravity
		particles = this.GetComponent<ParticleSystem>();

		// handling choosing a random start position for player
		int randPos = Random.Range(0,4); // choosing random index in startPositions array
		rb.transform.position = startPositions[randPos];

	}

	// Update is called once per frame
	void Update () {

		/*
		if (isCollecting) { // if player has just picked up a sparkly
			animationController.Play ("pickupSparkle"); // play the powering up animation
		} else { // if player hasn't just picked something up 
			animationController.Play ("player_idle"); // play its idle animation
		}
		*/	


		xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
		yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S/up/down key presses 

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);  // moves player

		if (Vector3.Distance (GameObject.FindWithTag ("enemy").transform.position, 
			rb.transform.position) < 2.5f) {
			particles.Play ();
		} else {
			particles.Stop ();
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "goal") { // if a sparkly is picked up
			//isCollecting = true;
			animationController.SetTrigger("pickup");
		}


	}

}
