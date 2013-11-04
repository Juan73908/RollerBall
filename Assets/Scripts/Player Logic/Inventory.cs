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
			
			if(Application.loadedLevel < Levels.count)
				// Load next level if there is
				Invoke("NextLevel", 2.0f);
			else
				Debug.Log("You finished the game :D");
		}
	}
	
	// Call the next level with delay
	void NextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	// Getter
	public int GetKeysCollected ()
	{
		return keysCollected;
	}
}
