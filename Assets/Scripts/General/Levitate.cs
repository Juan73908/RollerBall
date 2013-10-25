using UnityEngine;
using System.Collections;

public class Levitate : MonoBehaviour {
	
	public float maxHeight = 2.0f;
	public float minHeight = 1.5f;
	public float speed = 0.5f;
	
	
	void Update () {
		// We use sinusoidal movement for the levitation
		transform.position += (maxHeight - minHeight)*
								(Mathf.Sin(2*Mathf.PI*speed*Time.time) - 
									Mathf.Sin(2*Mathf.PI*speed*(Time.time - Time.deltaTime)))
										* new Vector3(0,1,0);
		
	}
}
