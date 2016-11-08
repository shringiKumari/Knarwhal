using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameWinScreen : MonoBehaviour {

    private NarwhalScoring narwhalScoring;
    public GameObject textarea;


    // Use this for initialization
    void Start () {
        narwhalScoring = GetComponent<NarwhalScoring>();
        narwhalScoring.winState.AddListener(HasWon);
        textarea = GameObject.Find("/WinPanel/GameWinText");
    }

    void HasWon(string winner) {
 
    }

    // Update is called once per frame
    void Update () {
  
	}
}
