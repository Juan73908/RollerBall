using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	protected GameObject player;
	
	public float speed = 4.0f;
	
	protected Vector3 relCameraPos;
	protected Vector3 newPos;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player);
		relCameraPos = new Vector3( 0.0f, 12.0f, -7.5f);
		// We initialize the position of the camera
		transform.position = player.transform.position + relCameraPos;
	}
	
	void FixedUpdate()
	{
		if (!PlayerStatus.dead)
		{
			// We only follow the player if it is alive
			Vector3 newPos = player.transform.position + relCameraPos;
			transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
		}
	}
}
