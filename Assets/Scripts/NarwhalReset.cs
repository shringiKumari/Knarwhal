using UnityEngine;
using System.Collections;

public class NarwhalReset : MonoBehaviour {

	private GameObject[] wounds;

	// Use this for initialization
	void Start () {
	
	}
	
	public void ClearWounds(){
		//TODO find all stabhole(Clone) children
		wounds = GameObject.FindGameObjectsWithTag("Wound");
		//TODO remove wound sprites from both scene
		foreach (GameObject wound in wounds) {
			Destroy (wound);
		}
		//TODO end
		Debug.Log("reset wounds callled");
	}
}
