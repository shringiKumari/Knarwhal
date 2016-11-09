using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {

  private float created;

  private Vector3 pos;
  private Vector3 scale;

  private Vector3 dir;
  private float peakTime;
  //private float 

	// Use this for initialization
	void Start () {
    created = Time.time;
    pos = transform.position;
    scale = transform.localScale;

    var angle = Random.Range (0f, 360f) * Mathf.Deg2Rad;
    dir = new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle));
	}
	
	// Update is called once per frame
	void Update () {
    var dt = Time.time - created;
    transform.position = pos + dir * dt;
    transform.localScale = scale / dt;
	}
}
