using UnityEngine;
using System.Collections;

public class MovementAndroid : MonoBehaviour {

		
	public float speed = 20.0f;
	
	// From the doc: http://docs.unity3d.com/Documentation/Manual/Input.html#AndroidInput
	void Update () {
		// If we are not on Android we exit
		if (Application.platform != RuntimePlatform.Android)
            enabled = false;
		
		Vector3 dir = new Vector3(0, 0, 0);
	
		// we assume that the device is held parallel to the ground, lightly facing to the player
		// and the Home button is in the right hand
	
		// remap the device acceleration axis to game coordinates:
		//  1) XY plane of the device is mapped onto XZ plane
		dir.x = Input.acceleration.x;
		dir.z = Input.acceleration.y + 0.25f; // More confortable to the user
		
		// We clean noise from the device.
		if (!(dir.sqrMagnitude <= 0.05)){
			// We make it easier to control.
			// Add a flat amount in the same direction of the vector
			dir += dir.normalized * 0.1f;
			// Apply a constant force to the ball
			constantForce.force = dir * speed;
		}
	}
}
