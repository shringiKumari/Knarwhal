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
	private float botLimit, topLimit, leftLimit, rightLimit;
	public Rigidbody2D rb;

  private int playerID;
  private KeyboardInput keyboard = new KeyboardInput();

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

    if (MoveInput()) {

			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
			transform.position += ReferenceVector * Time.fixedDeltaTime * translationSpeed;
			//Debug.Log(move);

		}

		if (DashInput()) {
			Debug.Log ("Dash" + dash);
			rb.AddForce (transform.right * thrust);
		}

		if (SpoutInput()) {
			Debug.Log ("Spout" + spout);
		}
	}
}
