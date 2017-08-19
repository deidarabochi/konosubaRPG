using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class player2 : MonoBehaviour
{
	public GameObject globalObject;
	private globalScript otherScriptToAccess;
	//Rigidbody2D rbody;
	Animator anim;

	//The controllerNumber int variable from globalScript
	private int playerControllerNumber;

	//The point to move to
	public Transform target;

	private Seeker seeker;

	//The calculated path
	public Path path;

	//The AI's speed per second
	public float speed = 2;

	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 0.02f;

	//The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	public void Start ()
	{
		seeker = GetComponent<Seeker>();
		//rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();


		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		//seeker.StartPath( transform.position, target.position, OnPathComplete );
		anim.SetBool ("isWalking", false);
	}

	public void OnPathComplete ( Path p )
	{
		//Debug.Log( "Yay, we got a path back. Did it have an error? " + p.error );
		if (!p.error)
		{
			path = p;
			//Reset the waypoint counter
			currentWaypoint = 0;
		}
	}

	public void FixedUpdate ()
	{
		anim.SetBool ("isWalking", false);
		if (path == null)
		{
			//We have no path to move after yet
			return;
		}

		if (currentWaypoint >= path.vectorPath.Count)
		{
			//Debug.Log( "End Of Path Reached" );
			return;
		}

		//Direction to the next waypoint
		Vector3 dir = ( path.vectorPath[ currentWaypoint ] - transform.position ).normalized;
		dir *= speed * Time.fixedDeltaTime;
		this.gameObject.transform.Translate( dir );
		Debug.Log (dir);

		//Directional sprite change
		anim.SetBool ("isWalking", true);
		anim.SetFloat ("input_x", dir.x);
		anim.SetFloat ("input_y", dir.y);

		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		if (Vector3.Distance( transform.position, path.vectorPath[ currentWaypoint ] ) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
	void Update () {
		otherScriptToAccess = globalObject.GetComponent<globalScript>(); //assigned our GameObject above to the script of globalScript
		playerControllerNumber = otherScriptToAccess.controllerNumber;
		if (playerControllerNumber == 2 && Input.GetMouseButtonDown (1)) {
			seeker = GetComponent<Seeker>();
			//anim.SetBool ("isWalking", true);
			//Start a new path to the targetPosition, return the result to the OnPathComplete function
			seeker.StartPath( transform.position, target.position, OnPathComplete );
		}
	}
}
