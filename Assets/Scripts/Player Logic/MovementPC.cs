using UnityEngine;
using System.Collections;

public class MovementPC : MonoBehaviour {
	
	public float speed = 20.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hx = Input.GetAxis("Horizontal");
		float hz = Input.GetAxis("Vertical");
		constantForce.force = new Vector3(speed * hx, 0, speed * hz);
		
	}
}
