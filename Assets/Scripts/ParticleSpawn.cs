using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {

  private Sprite[] particleSprites;

  private float particleProbability = 0.7f;

  private float created;

  private void SpawnParticle(){
    var p = new GameObject ();
    var sr = p.AddComponent<SpriteRenderer> ();
    sr.sprite = particleSprites [Random.Range (0, particleSprites.Length)];
    if (Random.Range (0, 2) == 0) {
      sr.sortingLayerName = "Particles";
    }
    var t = p.transform;
    t.position = transform.position;
    p.AddComponent<Particle> ();
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
