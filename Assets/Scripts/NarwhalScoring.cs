using UnityEngine;
using System.Collections;

public class NarwhalScoring : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("hit point");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
