using UnityEngine;
using System.Collections;

public class Levitate : MonoBehaviour {
	
	
	public float range = 0.5f;
	public float speed = 0.5f;
	
	protected float maxHeight;
	protected float minHeight;
	
	
	void Start() {
		// Initialize the levitation values
		minHeight = transform.position.y;
		maxHeight = minHeight + range;		
	}
	
	
	void Update () {
		// Use sinusoidal movement for the levitation
		transform.position += (maxHeight - minHeight)*
								(Mathf.Sin(2*Mathf.PI*speed*Time.time) - 
									Mathf.Sin(2*Mathf.PI*speed*(Time.time - Time.deltaTime)))
										* new Vector3(0,1,0);
		
	}
}
