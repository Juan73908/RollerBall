using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	
	protected int rows = 4;
	protected int columns = 5;
	
	protected int marginLeft = 100;
	protected int marginRight = 100;
	protected int marginUp = 100;
	protected int marginDown = 10;
	
	protected int innerGap = 10;
	
	protected int buttonHeight;
	protected int buttonWidth;
	
	
    void OnGUI() {
		// Calculate the size of the buttons
		buttonWidth = (Screen.width - marginLeft - marginRight) / rows - innerGap;
		buttonHeight = (Screen.height - marginUp - marginDown) / columns - innerGap;
		
		int curLevel = 1;
		
		// This is ugly and hardcoded, but there is no simple way to do it with unity
		for (int i = 1; i <= columns; i++){
			for (int j = 1; j <= rows; j++){
				
				// Calculate the position of the buttons
				int xPos = marginLeft + 
						((Screen.width - marginLeft - marginRight) / rows) * (j - 1) + innerGap /2;
				int yPos = marginUp +
						((Screen.height - marginUp - marginDown) / columns) * (i - 1) + innerGap /2;
				
				// Add the buttons
				if (GUI.Button(new Rect( xPos, yPos, buttonWidth, buttonHeight), "Level " + curLevel))
					// Add the action of the buttons
	            	Application.LoadLevel(Levels.GetLevelName(curLevel));
				
				curLevel += 1;
			}
		}        
    }
}
