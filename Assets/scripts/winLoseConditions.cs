using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class winLoseConditions : MonoBehaviour {
	
	public Rigidbody2D rb;
	private int goalCount; // number of sparklies the player collects
	private int goalNum = 5; // number of sparklies necessary for winning
	public AudioSource audio;


	// Use this for initialization
	void Start () {

		goalCount = 0;
		rb = this.GetComponent<Rigidbody2D> ();
		audio = this.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {

		if (goalCount == goalNum) {
			Debug.Log ("won");
			SceneManager.LoadScene ("winScene");
		}

	}


	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "goal") {
			audio.Play ();
			Destroy (coll.gameObject);
			Debug.Log ("collected a sparkly");
			goalCount += 1;
		}

		if (coll.gameObject.tag == "enemy") {
			Debug.Log ("lost");
			SceneManager.LoadScene ("loseScene");
		}
	}

	IEnumerator WaitAndLoadScene()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("winScene");
	}
}
