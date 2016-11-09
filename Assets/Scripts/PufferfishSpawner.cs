using UnityEngine;
using System.Collections;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfish;
	private float startTimer = 0f;
	private float spawnThreshholdTimer = 5f;

	private float screenLimitMax = 15f;
	private float screenLimitMin = -15f;

	// Use this for initialization
	void Start () {
          screenLimitMin = pufferfish.GetComponent<PufferMovement>().pufferSpwanXLeft;
          screenLimitMax = pufferfish.GetComponent<PufferMovement>().pufferSpwanXRight;
          Debug.Log(screenLimitMax + " max min " +screenLimitMin);
		}
	
	// Update is called once per frame
	void Update () {
		if (((pufferfish.transform.position.x <= screenLimitMin) || (pufferfish.transform.position.x >= screenLimitMax))
			&& (pufferfish.activeSelf == true)) {
			pufferfish.SetActive (false);
			pufferfish.transform.localScale = new Vector3 (1, 1, 0);
			startTimer = 0f;
		}

		if ((startTimer >= spawnThreshholdTimer) && (pufferfish.activeSelf == false)){
			pufferfish.SetActive (true);
		}
		startTimer += Time.deltaTime;

	}
}
