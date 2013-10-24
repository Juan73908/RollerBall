using UnityEngine;
using System.Collections;

public class ExplosionMine: MonoBehaviour {
	
    public float radius = 2.0f;
    public float power = 2000.0f;
    public float upwardsModifier = 1.0f;
	public ParticleSystem explosionParticles;
	
    void OnTriggerEnter(Collider other) {
		
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		
        foreach (Collider hit in colliders) {
			// If there is a collision with the player
            if ((hit.tag == Tags.player) && (hit.rigidbody))
				// Apply explosion force
                hit.rigidbody.AddExplosionForce(power, explosionPos, radius, upwardsModifier);
				// Generate explosion
				explosionParticles.Play();
				// Destroy self
				//Destroy(gameObject, 0.05f);
		}
    }
}
