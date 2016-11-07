using UnityEngine;
using System.Collections;

public class Skewer : MonoBehaviour {

  private float lastChangeTime = float.MinValue;

  private State state = State.hunting;

  private GameObject enemyParent;

  private enum State {
    hunting, pricked, skewered, cooldown
  }

  void SetState(State s){
    state = s;
    lastChangeTime = Time.time;
  }

  void OnTriggerEnter2D(Collider2D enemy) {
    
    if (state == State.pricked && enemy.name == "VitalConfirm") {
      Debug.Log ("Collision with " + enemy.name);
      var parent = transform.parent.gameObject;
      var newEnemyParent = enemy.gameObject.transform.parent.parent.gameObject;
      if (newEnemyParent == enemyParent) {

      }
    }

    if (state == State.hunting && enemy.name == "VitalCollision") {
      Debug.Log ("Collision with " + enemy.name);
      var parent = transform.parent.gameObject;
      enemyParent = enemy.gameObject.transform.parent.gameObject;
      if (parent != enemyParent) {
        var wound = enemyParent.transform.Find ("wound");
        wound.gameObject.SetActive (true);
        Destroy (wound.gameObject.GetComponent<FixedJoint2D> ());
        wound.position = parent.transform.TransformPoint (new Vector3 (1.6f, -0.4f));
        wound.rotation = parent.transform.rotation;
        var j = wound.gameObject.AddComponent<FixedJoint2D> ();
        j.connectedBody = enemyParent.GetComponent<Rigidbody2D> ();
        SetState (State.pricked);
      }
    }
  }

  // Update is called once per frame
  void Update () {
    if (state == State.hunting) {
      // Stay in this state indefinitely
    }
    else if (state == State.pricked) {
      if (lastChangeTime + 1 < Time.time) {
        SetState (State.hunting);
      }
    }
    else if (state == State.skewered) {
      if (lastChangeTime + 3 < Time.time) {
        SetState (State.cooldown);
      }
    }
    else if (state == State.cooldown) {
      if (lastChangeTime + 1 < Time.time) {
        SetState (State.hunting);
      }
    }
	}

	// Use this for initialization
	void Start () {
	
	}
}
