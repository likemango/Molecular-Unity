using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Magnetic WIP NOT FINISHED
 * This should implement the "magnetic" snapping feature of connecting a bond to an element. If within range of element/bond the two pieces should be able to
 * snap together to form a connection
*/

public class Magnetic : MonoBehaviour {

    public Collider bondTop;
    public Collider bondBottom;
    public Collider element;
    public GameObject target;
    private Transform trans;
    public float magneticSpeed = 1;
    
	// Use this for initialization
	void Start () {
        trans = transform;
        
	}

    // Fixed update is used for physics calculations FixedUpdate can run once, zero, or several times per frame, depending on how many physics frames per second are set in the time settings, and how fast/slow the framerate is.
    void FixedUpdate () {
        //trans.position = Vector3.Lerp(trans.position, element.transform.position, Time.deltaTime * magneticSpeed);
        if (bondTop.bounds != element.bounds)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, magneticSpeed);
        }
	}
}
