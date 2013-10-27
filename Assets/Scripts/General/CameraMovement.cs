using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public GameObject player;
	
	public float speed = 4.0f;
	
	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;
	
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag(Tags.player);
		relCameraPos = transform.position - player.transform.position;	
	}
	
	void FixedUpdate()
	{
		if (!PlayerStatus.dead == true)
		{
			// We only follow the player if it is alive
			Vector3 newPos = player.transform.position + relCameraPos;
			transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
		}
	}
}
