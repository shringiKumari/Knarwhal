using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	private int AndyScore;
	private int ThringiScore;
	private bool ScoreReady = true;
    public int WinScore;
    private string winner;
    public GameObject winscreen;

	public ScoreUpdateEvent updateScore = new ScoreUpdateEvent();
    public GameWinEvent winState = new GameWinEvent();

	// Use this for initialization
	void Start () {

    }

	IEnumerator OnTriggerEnter2D(Collider2D vitalhit) {

		if (vitalhit.tag == "AndyBody") {
			if (ScoreReady == true) {
				ThringiScore += 1;
				ScoreReady = false;
				updateScore.Invoke (ThringiScore); //Trigger for UI
				Debug.Log (ThringiScore);
			}
		}

		if (vitalhit.tag == "ThringiBody") {
			if (ScoreReady == true) {
				AndyScore += 1;
				ScoreReady = false;
				updateScore.Invoke (AndyScore); //Trigger for UI
				Debug.Log (AndyScore);
			}
		}

        WinCheck();
        yield return new WaitForSecondsRealtime (3); //Delay before scoring possible again, for disengage
		ScoreReady = true;
	}
	
    void WinCheck() {
        if (AndyScore == WinScore || ThringiScore == WinScore) {
            winner = "test";
            winState.Invoke (winner); //Trigger for UI
            winscreen.SetActive(true);
            Debug.Log("Game Won");
        }
    }

	// Update is called once per frame
	void Update () {

	}
}