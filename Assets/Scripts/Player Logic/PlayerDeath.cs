using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {
	
	protected Vector3 startingPosition;
	
	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( transform.position.y < -1){
			// The ball fell!
			transform.position = startingPosition;
		}
	}
}
