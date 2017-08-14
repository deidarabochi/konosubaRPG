using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target3 : MonoBehaviour {
	private float clickX;
	private float clickY;

	public GameObject globalObject;
	private globalScript otherScriptToAccess;

	//The controllerNumber int variable from globalScript
	private int playerControllerNumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		otherScriptToAccess = globalObject.GetComponent<globalScript>(); //assigned our GameObject above to the script of globalScript
		playerControllerNumber = otherScriptToAccess.controllerNumber;
		if (playerControllerNumber == 3 && Input.GetMouseButtonDown (1)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Obtains world coordinates of right-clicked area
			clickX = Mathf.Round(pos.x);
			clickY = Mathf.Round(pos.y);
			transform.position = new Vector3(clickX, clickY, 0);
		}
	}
}
