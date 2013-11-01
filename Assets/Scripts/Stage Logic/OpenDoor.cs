using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	public int requiredKeys = 1;
	protected Inventory inventory;
	
	public bool open = false;
	
	void Start() {
		inventory = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Inventory>();
	}
	
	// Check the player inventory to open
	void Update () {
		// If the player has enough keys
		if ((inventory.GetKeysCollected() >= requiredKeys) && !(open))
		{
			// OPEN DOOR
			animation.Play();
			open = true;
		}
	}
}
