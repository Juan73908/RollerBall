using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {
	
	protected static GameMusic instance;
	
	public AudioClip song;
	
	protected GameObject player;
	
    public static GameMusic GetInstance(){
    	return instance;
    }
	
	// Singlenton pattern for in between scenes
    void Awake() {
    	if (instance != null && instance != this) {
    		Destroy(this.gameObject);
    		return;
    	} else {
   			instance = this;
    	}
    	DontDestroyOnLoad(this.gameObject);
    }
	
	void Start() {
		// Play the song at start
		if( gameObject.audio.clip != song){
			gameObject.audio.clip = song;
			gameObject.audio.Play();
			gameObject.audio.loop = true;
		}
	}
	
	void Update() {
		// Get the reference to the player
		player = GameObject.FindGameObjectWithTag(Tags.player);
		// Follow the ball very frame
		if(player != null){
			transform.position = player.transform.position;
		}
	}
	
}