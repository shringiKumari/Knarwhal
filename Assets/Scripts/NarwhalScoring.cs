﻿using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	private int AndyScore;
	private int ThringiScore;
	private bool ScoreReady = true;

	public ScoreUpdateEvent updateScore = new ScoreUpdateEvent(); 

	// Use this for initialization
	void Start () {
	}

	IEnumerator OnTriggerEnter2D(Collider2D bodyhit) {

		if (bodyhit.tag == "AndyBody"){
			if (ScoreReady == true) {
				ThringiScore += 1;
				ScoreReady = false;
				updateScore.Invoke (ThringiScore); //Trigger for UI
				Debug.Log (ThringiScore);
			}
		}

		if (bodyhit.tag == "ThringiBody") {
			if (ScoreReady == true) {
				AndyScore += 1;
				ScoreReady = false;
				updateScore.Invoke (AndyScore); //Trigger for UI
				Debug.Log (AndyScore);
			}
		}
		if (bodyhit.tag == "Pufferfish") {
			if (ScoreReady == true) {
				if (gameObject.name == "Andy") {
					AndyScore -= 1;
					updateScore.Invoke (AndyScore);
				}
				if (gameObject.name == "Thringi") {
					ThringiScore -= 1;
					updateScore.Invoke (ThringiScore);
				}
				ScoreReady = false;
			}
		}
		yield return new WaitForSecondsRealtime (3);
		ScoreReady = true;
	}
	
	// Update is called once per frame
	void Update () {
	}
}