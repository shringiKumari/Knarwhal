using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SceneUIManager : MonoBehaviour {

	[SerializeField]
	private Image coolDownCircle;

     [SerializeField]
     private Image healthBar;

	private NarwhalMovement narwhalMovement;
	private float dashCoolDownTimer;

	bool dashHasStarted;

	private NarwhalScoring narwhalScoring;
	private int score;

     private float reduceBar;


	[SerializeField]
	private Text scoreText;

	void Start () {
		coolDownCircle.fillAmount = 0.0f;
          healthBar.fillAmount = 1.0f;
          reduceBar = healthBar.fillAmount / 8.0f;
		narwhalScoring = GetComponent<NarwhalScoring> (); 
		narwhalMovement = GetComponent<NarwhalMovement> (); 
		narwhalMovement.dashStarted.AddListener (OnDashStarted);
	}

	void OnDashStarted (float dashCoolDownTimer) {
		dashHasStarted = true;
		this.dashCoolDownTimer = dashCoolDownTimer;

	}

	public void ScoreUpdate (int score) {
		scoreText.text = score.ToString();
	}
          
     public void HealthBarUpdate (int damage) {
          
          healthBar.fillAmount = 1f - (reduceBar * damage);
     }
	void Update () {

		if (dashHasStarted) {
			coolDownCircle.fillAmount = 0.0f;
			dashHasStarted = false;
		}
		coolDownCircle.fillAmount += Time.deltaTime / dashCoolDownTimer;
	}
}