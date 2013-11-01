using UnityEngine;
using System.Collections;

public class WaypointMovement : MonoBehaviour {

	public float speed = 2.0f;
    public Transform[] waypoints;
	public bool loop = true;
	public bool mirror = false; // Mirror has no effect if loop is not true
	protected bool mirroring = false;
	
	protected Vector3 currentDestination;
	protected Vector3 currentFacing;
    protected int targetwaypoint = 0;
	
	void Start()
	{
		if ((waypoints.Length<=1) || (waypoints[0] == null))
        {
            Debug.Log("Not enough waypoints on " + name);
            this.enabled = false;
		} else {
			// Initialize the waypoint
			currentDestination = waypoints[targetwaypoint].position;
			currentFacing = (currentDestination - transform.position).normalized;
		}
	}
	
	void FixedUpdate () 
	{
		// Calculate the next position of the gameObject
		Vector3 nextPosition = transform.position + currentFacing * speed * Time.deltaTime;
		// Check if the next position passes the destination
		if ((nextPosition - transform.position).sqrMagnitude >= (currentDestination - transform.position).sqrMagnitude)
		{
			// Stop at the target without passing it
			nextPosition = waypoints[targetwaypoint].position;
			// Check finished if we are not looping
			if(!loop && (targetwaypoint + 1) >= waypoints.Length )
				enabled = false;
			// Check finished and mirror
			if(loop && mirror && !mirroring && (targetwaypoint + 1) >= waypoints.Length) {
				mirroring = true;
			} else if (loop && mirror && mirroring && (targetwaypoint) <= 0){
				mirroring = false;
			}
			// Change destination
			if (loop && mirror && mirroring){
				// Mirror looping down
				targetwaypoint = (targetwaypoint - 1);
			} else if (loop && mirror && !mirroring){
				// Mirror looping up
				targetwaypoint = (targetwaypoint + 1);
			}
			if (!mirror) {
				// Normal looping
				targetwaypoint = (targetwaypoint + 1) % waypoints.Length;
				// To allow dinamic activation of mirror
				mirroring = false;
			}
			currentDestination = waypoints[targetwaypoint].position;
			currentFacing = (currentDestination - transform.position).normalized;
		}
		// Move towards the currentDestination
		transform.position = nextPosition;
	}
	
	// draws red line from waypoint to waypoint
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(waypoints==null)
            return;
        for(int i=0;i< waypoints.Length;i++)
        {
            Vector3 pos = waypoints[i].position;
            if(i>0)
            {
                Vector3 prev = waypoints[i-1].position;
                Gizmos.DrawLine(prev,pos);
            }
        }
    }
}
