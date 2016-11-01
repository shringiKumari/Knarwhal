﻿using UnityEngine;
using System.Collections;

public class NarwhalMovement : MonoBehaviour {
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Up")) {
			transform.position += new Vector3 (0, +1, 0) * Time.deltaTime;
		}
		if (Input.GetButton("Down")) {
			transform.position += new Vector3 (0, -1, 0) * Time.deltaTime;
		}
		if (Input.GetButton("Left")) {
			transform.position += new Vector3 (-1, 0, 0) * Time.deltaTime;
		}
		if (Input.GetButton("Right")) {
			transform.position += new Vector3 (+1, 0, 0) * Time.deltaTime;
		}
		Debug.Log(Input.GetAxis("RightJoystickX"));
		transform.Rotate (Vector3.forward * Input.GetAxis("RightJoystickX") * speed);
	}
}
