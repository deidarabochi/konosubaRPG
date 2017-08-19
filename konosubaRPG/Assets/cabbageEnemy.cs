using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbageEnemy : MonoBehaviour {
	public BoxCollider territory;
	GameObject player1;
	//GameObject player2;
	//GameObject player3;
	//GameObject player4;
	bool playerInTerritory;

	public GameObject enemy;
	BasicEnemy basicenemy;

	// Use this for initialization
	void Start ()
	{
		player1 = GameObject.FindGameObjectWithTag ("kuzuma");
		//player2 = GameObject.FindGameObjectWithTag ("megumin");
		//player3 = GameObject.FindGameObjectWithTag ("akua");
		//player4 = GameObject.FindGameObjectWithTag ("oppai");
		basicenemy = enemy.GetComponent <BasicEnemy> ();
		playerInTerritory = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (playerInTerritory == true)
		{
			basicenemy.MoveToPlayer ();
		}

		if (playerInTerritory == false)
		{
			basicenemy.Rest ();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == player1)
		{
			playerInTerritory = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player1) 
		{
			playerInTerritory = false;
		}
	}
}

public class BasicEnemy : MonoBehaviour
{
	public Transform target;
	public float speed = 2f;
	public float attack1Range = 1f;
	public int attack1Damage = 1;
	public float timeBetweenAttacks;


	// Use this for initialization
	void Start ()
	{
		Rest ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void MoveToPlayer ()
	{
		//rotate to look at player
		transform.LookAt (target.position);
		transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

		//move towards player
		if (Vector3.Distance (transform.position, target.position) > attack1Range) 
		{
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
		}
	}

	public void Rest ()
	{

	}
}
