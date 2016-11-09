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
	private float speedMin = 45f;
	private float speedMax = 90f;

	private float pufferSpwanXLeft = -10.0f;
	private float pufferSpwanXRight = 10.0f;

	private float pufferSpwanYmin = 0.05f;
	private float pufferSpwanYmax = 0.9f;

	private float scaleMin = 0.9f;
	private float scaleMax = 2.0f;

	private float spawnX = 5f;

	private float redMin = 0.4f;
	private float redMax = 0.7f;
	private float greenMin = 0.4f;
	private float greenMax = 0.8f;

	private float optimalDistance = 3.5f;

  	private bool canHurtEnemy = false;

	private float scalePuffer;

	private GameObject narwhalAndy;
	private GameObject narwhalThringi;


	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void OnEnable () {
		
		narwhalAndy = GameObject.Find ("Andy");
		narwhalThringi = GameObject.Find("Thringi");
		gameObject.GetComponent<SpriteRenderer>().material.color = 
			Color.black + new Color(Random.Range(redMin, redMax), Random.Range(greenMin, greenMax), 1f); 

		//random scale
		scalePuffer = Random.Range (scaleMin, scaleMax);
		transform.localScale = transform.localScale * scalePuffer;

		//random speed 
		translationSpeed = Random.Range (speedMin, speedMax);

		//set random position
		transform.position = GetSpawnPositionAndSetDirection ();

    canHurtEnemy = true;
	}

	Vector3 GetSpawnPositionAndSetDirection(){
		Vector2 randomSpawnPosition = new Vector3 (Random.Range (0f, 1f), 
			Random.Range (pufferSpwanYmin, pufferSpwanYmax),0);

		Vector3 tempPosition = Camera.main.ViewportToWorldPoint(randomSpawnPosition) - 
			new Vector3 (0, 0, Camera.main.transform.position.z);
		float distance1 = Vector2.Distance (narwhalAndy.transform.position, tempPosition);
		float distance2 = Vector2.Distance (narwhalThringi.transform.position, tempPosition);
		if (distance1 < optimalDistance || distance2 < optimalDistance) {
			GetSpawnPositionAndSetDirection ();
		}
		if (tempPosition.x < spawnX) {
			tempPosition.x = pufferSpwanXLeft;
			direction = 1;
		} else {
			tempPosition.x = pufferSpwanXRight;
			direction = -1;
		}
		return tempPosition;
	}
	
  void RegisterHit(Collider2D bodyhit){
    var narwhal = bodyhit.gameObject.transform.parent.gameObject;
    NarwhalScoring.narwhalScoring.ScoreHit(narwhal);
    canHurtEnemy = false;
  }

	IEnumerator OnTriggerEnter2D(Collider2D bodyhit)
	{
    if (canHurtEnemy) {
      if (gameObject.activeSelf == true) {
        if (bodyhit.tag == "AndyBody") {
          RegisterHit (bodyhit);
          while (transform.localScale.x > float.MinValue) {
            yield return new WaitForSeconds (0.01f);
            transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
          }
          gameObject.SetActive (false);
        }
        if (bodyhit.tag == "ThringiBody") {
          RegisterHit (bodyhit);
          while (transform.localScale.x > float.MinValue) {
            yield return new WaitForSeconds (0.01f);
            transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, 0.1f);
          }
          gameObject.SetActive (false);
        }
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
