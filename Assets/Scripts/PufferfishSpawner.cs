using UnityEngine;
using System.Collections;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfish;
	private float startTimer = 0f;
	private float spawnThreshholdTimer = 5f;

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

	}
}
