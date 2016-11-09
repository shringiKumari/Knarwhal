using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

  public int AndyScore;
  public int ThringiScore;

  public int AndyDamage;
  public int ThringiDamage;
	
  public static NarwhalScoring narwhalScoring;

  public GameObject Andy;
  public GameObject Thringi;
  public GameObject winscreen;
  public GameObject hud;

  public int WinScore;
  private Text ScoreAndy;
  private Text ScoreThringi;
  private string WinText;


	// Use this for initialization
	void Start () {
    GameObject andyscore = GameObject.Find("ScoreUpdateAndy");
    ScoreAndy = andyscore.GetComponent<Text>();
    GameObject thringiscore = GameObject.Find("ScoreUpdateThringi");
    ScoreThringi = thringiscore.GetComponent<Text>();
    narwhalScoring = this;
  }

  public void ScoreHit(GameObject victim){
    if (victim.name == "Andy") { // Add point for Thringi when Andy is hit
      ThringiScore += 1;
	   AndyDamage += 1;
      var ui = Thringi.GetComponent<SceneUIManager> ();
      ui.ScoreUpdate (ThringiScore);
		var healthUI = Andy.GetComponent<SceneUIManager> ();
      healthUI.HealthBarUpdate (AndyDamage);
    }
    if (victim.name == "Thringi") { // Add point for Andy when Thringi is hit
      AndyScore += 1;
	  ThringiDamage += 1;
      var ui = Andy.GetComponent<SceneUIManager> ();
      ui.ScoreUpdate (AndyScore);
      var healthUI = Thringi.GetComponent<SceneUIManager> ();
      healthUI.HealthBarUpdate (ThringiDamage);
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
			WinText = "Player One wins! Best Knarwhal!";
    }

    if(ThringiScore == WinScore) {
      GameOver ();
			WinText = "Player Two wins! Best Knarwhal!";
	}

		var wintext = winscreen.GetComponent<GameWinScreen> ();
		wintext.WinnerUpdate (WinText);

	}

}