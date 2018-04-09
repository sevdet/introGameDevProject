using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Audio;

public class playerMovement : MonoBehaviour {

	public float speed; // speed of player
	private float xAxis; // move right when 1 move left when -1
	private float yAxis; // move up when 1 move down when -1
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		//goalCount = 0;
		speed = 3;
		rb = this.GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Dynamic; 
		rb.gravityScale = 0; // want collision but it's topdown so there's no gravity

	}

	// Update is called once per frame
	void Update () {
		
		xAxis = Input.GetAxis ("Horizontal"); // handle direction for A/D/left/right key presses
		yAxis = Input.GetAxis ("Vertical"); // handle direction for W/S/up/down key presses 

		transform.Translate (new Vector2 (xAxis, yAxis) * Time.deltaTime * speed);  // moves player

	}
		
}
