using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallManager : MonoBehaviour {

	public Vector2 pointOfCollision;

	// Use this for initialization
	void Start () {
		pointOfCollision = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("collided with wall");
		Debug.Log ("point of collision: " + GameObject.Find ("prototypePlayer").transform.position);
		GameObject.Find ("prototypePlayer").transform.
	}
}
