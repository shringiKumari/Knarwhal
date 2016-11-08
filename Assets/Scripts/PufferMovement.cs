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

	private float pufferSpwanXLeft = -0.01f;
	private float pufferSpwanXRight = 1.0f;

	private float pufferSpwanYmin = 0.05f;
	private float pufferSpwanYmax = 0.9f;

	private float spawnX = 0.5f;
	private float hue;
	private float s;
	private float v;


	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();		
	}

	void OnEnable () {
		
		Color thiscolor = Random.ColorHSV ();
		gameObject.GetComponent<SpriteRenderer>().material.color = thiscolor + new Color(225/255, 200/255, 1f); 
		//Debug.Log (thisColor);
		//Color.RGBToHSV (thisColor, out hue, out s, out v);
		//Debug.Log ("hue" + hue);

	 
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
		Debug.Log (transform.position);
	}
			

	void FixedUpdate () {
		theta += thetaStep;
		Vector3 referenceVector = new Vector2 (referencePositionX * direction, Mathf.Sin(theta) * referencePositionY);
		rb.velocity = referenceVector.normalized * Time.fixedDeltaTime * translationSpeed;
	
	}
}
