using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
    public Texture pauseButtonTexture;
	
	public bool paused = false;
	
	protected bool displayingVictory = false;
	protected bool displayingDefeat = false;
	
	protected string victoryMessage;
	protected string defeatMessage;
	
	public GUIStyle guiStyleLevel;
	public GUIStyle guiStyleVictory;
	public GUIStyle guiStyleDefeat;
	
	
	void Awake(){
		// Check that the game is not paused when it starts
		Resume();
		
		// Initialize the victory and defeat messages
		victoryMessage = getRandomVictoryMessage();
		defeatMessage = getRandomDefeatMessage();
	}
	
    void OnGUI() {
		// Display the current level
		GUI.Label(new Rect(50, 20, 100, 20), "Level " + Application.loadedLevel, guiStyleLevel);
		
        // Create the button
        if (GUI.Button(new Rect (Screen.width - 100,Screen.height - 100, 100, 100), pauseButtonTexture)){
			if (!paused){
				Pause();
			} else {
				Resume();
			}
		}
		
		// Show victory message
		if(Inventory.levelCompleted && !displayingDefeat){
			
			displayingVictory = true;

			GUI.Label(new Rect( 0 , (Screen.height / 2) - 100, Screen.width, 100),
								victoryMessage, guiStyleVictory);
		}
		
		// Show defeat message
		if(PlayerStatus.dead && !displayingVictory){
			
			displayingDefeat = false;
			
			GUI.Label(new Rect( 0 , (Screen.height / 2) - 50, Screen.width, 100),
								defeatMessage, guiStyleDefeat);
		}
		
		if (paused){
			// Create the pause menu
	        if (GUI.Button(new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 90 , 150, 80), "Resume")){
				// Resume button
				if (paused){
					Resume();
				}
			}
			
			if (GUI.Button(new Rect ((Screen.width / 2) - 75, (Screen.height / 2), 150, 80), "Level select")){
				// Level select button
				Application.LoadLevel(Levels.levelSelect);
			}
			
			if (GUI.Button(new Rect ((Screen.width / 2) - 75 , (Screen.height / 2) + 90, 150, 80), "Reset")){
				// Reset button
				Application.LoadLevel(Application.loadedLevel);
			}
		}
    }
	
	
	void Pause(){
		paused = true;
		Time.timeScale = 0.0f;
	}
		
	void Resume(){
		paused = false;
		Time.timeScale = 1.0f;
	}
	
	// Cool victory random messages
	protected string[] victoryMessages = new string[] {
		"Well done!",
		"Oh yeah!",
		"That was sweet",
		"Keep it rollin'",
		"Awesome :D",
		"That was good",
		"Fast as lighning ;)",
		"You are a master",
		"Rate 5 ;D",
		"How did you manage? :O",
		"I didn't though you could make it",
		"Impressive!",
		"Amazing!",
		"Delicious diamond :P",
		"Will you make the next one?",
		"Piece of cake!",
		"They see you rollin', they hatin'",
		"Omagawd!!1 ^^",
		"Victory!!",
		"Here! A cookie!"
	};
	
	string getRandomVictoryMessage(){
		return victoryMessages[Random.Range( 0, victoryMessages.Length)];
	}
		
	// Cool defeat random messages
	protected string[] defeatMessages = new string[] {
		"Woops",
		"What happened?",
		"You failed",
		"Can't you do it better? :)",
		"Oh no! :(",
		"You almost had it :P",
		"FAIL",
		"Deafeat!!",
		"Will you surrender?",
		"I knew you couldn't make it :/",
		"Too hard?",
		"Too bad...",
		"Ohhhhh...",
		"Try again",
		"Come on!",
		"You were not supposed to fail there",
		"The last try!",
		"Hihihi, losser",
		"What was that? xD",
		"I guess that was your best",
		"Don't hate the game...",
		"At least you tried... ^^",
		"Diamond is waiting",
		"No rollin'? :P",
		"Muahahahah!1!",
		"There is no cake for you",
		"This was the easy level...",
		"Insert Coin ;)",
	};
	
	string getRandomDefeatMessage(){
		return defeatMessages[Random.Range( 0, defeatMessages.Length)];
	}
}

