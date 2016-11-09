using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameWinScreen : MonoBehaviour {

	private NarwhalScoring narwhalScoring;
    public GameObject winscreen;
    public GameObject hud;

	[SerializeField]
	public Text winText;

    // Use this for initialization
    void Start () {

    }

	public void WinnerUpdate(string winner)
	{
		winText.text = winner;
	}

	public void PlayClick()
    { 
        ResetScreen();
	}

    void ResetScreen() // reactivate HUD and exit win screen
    {
        hud.SetActive(true);

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