using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
    public Texture pauseButtonTexture;
	
	public bool paused = false;
	
	void Awake(){
		// Check that the game is not paused when it starts
		paused = false;
		Resume();
	}
	
    void OnGUI() {
        // Create the button
        if (GUI.Button(new Rect (Screen.width - 100,Screen.height - 100, 100, 100), pauseButtonTexture)){
			if (!paused){
				paused = true;
				Pause();
			} else {
				paused = false;
				Resume();
			}
		}
		if (paused){
			// Create the pause menu
	        if (GUI.Button(new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 90 , 150, 80), "Resume")){
				if (paused){
					paused = false;
					Resume();
				}
			}
			
			if (GUI.Button(new Rect ((Screen.width / 2) - 75, (Screen.height / 2), 150, 80), "Level select")){
				Application.LoadLevel(Levels.levelSelect);
			}
			
			if (GUI.Button(new Rect ((Screen.width / 2) - 75 , (Screen.height / 2) + 90, 150, 80), "Reset")){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
    }
	
	
	void Pause(){
		Time.timeScale = 0.0f;
	}
		
	void Resume(){
		Time.timeScale = 1.0f;
	}
}

