using UnityEngine;
using System.Collections;

public class Skewer : MonoBehaviour {

  private float lastChangeTime = float.MinValue;

  private State state = State.hunting;

  private GameObject enemyParent;

  private enum State {
    hunting, jabbed, skewered, cooldown
  }

  void SetState(State s){
    state = s;
    lastChangeTime = Time.time;
  }

  Vector3 FindEntryWound(Collider2D c, GameObject parent) {
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

  void OnTriggerEnter2D(Collider2D enemy) {
    
    if (state == State.jabbed && enemy.name == "VitalConfirm") {
      var parent = transform.parent.gameObject;
      var newEnemyParent = enemy.gameObject.transform.parent.parent.gameObject;
      if (newEnemyParent == enemyParent) {
        Debug.Log (parent.name + " skewered " + enemyParent.name);
        SetState (State.skewered);
      }
    }

    if (state == State.hunting && enemy.name == "VitalCollision") {
      var parent = transform.parent.gameObject;
      enemyParent = enemy.gameObject.transform.parent.gameObject;
      if (parent != enemyParent) {
        Debug.Log (parent.name + " jabbed " + enemyParent.name);
        // Find wound location
        var pos = FindEntryWound(enemy, parent);
        if (enemy.OverlapPoint (pos)) {
          // Activate and configure wound
          var wound = enemyParent.transform.Find ("wound");
          wound.gameObject.SetActive (true);
          wound.position = pos;
          wound.rotation = parent.transform.rotation;
          // Activate skewer horn sprite
          var skewer = parent.transform.Find ("skewer");
          skewer.gameObject.SetActive (true);
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

  void DisableWoundAndSkewer(){
    var wound = enemyParent.transform.Find ("wound");
    wound.gameObject.SetActive (false);
    var parent = transform.parent.gameObject;
    var skewer = parent.transform.Find ("skewer");
    skewer.gameObject.SetActive (false);
  }

  // Update is called once per frame
  void Update () {
    if (state == State.hunting) {
      // Stay in this state indefinitely
    }
    else if (state == State.jabbed) {
      if (lastChangeTime + 1 < Time.time) {
        DisableWoundAndSkewer ();
        SetState (State.hunting);
      }
    }
    else if (state == State.skewered) {
      if (lastChangeTime + 6 < Time.time) {
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
	
	}
}
