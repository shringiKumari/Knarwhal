using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PufferfishSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject pufferfishReference;
	private float startTimer = 0f;
	private float spawnThreshholdTimer = 1f;

	private float screenLimitMax;
	private float screenLimitMin;

     private List<GameObject> pufferfishList = new List<GameObject> ();

	// Use this for initialization
	void Start () {
          screenLimitMin = pufferfishReference.GetComponent<PufferMovement>().pufferSpwanXLeft;
          screenLimitMax = pufferfishReference.GetComponent<PufferMovement>().pufferSpwanXRight;

          pufferfishList.Add (pufferfishReference);
		}
	
	// Update is called once per frame
	void Update () {
          foreach (GameObject pufferfish in pufferfishList) {
               if (((pufferfish.transform.position.x <= screenLimitMin) || (pufferfish.transform.position.x >= screenLimitMax))
               && (pufferfish.activeSelf == true)) {
                    pufferfish.SetActive (false);
                    pufferfish.transform.localScale = new Vector3 (1, 1, 0);
                    startTimer = 0f;
               }

               if ((startTimer >= spawnThreshholdTimer) && (pufferfish.activeSelf == false)) {
                    pufferfish.SetActive (true);
               }
          }
          startTimer += Time.deltaTime;

	}
}
