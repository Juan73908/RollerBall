using UnityEngine;
using System.Collections;

public class TileBounce : MonoBehaviour {

	public float power = 4.0f;	
	
	protected Vector3 dir; 
	
	void Awake() {
		// The direction to push the player
		dir = transform.FindChild("BounceDirection").position - transform.position;
		dir.Normalize();
	}
	
	void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we bounce it
			other.rigidbody.velocity += dir * power;
		}
    }
}
