using UnityEngine;
using System.Collections;

public class CrateStatus : MonoBehaviour {
	
	public int destroyOnY = -100;
	
	// Update is called once per frame
	void Update () {
		
		if ((rigidbody != null) && rigidbody.IsSleeping()) {
			// Mine will not detect the crate if it is sleeping
			rigidbody.WakeUp();
		}
		if (transform.position.y < destroyOnY)
		{
			// The crate fell, so we delete it
			Destroy(gameObject);
		}
	}
}
