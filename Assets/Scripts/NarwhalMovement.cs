using UnityEngine;
using System.Collections;

public class NarwhalMovement : MonoBehaviour {
	public string move;
	public string rotate;
	public string dash;
	public string spout;
	public float hornAngle;
	public float thrust;

	private float rotationSpeed = 500;
	private float translationSpeed = 500;
  
	public Rigidbody2D rb;

  private int playerID;
  private KeyboardInput keyboard = new KeyboardInput();

	// Use this for initialization
	void Start () {
    playerID = name == "Andy" ? 0 : 1;

    rb = GetComponent<Rigidbody2D>();
    rb.angularDrag = 10f;
    rb.drag = 10f;

    float h = 2f * Camera.main.orthographicSize;
    float w = h * Camera.main.aspect;

    AddWall(-w / 2 - 0.5f, 0, 1, h);
    AddWall(w / 2 + 0.5f, 0, 1, h);
    AddWall(0, -h / 2 - 0.5f, w, 1);
    AddWall(0, h / 2 + 0.5f, w, 1);

  }

  private float RotateInput() {
    return Input.GetAxis(rotate) + keyboard.Rotate(playerID);
  }


  void AddWall(float x, float y, float w, float h) {
    var o = new GameObject();
    o.AddComponent<BoxCollider2D>();
    var sr = o.AddComponent<SpriteRenderer>();
    sr.sprite = Resources.Load<Sprite>("white");
    var t = o.transform;
    t.localScale = new Vector3(w, h, 1);
    t.position = new Vector3(x, y);
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
    var rotate = RotateInput();
    if(rotate != 0f) rb.angularVelocity = rotate * rotationSpeed;
    
    if (MoveInput()) {
			Vector3 ReferenceVector = Quaternion.Euler(0, 0, hornAngle) * transform.right;
      rb.velocity = ReferenceVector * Time.fixedDeltaTime * translationSpeed;

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
