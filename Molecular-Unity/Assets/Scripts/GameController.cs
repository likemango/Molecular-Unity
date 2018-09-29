using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Does nothing yet
public class GameController : MonoBehaviour
{
    private Vector3 orgin;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExplosionDamage(orgin, CameraController.MaxCameraDistance);

    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            print(hitColliders[i].gameObject.name);
            i++;
        }
    }
}
