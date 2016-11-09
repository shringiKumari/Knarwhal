using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	public int AndyScore;
	public int ThringiScore;
	
  public static NarwhalScoring narwhalScoring;

  public GameObject Andy;
  public GameObject Thringi;
  public GameObject winscreen;

  private bool ScoreReady = true;
	public int WinScore;
	private string winner;
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
    narwhalScoring = this;
    Debug.Log ("sdadas");
  }

  public void ScoreHit(GameObject victim){
    if (victim.name == "Andy") { // Add point for Thringi when Andy is hit
      ThringiScore += 1;
      var ui = Thringi.GetComponent<SceneUIManager> ();
      ui.ScoreUpdate (ThringiScore);
      //updateScore.Invoke (ThringiScore); //Trigger for UI
    }
    if (victim.name == "Thringi") { // Add point for Andy when Thringi is hit
      AndyScore += 1;
      var ui = Andy.GetComponent<SceneUIManager> ();
      ui.ScoreUpdate (AndyScore);
      //updateScore.Invoke (AndyScore); //Trigger for UI
    }
    WinCheck(); //check winstate
  }

  private void GameOver(){
    AndyScore = 0;
    ThringiScore = 0;
    ScoreAndy.text = "0"; // Reset score on HUD
    ScoreThringi.text = "0"; // Reset score on HUD
    hud.SetActive(false);
    winscreen.SetActive (true);
  }

  private void WinCheck() {
    if (AndyScore == WinScore) {
      GameOver ();
      winner = "Andy";
    }

    if(ThringiScore == WinScore) {
      GameOver ();
      winner = "Thringi";
		}
	}

}