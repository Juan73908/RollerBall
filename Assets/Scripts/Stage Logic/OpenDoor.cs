using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	public int requiredKeys = 1;
	
	public bool open = false;
	
	// Check the player inventory to open
	void Update () {
		// If the player has enough keys
		if ((Inventory.keysCollected >= requiredKeys) && !(open))
		{
			// OPEN DOOR
			animation.Play();
			open = true;
			Destroy(gameObject, 2.0f);
		}
	}
}
