using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	public int requiredKeys = 1;
	public Inventory inventory;
	
	public bool open = false;
	
	void Start() {
	}
	
	// Check the player inventory to open
	void Update () {
		// If the player has enough keys
		if ((inventory.GetKeysCollected() >= requiredKeys) && !(open))
		{
			// OPEN DOOR
			Debug.Log("Opening door");
			animation.Play();
			open = true;
		}
	}
}
