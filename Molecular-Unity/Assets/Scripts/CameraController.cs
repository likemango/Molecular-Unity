using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera myCamera;
    private float distanceZoom = -10;
    private float movementX = 0;
    private float movementY = 0;


    // Use this for initialization
    void Start () {
        myCamera = transform.GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        HandleZoom();
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
