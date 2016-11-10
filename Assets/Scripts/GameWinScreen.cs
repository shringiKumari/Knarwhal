using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameWinScreen : MonoBehaviour {

     private NarwhalScoring narwhalScoring;
     public GameObject winscreen;
	public GameObject winimage;
     public GameObject hud;
	Image winnerimage;

	public GameObject AndyReset;
	public GameObject ThringiReset;

	public Sprite AndyWin;
	public Sprite ThringiWin;

	[SerializeField]
	public Text winText;


    // Use this for initialization
    void Start () {
		AndyWin = (Sprite)Resources.Load ("/Sprites/AndyWinner");
		ThringiWin = (Sprite)Resources.Load ("/Sprites/ThringiWinner");
    }

	public void WinnerUpdate(string winner)
	{
		winimage = GameObject.Find("WinnerSprite");
		winnerimage = winimage.GetComponent<Image> ();
		winText.text = winner + " is the Knarwhal Champion!";
		if (winner == "Player One") {
			winnerimage.sprite = (AndyWin);
		}
		if (winner == "Player Two") {
			winnerimage.sprite = (ThringiWin);
		}
	}

	public void PlayClick()
    { 
        ResetScreen();
	}

    void ResetScreen() // reactivate HUD and exit win screen
    {
        hud.SetActive(true);
		AndyReset = GameObject.Find ("Andy");
		ThringiReset = GameObject.Find ("Thringi");
		var Aclearwounds = ThringiReset.GetComponent<NarwhalReset> ();
		Aclearwounds.ClearWounds ();
		var Tclearwounds = AndyReset.GetComponent<NarwhalReset> ();
		Tclearwounds.ClearWounds ();
        winscreen.SetActive(false);
    }

	public void QuitClick() // close game
    { 
		Application.Quit ();
	}

    // Update is called once per frame
    void Update () {

	}
}