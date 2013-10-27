using UnityEngine;
using System.Collections;

public class TileGlue : MonoBehaviour {

	public float power = 1.0f;
	public GameObject player;
	

	void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we slow it
			player.rigidbody.velocity *= 0.7f * power;
		}
    }
}
