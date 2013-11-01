﻿using UnityEngine;
using System.Collections;

public class TilePush : MonoBehaviour {

	public float power = 500.0f;
	
	protected Vector3 dir; 
	
	void Awake() {
		// The direction to push the player
		dir = GameObject.Find("PushDirection").transform.position - transform.position;
		dir.Normalize();
	}
	
	
    void OnTriggerStay(Collider other) {
		
        if ((other.tag == Tags.player) && (other.rigidbody)){
			// If the ball is over the tile we push it
			other.constantForce.force += dir * power * Time.deltaTime;
		}
    }
}