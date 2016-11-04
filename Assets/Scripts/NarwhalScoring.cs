﻿using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	private int AndyScore;
	private int ThringiScore;
	private bool ScoreReady = true;

	// Use this for initialization
	void Start () {
	}

	IEnumerator OnTriggerEnter2D(Collider2D bodyhit) {

		if (bodyhit.tag == "AndyBody") {
			if (ScoreReady == true) {
				ThringiScore += 1;
				ScoreReady = false;
				Debug.Log (ThringiScore);
			}
		}

		if (bodyhit.tag == "ThringiBody") {
			if (ScoreReady == true) {
				AndyScore += 1;
				ScoreReady = false;
				Debug.Log (AndyScore);
			}
		}
		yield return new WaitForSecondsRealtime (3);
		ScoreReady = true;
	}
	
	// Update is called once per frame
	void Update () {
	}
}