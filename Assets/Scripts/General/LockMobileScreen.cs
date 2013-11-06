using UnityEngine;
using System.Collections;

public class LockMobileScreen : MonoBehaviour {
		
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
}
