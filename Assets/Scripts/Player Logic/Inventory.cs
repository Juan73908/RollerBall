using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	protected int keysCollected = 0;
	protected int diamondsCollected = 0;
	
	// We check triggers with the keys to collect them
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Tags.key && !PlayerStatus.dead)
		{
			keysCollected += 1;
			Destroy(other.gameObject);
		} 
		else if (other.tag == Tags.diamond && !PlayerStatus.dead)
		{
			diamondsCollected += 1;
			Destroy(other.gameObject);
			
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
	
	// Getter
	public int GetKeysCollected ()
	{
		return keysCollected;
	}
}
