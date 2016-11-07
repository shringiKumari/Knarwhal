using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {


	private Text readySetJoust;
	//[SerializeField]
	private GameEntryScreen gameEntryScreen;

	void Start () {

		GameObject gameEntry = GameObject.FindGameObjectWithTag("GameEntryScreen");
		gameEntryScreen = gameEntry.GetComponent<GameEntryScreen>(); 
	}

	// Update is called once per frame
	void Update () {
	
		if ((Input.GetKeyDown(KeyCode.Space))||
			(Input.GetButtonDown("Start"))||
			(Input.GetButtonDown("Start_W"))){
			gameEntryScreen.OnClick ();
		}
	}
}
