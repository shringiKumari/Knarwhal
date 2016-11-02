using UnityEngine;
using System.Collections;

public class NarwhalMovement_02 : MonoBehaviour {
	public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("A_2")) {
			Debug.Log ("A2");
		}
		if (Input.GetButton("B_2")) {
			Debug.Log ("B2");
		}
		if (Input.GetButton("X_2")) {
			Debug.Log ("X2");
		}
		if (Input.GetButton("Y_2")) {
			Debug.Log ("Y2");
		}
		if (Input.GetButton("RB_2")) {
			Debug.Log ("RB2");
		}
		if (Input.GetButton("RB_2")) {
			Debug.Log ("RB2");
		}
		transform.Rotate (Vector3.forward * Input.GetAxis("RightJoystickX_2") * speed);
	
	}
}
