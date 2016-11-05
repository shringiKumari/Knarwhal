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
	public float thrust;
	public float movementThrust;

	private float dashCoolDownTimer = 5;
	private float startTimer = 5;

	private float botLimit, topLimit, leftLimit, rightLimit;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
		Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
		Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));

		botLimit = bottomCorner.x;
		topLimit = topCorner.x;
		leftLimit = bottomCorner.y;
		rightLimit = topCorner.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		Vector3 pos = transform.position;
		if (pos.x < botLimit)
			pos.x = botLimit;
		if (pos.x > topLimit)
			pos.x = topLimit;
		if (pos.y < leftLimit)
			pos.y = leftLimit;
		if (pos.y > rightLimit)
			pos.y = rightLimit;

		transform.position = pos;

		//Knarwhal rotation using the joystick input.
		transform.Rotate (Vector3.forward * Input.GetAxis(rotate) * rotationSpeed);

		//Knarwhal move on pressing controller button.
		if (Input.GetButton(move)) {

			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
			transform.position += ReferenceVector * Time.fixedDeltaTime * translationSpeed;
			//rb.AddForce(ReferenceVector * movementThrust);
			//Debug.Log(move);

		}

		//Knarwhal dash on pressing controller button.
		if (Input.GetButtonDown(dash)) {
			Debug.Log ("Dash" + dash);
			if (startTimer >= dashCoolDownTimer) {
				Vector3 ReferenceVector = Quaternion.Euler (0, 0, hornAngle) * transform.right;
				rb.AddForce (ReferenceVector * thrust, ForceMode2D.Impulse);
				startTimer = 0;
			}
		}
		startTimer += Time.fixedDeltaTime;
		Debug.Log (gameObject.name + " startTimer" + startTimer);

		if (Input.GetButton(spout)) {
			Debug.Log ("Spout" + spout);
		}
	}
}
