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
		StartCoroutine(Tick());
	}

	IEnumerator Tick() {
		yield return new WaitForSeconds(0.4f);
		readySetJoust.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.8f);
		readySetJoust.text = "Set";
		yield return new WaitForSeconds(0.8f);
		readySetJoust.text = "Joust";
		yield return new WaitForSeconds(0.8f);
		gameObject.SetActive (false);
	}
}