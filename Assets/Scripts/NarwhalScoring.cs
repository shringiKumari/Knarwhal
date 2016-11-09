using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	public static int AndyScore;
	public static int ThringiScore;
	private bool ScoreReady = true;
	public int WinScore;
	private string winner;
	public GameObject winscreen;
    public GameObject hud;
    private Text ScoreAndy;
    private Text ScoreThringi;

    public ScoreUpdateEvent updateScore = new ScoreUpdateEvent();

	// Use this for initialization
	void Start () {
        GameObject andyscore = GameObject.Find("ScoreUpdateAndy");
        ScoreAndy = andyscore.GetComponent<Text>();
        GameObject thringiscore = GameObject.Find("ScoreUpdateThringi");
        ScoreThringi = thringiscore.GetComponent<Text>();
    }

	IEnumerator OnTriggerEnter2D(Collider2D vitalhit) {


		if (vitalhit.tag == "AndyBody") { // Add point for Thringi when Andy is hit
			if (ScoreReady == true) {
				ThringiScore += 1;
				ScoreReady = false;
				updateScore.Invoke (ThringiScore); //Trigger for UI
			}
		}

		if (vitalhit.tag == "ThringiBody") { // Add point for Andy when Thringi is hit
			if (ScoreReady == true) {
				AndyScore += 1;
				ScoreReady = false;
				updateScore.Invoke (AndyScore); //Trigger for UI
			}
		}

		if (vitalhit.tag == "Pufferfish") {
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
        WinCheck(); //check winstate
        yield return new WaitForSecondsRealtime (6); //Delay before scoring possible again (time skewered)
		ScoreReady = true;
	}

	void WinCheck() {
		if (AndyScore == WinScore || ThringiScore == WinScore) {
            AndyScore = 0;
            ThringiScore = 0;
            ScoreAndy.text = "0"; // Reset score on HUD
            ScoreThringi.text = "0"; // Reset score on HUD
            hud.SetActive(false);
			winscreen.SetActive (true);
		}
	}

    // Update is called once per frame
    void Update () {
  
    }
}