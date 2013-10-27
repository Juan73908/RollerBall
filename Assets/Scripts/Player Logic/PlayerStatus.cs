using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	protected Vector3 startingPosition;
	protected Quaternion startingRotation;
	
	// Player will be dead untill re-spawn
	public static bool dead = false;
	public float deadTime = 2.0f; // Re-spawn cooldown	
	
	void Start () {
		// Save initial values for re-spawning
		startingPosition = transform.position;
		startingRotation = transform.rotation;
	}
	
	
	void Update () {
		if (transform.position.y < -1 && !dead){
			// The ball fell!
			Die();
			Debug.Log("The player died falling to the... VOID! :O");
		}
	}
	
	// Check for collisions with the environment
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == Tags.enemies && !dead)
		{
			// The player touched an enemy!!
			Die();
			Debug.Log ("The player touched something nasty... OUCH! :(");
		}
	}
	
	// Check for collisions with triggers
	void OnTriggerEnter(Collider other) {
		if (other.tag == Tags.enemies && !dead)
		{
			// The player touched an enemy!!
			Die();
			Debug.Log ("The player flied away... WII! :P");
		}
	}
	
	// The player should wait and re-spawn
	void Die(){
		dead = true;
		// Disable the external forces applied to the player
		constantForce.enabled = false;
		// Wait
		Invoke("ReSpawn", deadTime);
	}
	
	// Called when the player comes into life again
	void ReSpawn(){
		// Re-enable components
		constantForce.enabled = true;
		// Back to the initial position
		Reset();
		dead = false;
	}
	
	// Reset the player to the original position
	void Reset() {
		// We restore initial values
		transform.position = startingPosition;
		transform.rotation = startingRotation;
		if (rigidbody != null) {
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
