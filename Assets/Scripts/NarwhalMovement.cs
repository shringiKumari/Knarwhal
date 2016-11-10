using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class NarwhalMovement : MonoBehaviour
{
     public float rotationSpeed = 10.0f;
     public float translationSpeed = 10.0f;
     public string move;
     public string rotate;
     public string dash;
     //public string spout;

     public float hornAngle;
     public float thrust;

     public float movementThrust;

     private float dashCoolDownTimer = 5.0f;
     private float startTimer = 5.0f;


     public Rigidbody2D rb;

     private int playerID;
     private KeyboardInput keyboard = new KeyboardInput ();


     public DashStartedEvent dashStarted = new DashStartedEvent ();

     // Use this for initialization
     void Start ()
     {
          playerID = name == "Andy" ? 0 : 1;

          rb = GetComponent<Rigidbody2D> ();

          float h = 2f * Camera.main.orthographicSize;
          float w = h * Camera.main.aspect;

          AddWall (-w / 2 - 0.5f, 0, 1, h);
          AddWall (w / 2 + 0.5f, 0, 1, h);
          AddWall (0, -h / 2 - 0.5f, w, 1);
          AddWall (0, h / 2 + 0.5f, w, 1);

     }

     void AddWall (float x, float y, float w, float h)
     {
          var o = new GameObject ();
          o.AddComponent<BoxCollider2D> ();
          var sr = o.AddComponent<SpriteRenderer> ();
          sr.sprite = Resources.Load<Sprite> ("white");
          var t = o.transform;
          t.localScale = new Vector3 (w, h, 1);
          t.position = new Vector3 (x, y);
     }

     private float RotateInput ()
     {
          return Input.GetAxis (rotate) + keyboard.Rotate (playerID);
     }

     private bool MoveInput ()
     {
          return Input.GetButton (move) || keyboard.Move (playerID);
     }

     private bool DashInput ()
     {
          return Input.GetButton (dash) || keyboard.Dash (playerID);
     }

     //private bool SpoutInput() {
     //  return Input.GetButton(dash) || keyboard.Spout(playerID);
     //}

     // Update is called once per frame
     void FixedUpdate ()
     {

          //Knarwhal rotation using the joystick input.
          //rb.angularVelocity = RotateInput() * rotationSpeed * -1.0f;
          rb.AddTorque (RotateInput () * -1.0f);


          //Knarwhal move on pressing controller button.
          if (MoveInput ()) {

               Vector3 ReferenceVector = Quaternion.Euler (0, 0, hornAngle) * transform.right;
               //rb.velocity = ReferenceVector * Time.fixedDeltaTime * translationSpeed;
               rb.AddForce (ReferenceVector * movementThrust);

          }

          //Knarwhal dash on pressing controller button.
          if (DashInput ()) {
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

          //if (SpoutInput()) {
          //	Debug.Log ("Spout" + spout);
          //}
     }
}
