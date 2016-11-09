using UnityEngine;
using System.Collections;

public class ParticleSpawn : MonoBehaviour {

  public GameObject[] particlePrefabs;

  private float timeCreated;
  private float particleInterval = 0.2f;
  private int particlesCreated = 0;

  private void SpawnParticle(){
    var p = Instantiate(particlePrefabs[Random.Range(0, particlePrefabs.Length)]);
    p.transform.position = transform.position;
  }

	// Use this for initialization
	void Start () {
    timeCreated = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
    var particles = Mathf.FloorToInt((Time.time - timeCreated) / particleInterval);
    while (particlesCreated < particles) {

    }
	}
}
