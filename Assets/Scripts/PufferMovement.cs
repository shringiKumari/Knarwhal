using UnityEngine;
using System.Collections;

public class PufferMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private float theta = 0f;
	private float referencePositionX = 0.01f;
	private float referencePositionY = 0.01f;
	private int direction = 1;

	public float thetaStep = 0.5f;
	private float translationSpeed = 30.0f;
	public float pufferAngularVelocity = 20.0f;
	private float speedMin = 30f;
	private float speedMax = 90f;

	private float pufferSpwanXLeft = -0.01f;
	private float pufferSpwanXRight = 1.0f;

	private float pufferSpwanYmin = 0.05f;
	private float pufferSpwanYmax = 0.9f;

	private float scaleMin = 0.8f;
	private float scaleMax = 1.8f;

	private float spawnX = 0.5f;

	private float redMin = 0.4f;
	private float redMax = 0.7f;
	private float greenMin = 0.4f;
	private float greenMax = 0.8f;

	private float scalePuffer;


	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();		
	}

	void OnEnable () {
		
		//random color
		gameObject.GetComponent<SpriteRenderer>().material.color = 
			Color.black + new Color(Random.Range(redMin, redMax), Random.Range(greenMin, greenMax), 1f); 

		//random scale
		scalePuffer = Random.Range (scaleMin, scaleMax);
		transform.localScale = transform.localScale * scalePuffer;

		//random speed 
		translationSpeed = Random.Range (speedMin, speedMax);

		//random position
		Vector2 randomSpawnPosition = new Vector3 (Random.Range (0f, 1f), 
										Random.Range (pufferSpwanYmin, pufferSpwanYmax),0);
		Debug.Log (randomSpawnPosition.x);
		if (randomSpawnPosition.x < spawnX) {
			randomSpawnPosition.x = pufferSpwanXLeft;
			direction = 1;
		} else {
			randomSpawnPosition.x = pufferSpwanXRight;
			direction = -1;
		}
		transform.position = Camera.main.ViewportToWorldPoint(randomSpawnPosition) - 
										new Vector3 (0, 0, Camera.main.transform.position.z);
	}
			

	void FixedUpdate () {

		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX * direction, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
		rb.angularVelocity= pufferAngularVelocity;
	
	}
}
