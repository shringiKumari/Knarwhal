using UnityEngine;
using System.Collections;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfish;
	// Use this for initialization
	void Start () {
		
		}
	
	// Update is called once per frame
	void Update () {
/*		if (Time.time >= 10) {
			pufferfish.SetActive (false);
			Debug.Log (Time.time);
			pufferfish.SetActive (true);
		}*/
		//make wall layer collision gone
		//spawn when timer && out of screen
		// in pufferfish - make direction random.


	}
}
