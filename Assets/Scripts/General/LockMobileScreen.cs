using UnityEngine;
using System.Collections;

public class LockMobileScreen : MonoBehaviour {
	
	public int seconds;
	
	void Start () {
		Screen.sleepTimeout = seconds;
	}
}
