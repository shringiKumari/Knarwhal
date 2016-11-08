using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SceneUIManager : MonoBehaviour {

	[SerializeField]
	private Image coolDownCircle;

	private NarwhalMovement narwhalMovement;
	private float dashCoolDownTimer;

	bool dashHasStarted;

	private NarwhalScoring narwhalScoring;
	private int score;


	[SerializeField]
	private Text scoreText;

	void Start () {

		coolDownCircle.fillAmount = 0.0f;
		narwhalScoring = GetComponent<NarwhalScoring> (); 
		narwhalMovement = GetComponent<NarwhalMovement> (); 
		narwhalMovement.dashStarted.AddListener (OnDashStarted);
		narwhalScoring.updateScore.AddListener (ScoreUpdate);
	}

	void OnDashStarted (float dashCoolDownTimer) {
		dashHasStarted = true;
		this.dashCoolDownTimer = dashCoolDownTimer;

	}

	void ScoreUpdate (int score) {
		//this.score = score;
		scoreText.text = score.ToString();
	}

	void Update () {

		if (dashHasStarted) {
			coolDownCircle.fillAmount = 0.0f;
			dashHasStarted = false;
		}
		coolDownCircle.fillAmount += Time.deltaTime / dashCoolDownTimer;
	}
}