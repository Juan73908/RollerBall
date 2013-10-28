using UnityEngine;
using System.Collections;

public class TileGlue : MonoBehaviour {

	public float drag = 0.7f;	

	void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we slow it
			other.rigidbody.velocity *= drag;
		}
    }
}
