using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {

  private Sprite[] particleSprites;

  private float particleProbability = 0.3f;

  private void SpawnParticle(){
    var p = new GameObject ();
    Debug.Log ("Layer: " + LayerMask.NameToLayer ("Particles"));
    p.layer = LayerMask.NameToLayer ("Particles");
    var sr = p.AddComponent<SpriteRenderer> ();
    sr.sprite = particleSprites [Random.Range (0, particleSprites.Length)];
    var t = p.transform;
    t.position = transform.position;
    p.AddComponent<Particle> ();
    //Debug.Log ("Spawn particle!");
  }

	// Use this for initialization
	void Start () {
    particleSprites = new[]{
      Resources.Load<Sprite>("blood1"),
      Resources.Load<Sprite>("blood2")
    };
	}
	
  void FixedUpdate(){
    if (Random.Range (0f, 1f) < particleProbability) {
      SpawnParticle ();
    }
  }
}
