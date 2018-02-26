using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class enemyBehavior : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float speed;

	// Use this for initialization
	void Start () {
		speed = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {

		// rotate enemy to face player
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);

		// translating enemy towards position of player FOR NOW
		// going to eventually make the target be the player's last point of collision w the wall
		if (Vector3.Distance(transform.position,target.position) > 0.8f){
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "player") {
			Debug.Log ("lost");
			EditorSceneManager.LoadScene ("loseScene");
		}
			
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "powerup") {
			Debug.Log ("enemy got powerup");
			coll.transform.Translate(new Vector2(100,100));
			speed += 0.2f;
			transform.localScale = Vector2.Lerp (transform.localScale, new Vector2 (0.4f, 0.4f), Time.deltaTime);
		}
	}

}
