using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor.Audio;

public class enemyBehavior : MonoBehaviour {

	public Transform target; // what the enemy follows (so this gets set to player in the inspector
	public float speed; // speed of enemy
	public float speedUpgrade; // amount of speed increase every time enemy collects powerup
	public Animator animationController; // controlling animation for when enemy picks up a powerup
	bool isCollecting = false; // using this to tell when the enemy has picked up a powerup so when this is true, it does the animation
	AudioSource audio; // sound effect for picking up powerup


	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (isCollecting) { // if enemy has just picked up a powerup
			animationController.Play ("enemy_transform1"); // play the powering up animation
		} else { // if enemy hasn't just picked something up 
			animationController.Play ("enemy_idle"); // play its idle animation
		}
				
		// rotate enemy to face player
		transform.LookAt(target.position);
		transform.Rotate(new Vector3(0,-90,0),Space.Self);

		// translating enemy towards position of player
		if (Vector3.Distance(transform.position,target.position) > 0.4f){
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		// if enemy collides with player once then it's gameover 
		if (coll.gameObject.tag == "player") {
			Debug.Log ("lost");
			EditorSceneManager.LoadScene ("loseScene");
		}
			
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "powerup") {
			audio.Play(); // play powerup sound
			isCollecting = true; // collided with powerup so this is set to true so that the animation plays in Update()
			Debug.Log ("enemy got powerup");
			Destroy (coll.gameObject); // the collected powerup is no longer in the game
			speed += speedUpgrade; // speed increases when powerup collected
			//transform.localScale = Vector2.Lerp (transform.localScale, new Vector2 (0.8f, 0.8f), Time.deltaTime);
			/*
				originally was using the line above this to increase the size of the enemy along with its speed
				whenever it got a powerup, but once the animation was implemented, the size stopped changing so
				i need to figure out how to get that to work again or just give up on increasing the enemy's size
			*/
		} 
	}
		
}
