using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Molecular Unity - CameraController
 * Mark Halle
 * Camera rotation and zoom functionallity.
 * Right mouse button pressed allows the camera to rotate about an orgin in 3D space
 * Assisted from: Emergent Sagas @ https://www.youtube.com/user/sliceofvice/
 */

public class CameraController : MonoBehaviour {

    private Transform cameraMain;
    private Transform cameraPivot;

    private Vector3 localRotation;
    private Vector3 localPosition;
    private float cameraDistance = 10f;

    public float mouseSensitivity = 5f; // how much mouse movement across the screen
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f; // how long it takes for the camera to reach it destination
    public float scrollDampening = 6f; // the larger the number the less time it takes for the camera to reach it destination
    public float minCameraDistance = 1f;
    public float maxCameraDistance = 100f;
    public bool cameraDisabled = false;


    // Use this for initialization
    void Start()
    {
        this.cameraMain = this.transform; // add the transform of the game object this script is attached to
        this.cameraPivot = this.transform.parent;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraDisabled = !cameraDisabled; // disables and enables the camera
        }

        /* Possible code for translation of the focal point
        if (Input.GetButton("Mouse 0"))
        {
            localPosition.x += Input.GetAxis("Mouse X") * mouseSensitivity;
            localPosition.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        */

        if (!cameraDisabled)
        {
            // Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 && Input.GetButton("Mouse 1") || Input.GetAxis("Mouse Y") != 0 && Input.GetButton("Mouse 1")) // only triggers when the mouse is not stationary
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y += Input.GetAxis("Mouse Y") * mouseSensitivity;
            }

            // Scrolling Input from the Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;
                scrollAmount *= (this.cameraDistance * 0.3f);  // allows for scrolling faster as far away and slower the closer.
                this.cameraDistance += scrollAmount * -1f; // -1 due to the way Unity detects the axis on the mouse scroll wheel
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, minCameraDistance, maxCameraDistance); // min and max camera is allowed to zoom
            }
        }

        // Setting actual camera roations and positions
        Quaternion cameraLocation = Quaternion.Euler(localRotation.y, localRotation.x, 0f); // Sets pitch and yaw of euler angles, z=0 due to no rotation, used to avoid gimble lock
        this.cameraPivot.rotation = Quaternion.Lerp(this.cameraPivot.rotation, cameraLocation, Time.deltaTime * orbitDampening); // Linear interpolation between current roation of camera at the start of the frame toward the target roation that was set above
        this.cameraPivot.position = localPosition;

        // Setting camera zoom
        if (this.cameraMain.localPosition.z != this.cameraDistance * -1f)
        {
            this.cameraMain.localPosition = new Vector3(0f, 0f, this.cameraDistance * -1f);
        }
    }
}
