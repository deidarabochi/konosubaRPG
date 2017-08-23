using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabbageEnemy : MonoBehaviour {
	public Transform player1;
	public Transform player2;
	//public Transform player3;
	//public Transform player4;
	float MoveSpeed = 0.7f;
	float MaxDist = 1.5f;
	float MinDist = 1.25f;
	float AgroDist = 3f;
	float DeAgroDist = 3.25f;
	bool isAgro = false;
	int whoAgro = 1;
	Vector3 dir = new Vector3(0, 0, 0);

	void Start()
	{

	}

	void Update()
	{
		//KAZUMA AGRO
		if (Vector3.Distance (transform.position, player1.position) <= AgroDist && isAgro == false) {
			isAgro = true;
			whoAgro = 1;
		}
		if (whoAgro == 1 && Vector3.Distance (transform.position, player1.position) >= DeAgroDist && isAgro == true) {
			isAgro = false;
		}

		if (whoAgro == 1) {
			dir = new Vector3(player1.position.x - transform.position.x, player1.position.y - transform.position.y, 0);
			Vector3.Normalize (dir);
			if (Vector3.Distance(transform.position, player1.position) >= MinDist && isAgro == true)
			{

				transform.position += dir * MoveSpeed * Time.deltaTime;



				if (Vector3.Distance(transform.position, player1.position) <= MaxDist)
				{
					//Here Call any function U want Like Shoot at here or something
				}

			}
		}

		//MEGUMIN AGRO
		if (Vector3.Distance (transform.position, player2.position) <= AgroDist && isAgro == false) {
			isAgro = true;
			whoAgro = 2;
		}
		if (whoAgro == 2 && Vector3.Distance (transform.position, player2.position) >= DeAgroDist && isAgro == true) {
			isAgro = false;
		}

		if (whoAgro == 2) {
			dir = new Vector3(player2.position.x - transform.position.x, player2.position.y - transform.position.y, 0);
			Vector3.Normalize (dir);
			if (Vector3.Distance(transform.position, player2.position) >= MinDist && isAgro == true)
			{

				transform.position += dir * MoveSpeed * Time.deltaTime;



				if (Vector3.Distance(transform.position, player2.position) <= MaxDist)
				{
					//Here Call any function U want Like Shoot at here or something
				}

			}
		}

	}
}
