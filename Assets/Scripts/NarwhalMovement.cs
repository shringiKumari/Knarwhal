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
		//float angle = transform.rotation.eulerAngles.z;
		//float angle = Quaternion.Angle(transform.rotation, Quaternion.identity);

		if (Input.GetButton(move)) {

			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
			transform.position += ReferenceVector * Time.fixedDeltaTime * translationSpeed;
			//transform.position += new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0) * Time.fixedDeltaTime * translationSpeed;
			//Debug.Log ("cos"+Mathf.Cos(angle));
			//Debug.Log ("sin"+Mathf.Sin(angle));
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
