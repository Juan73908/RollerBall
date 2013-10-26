using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	public GameObject player;
	
	public float smooth = 1.5f;
	
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
		Vector3 newPos = player.transform.position + relCameraPos;
		
		transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
	}
}
