using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	
	protected int rows = 6;
	protected int columns = 3;
	
	protected int marginLeft = 100;
	protected int marginRight = 100;
	protected int marginUp = 100;
	protected int marginDown = 20;
	
	protected int innerGap = 10;
	
	protected int buttonHeight;
	protected int buttonWidth;
	
	protected int ballButtonSize;
	
	public Texture basketballTexture;
	public Texture footballTexture;
	public Texture rugbyballTexture;
	public Texture googlePlayTexture;

	public string googlePlayURL;
	
    void OnGUI() {
		// Calculate the size of the square ball buttons
		ballButtonSize = Mathf.Min( marginUp - (marginDown * 2), 
									(Screen.width - (marginLeft - marginRight - (innerGap * 2)) / 3));

		// Add the googlePlay button
		if (GUI.Button(new Rect(marginLeft + innerGap/2, marginDown, ballButtonSize * 4, ballButtonSize), googlePlayTexture))
#if UNITY_WEBPLAYER
			Application.ExternalEval("window.open('" + googlePlayURL + "','_blank')");
#else
			Application.OpenURL(googlePlayURL);
#endif

		// Add the buttons for the ball selection
		for (int i = 0; i < 3; i++){
			// Select the color
			if (PlayerPrefs.GetInt(Prefs.ballSelection) == i){
				GUI.backgroundColor = Color.black;
			}
		
			// Create the button
			if (GUI.Button(new Rect(Screen.width - marginRight - ((ballButtonSize + innerGap)* (3 - i)), 
									marginDown, ballButtonSize, ballButtonSize), getButtonTexture(i)))
	        	PlayerPrefs.SetInt(Prefs.ballSelection, i);
			
			// Revert the color
			GUI.backgroundColor = Color.white;
		}
		
		// Calculate the size of the buttons
		buttonWidth = (Screen.width - marginLeft - marginRight) / rows - innerGap;
		buttonHeight = (Screen.height - marginUp - marginDown) / columns - innerGap;
		
		int curLevel = 1;
		
		// Set the color of the available buttons
		GUI.backgroundColor = Color.green;
		
		// This is ugly, but there is no simple way to do it with unity
		for (int i = 1; i <= columns; i++){
			for (int j = 1; j <= rows; j++){
				
				// Calculate the position of the buttons
				int xPos = marginLeft + 
						((Screen.width - marginLeft - marginRight) / rows) * (j - 1) + innerGap /2;
				int yPos = marginUp +
						((Screen.height - marginUp - marginDown) / columns) * (i - 1) + innerGap /2;
				
				// Calculate the color of the buttons
				if (curLevel > PlayerPrefs.GetInt(Prefs.lastCompletedLevel) + 1){
					GUI.backgroundColor = Color.red;
					GUI.enabled = false;
				}
				
				// Add the buttons
				if (GUI.Button(new Rect( xPos, yPos, buttonWidth, buttonHeight), "Level " + curLevel))
					// Add the action of the buttons
	            	Application.LoadLevel(Levels.GetLevelName(curLevel));
				
				curLevel += 1;
			}
		}
		
		// Revert the color
		GUI.backgroundColor = Color.white;
		GUI.enabled = true;
    }
	
	// Helper function to define textures of the buttons
	Texture getButtonTexture(int id){
		
		if(id == Prefs.basketball)
			return basketballTexture;
		
		else if (id == Prefs.football)
			return footballTexture;
		
		else if (id == Prefs.rugbyball)
			return rugbyballTexture;
		
		// Just in case
		return basketballTexture;
	}
}
