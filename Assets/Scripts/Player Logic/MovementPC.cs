using UnityEngine;
using System.Collections;

public class MovementPC : MonoBehaviour {
	
	public float speed = 20.0f;
	
	public float maxForce = 12.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hx = Input.GetAxis("Horizontal");
		float hz = Input.GetAxis("Vertical");
		
		// We calculate the force to apply
		Vector3 force = new Vector3(speed * hx, 0, speed * hz);
		
		if (force.sqrMagnitude > maxForce)
			// If the force is too big we nerf it
			force = force.normalized * maxForce;
		
		constantForce.force = force;
		
	}
}
