using UnityEngine;
using System.Collections;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfish;
	private float startTimer = 0f;
	public float spawnThreshholdTimer = 5f;

	// Use this for initialization
	void Start () {
		
		}
	
	// Update is called once per frame
	void Update () {
		if ((pufferfish.transform.position.x >= 7f) && (pufferfish.activeSelf == true)) {
			Debug.Log("not here???????????????????????????????????????");
			pufferfish.SetActive (false);
			startTimer = 0f;
		}

		if ((startTimer >= spawnThreshholdTimer) && (pufferfish.activeSelf == false)){
			//Debug.Log("here???????????????????????????????????????");
			pufferfish.SetActive (true);

		}
		startTimer += Time.deltaTime;
		Debug.Log (startTimer);
		//make wall layer collision gone
		//spawn when timer && out of screen
		// in pufferfish - make direction random.


	}
}
