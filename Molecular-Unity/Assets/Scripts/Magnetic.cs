using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	
	// Update is called once per frame
	void Update () {
        //trans.position = Vector3.Lerp(trans.position, element.transform.position, Time.deltaTime * magneticSpeed);
        if (bondTop.bounds != element.bounds)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, magneticSpeed);
        }
	}
}
