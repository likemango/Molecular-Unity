using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour {

    List<string> premadeMolecules = new List<string>() {"Water", "Methane"};
    private string moleculeSelected;
    private GameObject moleculeSpawn;
    private float nextSpawnTime;
    [SerializeField]
    private float spawnDelay = 5;

    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        var moleculeTemp = Resources.Load("Molecules/" + moleculeSelected);
        moleculeSpawn = moleculeTemp as GameObject;
        Instantiate(moleculeSpawn, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawnTime;
    }

    private void ChooseNextSpawn()
    {
        moleculeSelected = premadeMolecules[Random.Range(0, 1)];
    }
}
