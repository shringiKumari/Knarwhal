using UnityEngine;
using System.Collections;

public class Skewer : MonoBehaviour {

  private float skewered = float.MinValue;

  private Vector3 collisionPointFar = new Vector3(2f, -0.4f);
  private Vector3 collisionPointNear = new Vector3(1.5f, -0.4f);


  GameObject SpawnWoundBlock(GameObject enemyParent, string name) {
    // Clear existing object
    var oldTransform = enemyParent.transform.Find(name);
    if (oldTransform != null) {
      Destroy(oldTransform.gameObject);
    }
    // Create block
    var o = new GameObject();
    o.layer = LayerMask.NameToLayer("wound");
    o.AddComponent<CircleCollider2D>();
    var rb = o.AddComponent<Rigidbody2D>();
    var sr = o.AddComponent<SpriteRenderer>();
    var joint = o.AddComponent<FixedJoint2D>();
    joint.connectedBody = enemyParent.GetComponent<Rigidbody2D>();
    sr.sprite = Resources.Load<Sprite>("white");
    var t = o.transform;
    t.parent = enemyParent.transform;
    t.localScale = new Vector3(0.2f, 0.2f, 1);
    o.name = name;
    return o;
  }

  void OnTriggerEnter2D(Collider2D enemy) {
    if (Time.time > skewered + 3) {
      Debug.Log("Collision with " + enemy.name);
      var parent = transform.parent.gameObject;
      var enemyParent = enemy.gameObject.transform.parent.gameObject;
      if (enemy.name == "VitalCollision" && parent != enemyParent) {
        //var rb = parent.GetComponent<Rigidbody2D>();
        //var v = rb.velocity;
        // if the collision is in the right direction and with enough force
        var w1 = SpawnWoundBlock(enemyParent, "w1");
        var w2 = SpawnWoundBlock(enemyParent, "w2");
        //w1.transform.position = parent.transform.localToWorldMatrix * new Vector3(2, 0, 0);
        var hornVec = new Vector3(1.6f, -0.4f);
        var perp = new Vector3(-hornVec.y, hornVec.x).normalized;
        w1.transform.position = parent.transform.TransformPoint(hornVec + perp * 0.25f);
        w2.transform.position = parent.transform.TransformPoint(hornVec + perp * -0.25f);

        // spawn blocks by the horn tip
        // add a spring joint connecting the horn to the body of the enemy
        skewered = Time.time;
      }
    }
  }

  // Update is called once per frame
  void Update () {
	  
	}

	// Use this for initialization
	void Start () {
	
	}
}
