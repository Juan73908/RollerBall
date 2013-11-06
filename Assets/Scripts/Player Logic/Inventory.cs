using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	public static int keysCollected = 0;
	public static int diamondsCollected = 0;
	
	public static bool levelCompleted = false;
	
	protected AudioSource audioSource;
	
	void Awake(){
		keysCollected = 0;
		diamondsCollected = 0;
		levelCompleted = false;
		
		audioSource = gameObject.AddComponent<AudioSource>();
	}
	
	// We check triggers with the keys to collect them
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Tags.key && !PlayerStatus.dead)
		{
			keysCollected += 1;
			Destroy(other.gameObject);
			
			// Play sound
   	 		audioSource.clip = Resources.Load(Res.key) as AudioClip;
			if((audioSource.isPlaying == false) && (audioSource.clip != null)){
    			audioSource.minDistance = 100.0f;
				audioSource.Play();
			}
		} 
		else if (other.tag == Tags.diamond && !PlayerStatus.dead)
		{
			diamondsCollected += 1;
			Destroy(other.gameObject);
				
			// Play sound
   	 		audioSource.clip = Resources.Load(Res.diamond) as AudioClip;
			if((audioSource.isPlaying == false) && (audioSource.clip != null)){
    			audioSource.minDistance = 100.0f;
				audioSource.Play();
			}
			// Set the level progression
			PlayerPrefs.SetInt(Prefs.lastCompletedLevel,
					Mathf.Max(PlayerPrefs.GetInt(Prefs.lastCompletedLevel), Application.loadedLevel));
			// Level UP!
			levelCompleted = true;
			Invoke("NextLevel", 2.0f);
		}
	}
	
	// Call the next level with delay
	void NextLevel(){		
		if(Application.loadedLevel < Levels.count){
			// Load next level
			Application.LoadLevel(Application.loadedLevel + 1);
		}else {
			// Or if finished the game return to load screen
			Application.LoadLevel(Levels.levelSelect);
		}
	}
}
