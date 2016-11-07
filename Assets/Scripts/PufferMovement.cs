using UnityEngine;
using System.Collections;

public class PufferMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private float theta = 0f;
	private float referencePositionX = 0.01f;
	private float referencePositionY = 0.01f;

	public float thetaStep = 0.5f;
	public float translationSpeed = 30.0f;


	// Use this for initialization
	void Start () {
		
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
	
	}
}
