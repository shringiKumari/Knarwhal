using UnityEngine;
using System.Collections;

public class WinScreenButtonScript : MonoBehaviour {

	private GameWinScreen gameWinScreen;
	// Use this for initialization
	void Start () {

		GameObject gameWin = GameObject.FindGameObjectWithTag("WinScreen");
		gameWinScreen = gameWin.GetComponent<GameWinScreen>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.H)) {
			gameWinScreen.PlayClick ();
		}
		if (Input.GetKeyDown(KeyCode.B)) {
			gameWinScreen.QuitClick ();
		}
	
	}
}
