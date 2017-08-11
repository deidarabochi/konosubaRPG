using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalScript : MonoBehaviour {
    public int controllerNumber;

	// Use this for initialization
	void Start () {
        controllerNumber = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            controllerNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            controllerNumber = 2;
        }
    }
}
