using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	private float clickX;
	private float clickY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Obtains world coordinates of right-clicked area
			clickX = Mathf.Round(pos.x);
			clickY = Mathf.Round(pos.y);
			transform.position = new Vector3(clickX, clickY, 0);
		}
	}
}
