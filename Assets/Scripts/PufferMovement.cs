using UnityEngine;
using System.Collections;

public class PufferMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private float theta = 0f;
	private float referencePositionX = 0.01f;
	private float referencePositionY = 0.01f;
	private int direction = 1;

	public float thetaStep = 0.5f;
	public float translationSpeed = 30.0f;

	public float pufferSpwanXmin = 0.05f;
	public float pufferSpwanXmax = 0.9f;

	public float pufferSpwanYmin = 0.05f;
	public float pufferSpwanYmax = 0.9f;

	private float spawnMidX;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();		
	}

	void OnEnable () {		
		Vector2 randomSpawnPosition = new Vector3 (Random.Range (pufferSpwanXmin, pufferSpwanXmax), 
										Random.Range (pufferSpwanYmin, pufferSpwanYmax),0);
		transform.position = Camera.main.ViewportToWorldPoint(randomSpawnPosition) - 
										new Vector3 (0, 0, Camera.main.transform.position.z);
		spawnMidX = (pufferSpwanXmin + pufferSpwanXmax) / 2;
		if (transform.position.x < spawnMidX) {
			direction = 1;
		} else {
			direction = -1;
		}
	}
			
	// Update is called once per frame
	void FixedUpdate () {
		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX * direction, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
		//Debug.Log ("Here");
	
	}
}
