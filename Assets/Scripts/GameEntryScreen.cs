using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEntryScreen : MonoBehaviour {

	private Button button;
	private Text readySetJoust;
	// Use this for initialization
	void Start () {
		button = GetComponentInChildren<Button>();
		GameObject go = GameObject.FindGameObjectWithTag("ReadySetJoust");
		readySetJoust = go.GetComponent<Text> ();
		readySetJoust.gameObject.SetActive (false);
	}

	public void OnClick (){
		button.gameObject.SetActive(false);
		readySetJoust.gameObject.SetActive (true);
		StartCoroutine(Tick());
	}

	IEnumerator Tick() {
		yield return new WaitForSeconds(0.5f);
		readySetJoust.text = "Set";
		yield return new WaitForSeconds(0.5f);
		readySetJoust.text = "Joust";
		yield return new WaitForSeconds(0.5f);
		gameObject.SetActive (false);
	}
}
