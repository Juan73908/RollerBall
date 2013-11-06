using UnityEngine;
using System.Collections;

public class ChooseBall : MonoBehaviour {

	// Choose the proper ball
	void Awake () {
		// Deactive all the balls
		transform.FindChild("basketball").gameObject.SetActive(false);
		transform.FindChild("football").gameObject.SetActive(false);
		transform.FindChild("rugbyball").gameObject.SetActive(false);
		
		// Activate the proper object
		if(PlayerPrefs.GetInt(Prefs.ballSelection) == Prefs.basketball){
			transform.FindChild("basketball").gameObject.SetActive(true);
			
		} else if (PlayerPrefs.GetInt(Prefs.ballSelection) == Prefs.football){
			transform.FindChild("football").gameObject.SetActive(true);
			
		} else if (PlayerPrefs.GetInt(Prefs.ballSelection) == Prefs.rugbyball){
			transform.FindChild("rugbyball").gameObject.SetActive(true);
			
		} else {
			// Just in case
			transform.FindChild("basketball").gameObject.SetActive(true);
		}
	}
}
