using UnityEngine;
using System.Collections;

public class TilePush : MonoBehaviour {

	public float power = 1000.0f;
	
	protected Vector3 dir; 
	
	void Awake() {
		// The direction to push the player
		dir = transform.FindChild("PushDirection").position - transform.position;
		dir.Normalize();
	}
	
	
    void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we push it
			other.constantForce.force += dir * power * Time.deltaTime;
		}
    }
}
