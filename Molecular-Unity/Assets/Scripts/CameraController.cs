using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera myCamera;
    private float distanceZoom = -10;
    private float movementX = 0;
    private float movementY = 0;
    //private Vector3 offset;
    //private Vector3 orgin;

    // Use this for initialization
    void Start () {
        myCamera = transform.GetComponent<Camera>();
        //offset = transform.position - orgin;
    }
	
	// Update is called once per frame
	void Update () {
        HandleZoom();
        Vector3 orgin = Vector3.zero;
        //distance = Math.Sqrt(myCamera)
        //bool leftMouseClick = Input.GetButton("Mouse 0");
        //transform.position = orgin + offset;
    }

    private void HandleZoom() {
        float ScrollMovement = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollMovement < 0)
        {
            distanceZoom--;
        }
        if (ScrollMovement > 0)
        {
            distanceZoom++;
        }
        bool rightMouseClick = Input.GetButton("Mouse 1");
        if (rightMouseClick)
        {
            movementX = Input.GetAxis("Mouse X") + movementX;
            movementY = Input.GetAxis("Mouse Y") + movementY;
        }
        Vector3 cameraZoom = new Vector3(movementX, movementY, distanceZoom);
        myCamera.transform.position = cameraZoom;
    }
}
