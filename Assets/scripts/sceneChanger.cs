/*
this script needs to be changed eventually so that UnityEditor.SceneManagement isn't being used
to switch between scenes, need to find a different way so that it can build and run outside the editor 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "loseScene") {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("titleScene");
			}
		}

		if (SceneManager.GetActiveScene ().name == "winScene") {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("maze2");
			}
		}

		if (SceneManager.GetActiveScene ().name == "titleScene") {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene ("maze1");
			}
		}

		if (SceneManager.GetActiveScene ().name == "maze1" || SceneManager.GetActiveScene().name == "maze2" 
			|| SceneManager.GetActiveScene().name == "maze3") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

}
