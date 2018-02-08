﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () {
		speed = 6;
	}
	
	// Update is called once per frame
	void Update () {

		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		transform.Translate (new Vector2 (xAxis, yAxis)* Time.deltaTime*speed);
	}
		
}
