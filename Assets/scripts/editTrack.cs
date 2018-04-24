using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editTrack : MonoBehaviour {

	AudioSource music;
	public float distance; // the distance between enemy and player at which the music speeds up
	public float speedUp; // how much to speed up the music when enemy and player are within the distance above
	public float normalSpeed; // base speed of the music (should be this most of the time)

	// Use this for initialization
	void Start () {
		music = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// when play and enemy are within a certain distance the music will speed up to create urgent mood
		if (Vector3.Distance (GameObject.FindWithTag ("enemy").transform.position, 
			    GameObject.FindWithTag ("player").transform.position) < distance) {
			music.pitch = speedUp;
		} else {
			music.pitch = normalSpeed;
		}
	}
}
