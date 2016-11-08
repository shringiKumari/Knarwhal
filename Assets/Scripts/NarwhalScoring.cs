using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	public static int AndyScore;
	public static int ThringiScore;
	private bool ScoreReady = true;
    public int WinScore;
    private string winner;
    public GameObject winscreen;

	public ScoreUpdateEvent updateScore = new ScoreUpdateEvent();

	// Use this for initialization
	void Start () {

    }

	IEnumerator OnTriggerEnter2D(Collider2D vitalhit) {

		if (vitalhit.tag == "AndyBody") {
			if (ScoreReady == true) {
				ThringiScore += 1;
				ScoreReady = false;
				updateScore.Invoke (ThringiScore); //Trigger for UI
			}
		}

		if (vitalhit.tag == "ThringiBody") {
			if (ScoreReady == true) {
				AndyScore += 1;
				ScoreReady = false;
				updateScore.Invoke (AndyScore); //Trigger for UI
			}
		}

        WinCheck();
		yield return new WaitForSecondsRealtime (6); //Delay before scoring possible again (time skewered)
		ScoreReady = true;
	}
	
    void WinCheck() {
		if (AndyScore == WinScore || ThringiScore == WinScore) {
			Debug.Log ("winner");
			winscreen.SetActive (true);
		}
    }
		


	// Update is called once per frame
	void Update () {

	}
}