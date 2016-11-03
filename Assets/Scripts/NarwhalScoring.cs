using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "AndyBody") {
			Debug.Log ("Point for Thringi");
		}

		if (other.tag == "ThringiBody") {
			Debug.Log ("Point for Andy");
		}

		Debug.Log ("no points :<");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
