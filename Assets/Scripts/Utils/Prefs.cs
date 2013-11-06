using UnityEngine;
using System.Collections;

public class Prefs : MonoBehaviour {

	public const string ballSelection = "Ball";
	public const int basketball = 0; // PlayerPrefs.GetInt() returns 0 if not initialized
	public const int football = 1;
	public const int rugbyball = 2;
	
	public const string lastCompletedLevel = "LastCompletedLevel";
	
	public const string sound = "Sound";
	public const int on = 0;
	public const int off = 1;
	

	
}
