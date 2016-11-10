using UnityEngine;
using System.Collections;

public class NarwhalReset : MonoBehaviour {

	private GameObject[] wounds;

	public float x;
	public float y; 
	public GameObject FaceSmile;
	public GameObject FaceScream;

	// Use this for initialization
	void Start () {

	}
	
	public void ClearWounds(){ // remove wounds and reposition / rerotated the narwhals
		wounds = GameObject.FindGameObjectsWithTag("Wound");
		foreach (GameObject wound in wounds) {
			Destroy (wound);
		}
		FaceScream.SetActive(false);
		FaceSmile.SetActive (true);
		transform.position = new Vector2(x, y);
		transform.rotation = Quaternion.identity;
	}
}
