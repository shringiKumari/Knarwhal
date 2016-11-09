using UnityEngine;
using System.Collections;

public class NarwhalReset : MonoBehaviour {

	private GameObject[] wounds;

	public float x;
	public float y; 

	// Use this for initialization
	void Start () {

	}
	
	public void ClearWounds(){
		wounds = GameObject.FindGameObjectsWithTag("Wound");
		foreach (GameObject wound in wounds) {
			Destroy (wound);
		}
		transform.position = new Vector2(x, y);
		//transform.Rotate (Vector3(0, 0, 0), Space.World);
	}
}
