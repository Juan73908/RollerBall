using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	protected Vector3 startingPosition;
	protected Quaternion startingRotation;
	
	protected AudioSource audioSource;
	
	// Player will be dead untill reload level
	public static bool dead = false;
	public float deadTime = 2.0f;
	
	// The height at which the ball is considered fallen
	public float deadOnY = -1.0f;
	
	void Awake () {
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	void Start () {
		dead = false;
	}
	
	
	void Update () {
		if (transform.position.y < deadOnY && !dead){
			// The ball fell!
			Die();
			Debug.Log("The player died falling to the... VOID! :O");
			// Play sound
   	 		audioSource.clip = Resources.Load(Res.fall) as AudioClip;
			if((audioSource.isPlaying == false) && (audioSource.clip != null)){
    			audioSource.minDistance = 100.0f;
				audioSource.Play();
			}
		}
	}
	
	// Check for collisions with the environment
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == Tags.enemies && !dead)
		{
			// The player touched an enemy!!
			Die();
			Debug.Log ("The player touched something nasty... OUCH! :(");
			// Play sound
   	 		audioSource.clip = Resources.Load(Res.shuriken) as AudioClip;
			if((audioSource.isPlaying == false) && (audioSource.clip != null)){
    			audioSource.minDistance = 100.0f;
				audioSource.Play();
			}
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
