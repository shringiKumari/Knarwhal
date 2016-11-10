using UnityEngine;
using System.Collections;


public class Particle : MonoBehaviour {
  private float phaseBegan;
  private Vector3 pos;
  private Vector3 scale;
  private int currentPhase = 0;

  private Vector3 dir;

  delegate Vector3 Scale(float dt, Particle p);
  delegate Vector3 Pos(float dt, Particle p);

  class Phase {
    public float duration;
    public Scale scale;
    public Pos pos;
  }

  private static Phase[] phases = new[]{
    new Phase(){
      duration = 0.3f,
      scale = (dt, p) => (0.5f + dt) * p.scale * 5f,
      pos = (dt, p) => p.pos + p.dir * dt * 3f
    },
    new Phase(){
      duration = 1.2f,
      scale = (dt, p) => p.scale / (1f + dt * 5f),
      pos = (dt, p) => p.pos + p.dir * dt * 0.5f
    }
  };

	// Use this for initialization
	void Start () {
    phaseBegan = Time.time;
    pos = transform.position;
    scale = transform.localScale * Random.Range (0.1f, 0.6f);

    var angle = Random.Range (0f, 360f) * Mathf.Deg2Rad;
    dir = new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle));
	}
	
  void UpdateParticle() {
    var dt = Time.time - phaseBegan;
    var phase = phases [currentPhase];
    if (dt <= phase.duration) {
      transform.position = phase.pos (dt, this);
      transform.localScale = phase.scale (dt, this);
    }
    else {
      currentPhase += 1;
      if (currentPhase < phases.Length) {
        pos = phase.pos (phase.duration, this);
        scale = phase.scale (phase.duration, this);
        phaseBegan += phase.duration;
        UpdateParticle ();
      }
      else {
        Destroy (gameObject);
      }
    }
  }

  // Update is called once per frame
  void Update () {
    UpdateParticle ();
	}
}
