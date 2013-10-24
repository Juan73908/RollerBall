using UnityEngine;
using System.Collections;

public class ExplosionMine: MonoBehaviour {
	
    public float radius = 2.0f;
    public float power = 2000.0f;
    public float upwardsModifier = 1.0f;
	
    void OnTriggerEnter(Collider other) {
		
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		
        foreach (Collider hit in colliders) {
            if (hit.rigidbody)
                hit.rigidbody.AddExplosionForce(power, explosionPos, radius, upwardsModifier);
		}
    }
}
