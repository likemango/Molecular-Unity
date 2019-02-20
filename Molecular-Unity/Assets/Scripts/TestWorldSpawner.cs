using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorldSpawner : MonoBehaviour
{


    private GameObject moleculeSpawn;
    private Vector3 location;
    private Quaternion rotation;
    private int testlocationy = 1;
    private int testlocationz = 1;

    void Update()
    {
        Spawn();
        location = new Vector3(0, testlocationy, testlocationz);
        testlocationy++;
        testlocationz++;
    }

    private void Spawn()
    {
        var spawnTemp = Resources.Load("TestBox");
        GameObject spawnGameObject = Instantiate(spawnTemp, location, transform.rotation) as GameObject;

    }

}
