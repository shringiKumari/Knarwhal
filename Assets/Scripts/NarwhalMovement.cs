using UnityEngine;
using System.Collections;

public class NarwhalMovement : MonoBehaviour {
	public float rotationSpeed = 10;
	public float translationSpeed = 10;
	public string move;
	public string rotate;
	public string dash;
	public string spout;
	public float hornAngle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.forward * Input.GetAxis(rotate) * rotationSpeed);

		if (Input.GetButton(move)) {

			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
			transform.position += ReferenceVector * Time.fixedDeltaTime * translationSpeed;
			Debug.Log(move);
		}

		if (Input.GetButton(dash)) {
			Debug.Log ("Dash" + dash);
		}

		if (Input.GetButton(spout)) {
			Debug.Log ("Spout" + spout);
		}
	}
}
