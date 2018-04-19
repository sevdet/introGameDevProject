using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class editTrack : MonoBehaviour {

	AudioSource music;

	// Use this for initialization
	void Start () {
		music = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (GameObject.FindWithTag ("enemy").transform.position, 
			    GameObject.FindWithTag ("player").transform.position) < 2.5f) {
			music.pitch = 1.2f;
		} else {
			music.pitch = 1f;
		}
	}
}
