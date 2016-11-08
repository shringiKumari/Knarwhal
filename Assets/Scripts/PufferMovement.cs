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

	void OnEnable () {		
		Vector2 randomSpawnPosition = new Vector3 (Random.Range (0.05f, 0.9f), Random.Range (0.05f, 0.9f),0);
		transform.position = Camera.main.ViewportToWorldPoint(randomSpawnPosition) - new Vector3 (0, 0, Camera.main.transform.position.z);
		Debug.Log(transform.position);
	}
		
	
	// Update is called once per frame
	void FixedUpdate () {
		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
		//Debug.Log ("Here");
	
	}
}
