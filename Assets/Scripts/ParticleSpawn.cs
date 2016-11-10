using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {

  private Sprite[] particleSprites;

  private float particleProbability = 0.7f;

  private float created;

  private void SpawnParticle(){
    var o = new GameObject ();
    var sr = o.AddComponent<SpriteRenderer> ();
    sr.sprite = particleSprites [Random.Range (0, particleSprites.Length)];
    bool foreground = Random.Range (0, 2) == 0;
    if (foreground) {
      sr.sortingLayerName = "Particles";
    }
    var t = o.transform;
    t.position = transform.position;
    var p = o.AddComponent<Particle> ();

    float angle;
    //angle = Random.Range (160f, 200f) * Mathf.Deg2Rad;
    angle = Random.Range (-20f, 20f) * Mathf.Deg2Rad;
    if (foreground) {
      //angle = Random.Range (160f, 200f) * Mathf.Deg2Rad;
    }
    else {
    }
    p.dir = transform.TransformVector(new Vector3 (Mathf.Cos(angle), Mathf.Sin(angle))) * transform.localScale.x;
  }

	// Use this for initialization
	void Start () {
    created = Time.time;

    particleSprites = new[]{
      Resources.Load<Sprite>("blood1"),
      Resources.Load<Sprite>("blood2")
    };
	}
	
  void FixedUpdate(){
    var dt = Time.time - created;
    var prob = particleProbability / (1f + dt * 1.5f);
    if (Random.Range (0f, 1f) < prob) {
      SpawnParticle ();
    }
    if (prob <= 0.01f) {
      Destroy (this);
    }
  }
}
