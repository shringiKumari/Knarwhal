using UnityEngine;
using System.Collections;

public class Skewer : MonoBehaviour {

  private float lastChangeTime = float.MinValue;

  private State state = State.hunting;

  private GameObject parent;
  private GameObject skewer;
  private Collider2D hornCollider;

  private GameObject enemyParent;
  private GameObject enemyWound;
  private Collider2D enemyWoundBetween;

  private enum State {
    hunting, jabbed, skewered, cooldown
  }

  void SetState(State s){
    state = s;
    lastChangeTime = Time.time;
  }

  Vector3 FindEntryWound(Collider2D c) {
    var pos = parent.transform.TransformPoint(new Vector3(1.8f, -0.4f));
    var dir = pos - parent.transform.TransformPoint(new Vector3(2.8f, -0.4f));
    dir *= 0.1f;
    int steps = 0;
    while (steps <= 10 && !c.OverlapPoint(pos)) {
      pos += dir;
      steps++;
    }
    var lastPos = pos;
    while (steps <= 10 && c.OverlapPoint(pos)) {
      lastPos = pos;
      pos += dir;
      steps++;
    }
    return lastPos;
  }

  void VelocityCheck(out float angle, out float magnitude){
    var rb_parent = parent.GetComponent<Rigidbody2D> ();
    var rb_enemy = enemyParent.GetComponent<Rigidbody2D> ();
    var vel = rb_parent.velocity;
    var dir3 = rb_parent.transform.TransformVector (1, 0, 0);
    var dir = new Vector2 (dir3.x, dir3.y);
    angle = Mathf.Abs (Vector2.Angle (vel, dir));
    magnitude = vel.magnitude;
  }

  void OnTriggerEnter2D(Collider2D enemy) {
    
    if (state == State.jabbed && enemy.name == "VitalConfirm") {
      var newEnemyParent = enemy.gameObject.transform.parent.parent.gameObject;
      if (newEnemyParent == enemyParent) {
        SetState (State.skewered);
      }
    }

    if (state == State.hunting && enemy.name == "VitalCollision") {
      enemyParent = enemy.gameObject.transform.parent.gameObject;
      if (parent != enemyParent) {
        // Find wound location
        var pos = FindEntryWound(enemy);
        if (enemy.OverlapPoint (pos)) {
          float angle; float magnitude;
          VelocityCheck (out angle, out magnitude);
          if (magnitude > 3f && angle < 180f) {
            // Activate and configure wound
            enemyWound = enemyParent.transform.Find ("wound").gameObject;
            enemyWound.gameObject.SetActive (true);
            enemyWound.transform.position = pos;
            enemyWound.transform.rotation = parent.transform.rotation;
            // Check whether to activate skewer horn sprite
            enemyWoundBetween = enemyWound.transform.Find ("wbetween").GetComponent<Collider2D> ();
            UpdateSkewer ();
            // Spawn a stab hole sprite
            var stabhole = Instantiate (Resources.Load<GameObject> ("stabhole")).transform;
            stabhole.parent = enemyParent.transform;
            stabhole.position = pos;
            stabhole.rotation = parent.transform.rotation;
            // Register the skewer
            NarwhalScoring.narwhalScoring.ScoreHit (enemyParent);
            SetState (State.jabbed);
          }
        }
      }
    }
  }

  void DisableWoundAndSkewer(){
    var wound = enemyParent.transform.Find ("wound");
    wound.gameObject.SetActive (false);
    var parent = transform.parent.gameObject;
    var skewer = parent.transform.Find ("skewer");
    skewer.gameObject.SetActive (false);
  }

  void UpdateSkewer(){
    skewer.gameObject.SetActive (hornCollider.IsTouching (enemyWoundBetween));
  }

  // Update is called once per frame
  void Update () {
    if (state == State.hunting) {
      // Stay in this state indefinitely
    }
    else if (state == State.jabbed) {
      UpdateSkewer ();
      if (lastChangeTime + 1 < Time.time) {
        DisableWoundAndSkewer ();
        SetState (State.hunting);
      }
    }
    else if (state == State.skewered) {
      UpdateSkewer ();
      if (lastChangeTime + 3 < Time.time) {
        DisableWoundAndSkewer ();
        SetState (State.cooldown);
      }
    }
    else if (state == State.cooldown) {
      if (lastChangeTime + 0.3 < Time.time) {
        SetState (State.hunting);
      }
    }
	}

	// Use this for initialization
	void Start () {
    parent = transform.parent.gameObject;
    skewer = parent.transform.Find ("skewer").gameObject;
    hornCollider = parent.transform.Find ("HornCollision").GetComponent<Collider2D>();
	}
}
