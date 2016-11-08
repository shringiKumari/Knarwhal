using UnityEngine;
using System.Collections;
//using System;

public class PufferMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private float theta = 0f;
	private float referencePositionX = 0.01f;
	private float referencePositionY = 0.01f;
	private int direction = 1;

	public float thetaStep = 0.5f;
	private float translationSpeed = 30.0f;
	public float pufferAngularVelocity = 20.0f;
	private float speedMin = 90f;
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

	private GameObject narwhalAndy;
	private GameObject narwhalThringi;


	Vector3 localScale;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();	
		localScale = transform.localScale;


	}

	void OnEnable () {
		
		narwhalAndy = GameObject.FindGameObjectWithTag ("AndyBody").transform.parent.gameObject;
		narwhalThringi = GameObject.FindGameObjectWithTag ("ThringiBody").transform.parent.gameObject;
		//random color
		gameObject.GetComponent<SpriteRenderer>().material.color = 
			Color.black + new Color(Random.Range(redMin, redMax), Random.Range(greenMin, greenMax), 1f); 

		//random scale
		scalePuffer = Random.Range (scaleMin, scaleMax);
		transform.localScale = transform.localScale * scalePuffer;

		//random speed 
		translationSpeed = Random.Range (speedMin, speedMax);

		//set random position
		transform.position = GetSpawnPositionAndSetDirection ();
	}

	Vector3 GetSpawnPositionAndSetDirection(){
		Vector2 randomSpawnPosition = new Vector3 (Random.Range (0f, 1f), 
			Random.Range (pufferSpwanYmin, pufferSpwanYmax),0);
		if (randomSpawnPosition.x < spawnX) {
			randomSpawnPosition.x = pufferSpwanXLeft;
			direction = 1;
		} else {
			randomSpawnPosition.x = pufferSpwanXRight;
			direction = -1;
		}
		Vector3 tempPosition = Camera.main.ViewportToWorldPoint(randomSpawnPosition) - 
			new Vector3 (0, 0, Camera.main.transform.position.z);
		float distance1 = Vector2.Distance (narwhalAndy.transform.position, tempPosition);
		float distance2 = Vector2.Distance (narwhalThringi.transform.position, tempPosition);
		Debug.Log ("distanceA " + distance1);
		Debug.Log ("distanceB " + distance2);
		if (distance1 < 3.0 || distance2 < 3.0) {
			GetSpawnPositionAndSetDirection ();
		}
		return tempPosition;
	}
			
	IEnumerator OnTriggerEnter2D(Collider2D bodyhit)
	{
		if (gameObject.activeSelf == true) {
			if (bodyhit.tag == "AndyBody") {
				while (transform.localScale.x > float.MinValue) {
					yield return new WaitForSeconds (0.01f);
					transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
				}
				gameObject.SetActive (false);
			}
			if (bodyhit.tag == "ThringiBody") {	
				while (transform.localScale.x > float.MinValue) {
					yield return new WaitForSeconds (0.01f);
					transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
				}
				gameObject.SetActive (false);
			}
		}
	}

	void FixedUpdate () {

		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX * direction, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
		rb.angularVelocity= pufferAngularVelocity;
	
	}
		
}
