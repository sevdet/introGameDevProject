using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class sceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (EditorSceneManager.GetActiveScene ().name == "winScene" || EditorSceneManager.GetActiveScene ().name == "loseScene") {
			if (Input.anyKeyDown) {
				EditorSceneManager.LoadScene ("titleScene");
			}
		}

		if (EditorSceneManager.GetActiveScene ().name == "titleScene") {
			if (Input.anyKeyDown) {
				EditorSceneManager.LoadScene ("maze1");
			}
		}

		if (EditorSceneManager.GetActiveScene ().name == "maze1") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				EditorSceneManager.LoadScene (EditorSceneManager.GetActiveScene ().name);
			}
		}
	}
}
