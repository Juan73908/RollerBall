using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float moveSpeed = 5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hx = Input.GetAxis("Horizontal");
		float hz = Input.GetAxis("Vertical");
		constantForce.force = new Vector3(moveSpeed * hx, 0, moveSpeed * hz);
		
	}
	
	
	// http://docs.unity3d.com/Documentation/Manual/Input.html#AndroidInput
	public float speed = 20.0f;

	void Update () {
		Vector3 dir = new Vector3(0, 0, 0);
	
		// we assume that the device is held parallel to the ground
		// and the Home button is in the right hand
	
		// remap the device acceleration axis to game coordinates:
		//  1) XY plane of the device is mapped onto XZ plane
		dir.x = Input.acceleration.x;
		dir.z = Input.acceleration.y;
		
		// We clean noise from the device.
		if (!(dir.sqrMagnitude <= 0.01)){
			// Apply a constant force to the ball
			constantForce.force = new Vector3(speed * dir.x, 0, speed * dir.z);
		}
	}
}
