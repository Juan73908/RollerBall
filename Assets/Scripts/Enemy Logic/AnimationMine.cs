using UnityEngine;
using System.Collections;

public class AnimationMine : MonoBehaviour {
	
	public float rotationSpeed = 45.0f;
	
	// 
	void Update () {
		transform.Rotate(new Vector3( 0, rotationSpeed * Time.deltaTime, 0));
	}
}
