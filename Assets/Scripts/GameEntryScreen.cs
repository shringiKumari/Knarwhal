using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEntryScreen : MonoBehaviour {

	private Button button;
	private GameObject controlinfo;
	private Text readySetJoust;
    public GameObject andy;
    public GameObject thringi;
	public GameObject pufferfish;
	public GameObject pufferfishSpawner;

	// Use this for initialization
	void Start () {
		button = GetComponentInChildren<Button>();
		GameObject go = GameObject.FindGameObjectWithTag("ReadySetJoust");
		readySetJoust = go.GetComponent<Text> ();
		readySetJoust.gameObject.SetActive (false);
		controlinfo = GameObject.Find ("ControlInfo");
	}

	public void OnClick (){
		button.gameObject.SetActive(false);
		controlinfo.SetActive (false);
		StartCoroutine(Tick());
    }

	public IEnumerator Tick() {
		yield return new WaitForSeconds(0.4f);
		readySetJoust.gameObject.SetActive (true);
		yield return new WaitForSeconds(0.8f);
		readySetJoust.text = "Set";
		yield return new WaitForSeconds(0.8f);
		readySetJoust.text = "Joust";
		yield return new WaitForSeconds(0.8f);
        andy.SetActive(true); // activate NARWHAL CONTROL
        thringi.SetActive(true); // activate NARWHAL CONTROL
		pufferfish.SetActive(true);
		pufferfishSpawner.SetActive(true);
		gameObject.SetActive(false);
    }
}