using UnityEngine;
using System.Collections;

public class TileIce : MonoBehaviour {
	
	
	void OnTriggerStay(Collider other) {
        if ((other.tag == Tags.player) && (other.rigidbody)){
			Vector3 playerVelocity = other.rigidbody.velocity;
			// If the ball is over the tile we make it slide
			// We change the way that foce affects velocity of the object, giving it some inertia
			playerVelocity = Vector3.Lerp(other.constantForce.force, playerVelocity, 0.1f).normalized
										* playerVelocity.sqrMagnitude;
		}
    }
}
