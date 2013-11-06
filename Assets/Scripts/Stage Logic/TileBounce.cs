using UnityEngine;
using System.Collections;

public class TileBounce : MonoBehaviour {

	public float power = 4.0f;	
	
	protected Vector3 dir; 
	
	protected AudioSource audioSource;
	
	void Awake() {
		// The direction to push the player
		dir = transform.FindChild("BounceDirection").position - transform.position;
		dir.Normalize();
		
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we bounce it
			other.rigidbody.velocity += dir * power;
			
			// Play sound
   	 		audioSource.clip = Resources.Load(Res.bounce) as AudioClip;
			if((audioSource.isPlaying == false) && (audioSource.clip != null)){
    			audioSource.minDistance = 100.0f;
				audioSource.Play();
			}
		}
    }
}
