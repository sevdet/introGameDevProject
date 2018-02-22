using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

	public Transform target;//set target from inspector instead of looking in Update
	public float speed = 4;

	// Use this for initialization
	void Start () {
		
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

}
