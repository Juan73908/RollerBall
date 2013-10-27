using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	protected int keysCollected = 0;
	
	// We check triggers with the keys to collect them
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Tags.key && !PlayerStatus.dead)
		{
			keysCollected += 1;
			Destroy(other.gameObject);
			Debug.Log("Keys collected: " + keysCollected);
		}
	}
	
	// Getter
	public int GetKeysCollected ()
	{
		return keysCollected;
	}
}
