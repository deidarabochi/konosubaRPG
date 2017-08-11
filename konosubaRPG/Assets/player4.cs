using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player4 : MonoBehaviour
{
    private float speed;
    public GameObject globalObject;
    private globalScript otherScriptToAccess;

    //The controllerNumber int variable from globalScript
    private int playerControllerNumber;

    private float destX;
    private float destY;
    private bool isMoving;

    // Use this for initialization
    void Start()
    {
        speed = 3;
        destX = 0;
        destY = 0;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        otherScriptToAccess = globalObject.GetComponent<globalScript>(); //assigned our GameObject above to the script of globalScript
        playerControllerNumber = otherScriptToAccess.controllerNumber;
        if (playerControllerNumber == 4 && Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Obtains world coordinates of right-clicked area
            destX = pos.x;
            destY = pos.y;

            Debug.Log(destX);
            Debug.Log(destY);

            isMoving = true;
        }
        if (isMoving == true)
        {
            float axisX;
            float axisY;
            if (transform.position.x < destX)
            {
                axisX = 1;
            }
            else if (transform.position.x > destX)
            {
                axisX = -1;
            }
            else
            {
                axisX = 0;
            }
            if (transform.position.y < destY)
            {
                axisY = 1;
            }
            else if (transform.position.y > destY)
            {
                axisY = -1;
            }
            else
            {
                axisY = 0;
            }
            if (Mathf.Abs(transform.position.x - destX) < 0.06)
            {
                axisX = 0;
            }
            if (Mathf.Abs(transform.position.y - destY) < 0.06)
            {
                axisY = 0;
            }
            if (axisX == 0)
            {
                axisY *= 1.414f;
            }
            if (axisY == 0)
            {
                axisX *= 1.414f;
            }
            transform.Translate(new Vector3(axisX, axisY) * Time.deltaTime * speed);
            if (axisX == 0 && axisY == 0)
            {
                isMoving = false;
            }
        }
    }
}
