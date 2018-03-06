using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class enemyBehavior : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// rotate enemy to face player
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);

		// translating enemy towards position of player
		if (Vector3.Distance(transform.position,target.position) > 0.4f){
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
			Destroy (coll.gameObject);
			speed += 0.3f;
			transform.localScale = Vector2.Lerp (transform.localScale, new Vector2 (0.4f, 0.4f), Time.deltaTime);
		}
	}

}
