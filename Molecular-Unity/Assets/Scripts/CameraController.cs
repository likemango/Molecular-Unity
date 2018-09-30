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
    private float orbitDampening = 10f; // how long it takes for the camera to reach it destination
    //private float scrollDampening = 6f; // the larger the number the less time it takes for the camera to reach it destinatio

    //[SerializeField]
    private static float mouseSensitivity = 5f; // how much mouse movement across the screen
    private static float scrollSensitivity = 2f;
    private static float minCameraDistance = 1f;
    private static float maxCameraDistance = 100f;
    private bool cameraDisabled = false;

    // Changeable properties that can be used for control design
    public static float MouseSensitivity
    {
        get
        {
            return mouseSensitivity;
        }

        set
        {
            mouseSensitivity = value;
        }
    }

    public static float ScrollSensitivity
    {
        get
        {
            return scrollSensitivity;
        }

        set
        {
            scrollSensitivity = value;
        }
    }

    public static float MinCameraDistance
    {
        get
        {
            return minCameraDistance;
        }

        set
        {
            minCameraDistance = value;
        }
    }

    public static float MaxCameraDistance
    {
        get
        {
            return maxCameraDistance;
        }

        set
        {
            maxCameraDistance = value;
        }
    }

    public bool CameraDisabled
    {
        get
        {
            return cameraDisabled;
        }

        set
        {
            cameraDisabled = value;
        }
    }


    // Use this for initialization
    void Start()
    {
        this.cameraMain = this.transform; // add the transform of the game object this script is attached to
        this.cameraPivot = this.transform.parent;
    }

    void Update()
    {
        moveCameraPosition();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CameraDisabled = !CameraDisabled; // disables and enables the camera
        }
        
        if (!CameraDisabled)
        {
            // Rotation of the Camera based on Mouse Coordinates
            if (Input.GetAxis("Mouse X") != 0 && Input.GetButton("Mouse 1") || Input.GetAxis("Mouse Y") != 0 && Input.GetButton("Mouse 1")) // only triggers when the mouse is not stationary
            {
                localRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;
            }

            // Scrolling Input from the Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;
                scrollAmount *= (this.cameraDistance * 0.3f);  // allows for scrolling faster as far away and slower the closer.
                this.cameraDistance += scrollAmount * -1f; // -1 due to the way Unity detects the axis on the mouse scroll wheel
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, MinCameraDistance, MaxCameraDistance); // min and max camera is allowed to zoom
            }
        }

        // Setting actual camera roations and positions
        Quaternion cameraLocation = Quaternion.Euler(localRotation.y, localRotation.x, 0f); // Sets pitch and yaw of euler angles, z=0 due to no rotation, used to avoid gimble lock
        this.cameraPivot.rotation = Quaternion.Lerp(this.cameraPivot.rotation, cameraLocation, Time.deltaTime * orbitDampening); // Linear interpolation between current roation of camera at the start of the frame toward the target roation that was set above
        //this.cameraPivot.position = localPosition;

        // Setting camera zoom
        if (this.cameraMain.localPosition.z != this.cameraDistance * -1f)
        {
            this.cameraMain.localPosition = new Vector3(0f, 0f, this.cameraDistance * -1f);
        }
    }
    
    // Moves camera position to cneter around an element or a bond
    private void moveCameraPosition()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, MaxCameraDistance))
            {
                if (hit.transform != null)
                {
                    cameraPivot.position = hit.collider.bounds.center;
                }
            }
        }
    }
}
