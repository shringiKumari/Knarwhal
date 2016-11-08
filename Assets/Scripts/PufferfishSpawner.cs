using UnityEngine;
using System.Collections;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfish;
	private float startTimer = 0f;
	private float spawnThreshholdTimer = 3f;

	private float screenLimitMax = 10f;
	private float screenLimitMin = -10f;

	// Use this for initialization
	void Start () {
		
		}
	
	// Update is called once per frame
	void Update () {
		if (((pufferfish.transform.position.x <= screenLimitMin) || (pufferfish.transform.position.x >= screenLimitMax))
			&& (pufferfish.activeSelf == true)) {
			pufferfish.SetActive (false);
			startTimer = 0f;
		}

		if ((startTimer >= spawnThreshholdTimer) && (pufferfish.activeSelf == false)){
			pufferfish.SetActive (true);
		}
		startTimer += Time.deltaTime;
		//Debug.Log (startTimer);
		//make wall layer collision gone
		//spawn when timer && out of screen
		// in pufferfish - make direction random.

		//(pufferfish.transform.position.x >= screenLimitMax)

	}
}
