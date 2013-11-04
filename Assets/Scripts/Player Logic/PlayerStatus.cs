using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	protected Vector3 startingPosition;
	protected Quaternion startingRotation;
	
	// Player will be dead untill reload level
	public static bool dead = false;
	public float deadTime = 2.0f;
	
	void Start () {
		dead = false;
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
	
	// The player should wait and reload level
	void Die(){
		dead = true;
		// Disable the external forces applied to the player
		constantForce.enabled = false;
		// Wait
		Invoke("ReloadLevel", deadTime);
	}
	
	// Reload the level when character dies or player hits reset
	void ReloadLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
