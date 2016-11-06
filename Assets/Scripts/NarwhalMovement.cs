using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class NarwhalMovement : MonoBehaviour {
	public float rotationSpeed = 10.0f;
	public float translationSpeed = 10.0f;
	public string move;
	public string rotate;
	public string dash;
	public string spout;

	public float hornAngle;
	public float thrust;
	public float movementThrust;

	private float dashCoolDownTimer = 5.0f;
	private float startTimer = 5.0f;

	private float botLimit, topLimit, leftLimit, rightLimit;

	public Rigidbody2D rb;

	private int playerID;
	private KeyboardInput keyboard = new KeyboardInput();


	public DashStartedEvent dashStarted = new DashStartedEvent(); 

	// Use this for initialization
	void Start () {

		playerID = name == "Andy" ? 0 : 1;

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
	private float RotateInput() {
		var r = Input.GetAxis(rotate);
		if (r == 0f) {
		r = keyboard.Rotate(playerID);
		}
	return r;
	}

	private bool MoveInput() {
		return Input.GetButton(move) || keyboard.Move(playerID);
	}

	private bool DashInput() {
		return Input.GetButton(dash) || keyboard.Dash(playerID);
	}

	private bool SpoutInput() {
		return Input.GetButton(dash) || keyboard.Spout(playerID);
	}

	 // Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.forward * RotateInput() * rotationSpeed);

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
		//transform.Rotate (Vector3.forward * Input.GetAxis(rotate) * rotationSpeed);
		rb.angularVelocity = Input.GetAxis(rotate) * rotationSpeed;

		//Knarwhal move on pressing controller button.
		if (MoveInput()) {

			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
			//transform.position += ReferenceVector * Time.fixedDeltaTime * translationSpeed;
			rb.velocity = ReferenceVector * Time.fixedDeltaTime * translationSpeed;

		}

		//Knarwhal dash on pressing controller button.
		if (DashInput()) {
			
			if (startTimer >= dashCoolDownTimer) {
				
				Vector3 ReferenceVector = Quaternion.Euler (0, 0, hornAngle) * transform.right;
				rb.AddForce (ReferenceVector * thrust, ForceMode2D.Impulse);
				if (dashStarted != null) {
					dashStarted.Invoke (dashCoolDownTimer);
				}
				startTimer = 0;

			}
		}
		startTimer += Time.fixedDeltaTime;

		if (SpoutInput()) {
			Debug.Log ("Spout" + spout);
		}
	}
}
