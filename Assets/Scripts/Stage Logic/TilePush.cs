using UnityEngine;
using System.Collections;

public class TilePush : MonoBehaviour {

	public float power = 1.0f;
	public GameObject player;
	
	protected Vector3 dir; 
	
	void Awake() {
		// The direction to push the player
		dir = GameObject.Find("PushDirection").transform.position - transform.position;
		dir.Normalize();
	}
	
	
    void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we push it
			player.constantForce.force += dir * power * Time.deltaTime;
		}
    }
}
