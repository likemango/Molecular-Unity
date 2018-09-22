using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {

    public Vector3 newPosition;
    private Transform trans;
    public float magneticSpeed = 1;

	// Use this for initialization
	void Start () {
        trans = transform;
		
	}
	
	// Update is called once per frame
	void Update () {
        trans.position = Vector3.Lerp(trans.position, newPosition, Time.deltaTime * magneticSpeed);
        if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05)
        {
            trans.position = newPosition;
        }
		
	}
}
