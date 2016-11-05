using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DashCoolDownProgress : MonoBehaviour {
	[SerializeField]
	private Image coolDownCircle;
	[SerializeField]
	private NarwhalMovement narwhalMovement;
	bool dashHasStarted;
	private float dashCoolDownTimer;

	void Start () {

		coolDownCircle.fillAmount = 0.0f;
		narwhalMovement.dashStarted.AddListener (OnDashStarted);
	
	}

	void OnDashStarted (float dashCoolDownTimer) {
		dashHasStarted = true;
		this.dashCoolDownTimer = dashCoolDownTimer;

	}

	void Update () {

		if (dashHasStarted) {
			coolDownCircle.fillAmount = 0.0f;
			dashHasStarted = false;
		}
			coolDownCircle.fillAmount += Time.deltaTime / dashCoolDownTimer;
	}
}
