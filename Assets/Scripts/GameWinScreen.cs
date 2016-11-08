using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameWinScreen : MonoBehaviour {

    private NarwhalScoring narwhalScoring;
	public GameObject winscreen;


    // Use this for initialization
	void Start () {

	}

	public void PlayClick() {
		ResetScore ();
		winscreen.SetActive (false);
	}

	void ResetScore () {
		int clear = 0;
		NarwhalScoring.AndyScore = clear;
		NarwhalScoring.ThringiScore = clear;
		//scoreText.text = clear.ToString ();
	}

	public void QuitClick(){
		Application.Quit ();

	}
		

    // Update is called once per frame
    void Update () {
  
	}
}
