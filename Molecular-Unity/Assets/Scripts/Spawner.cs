using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    List<string> premadeMolecules = new List<string>() {"Please Select Molecule", "Water", "Methane"};
    private GameObject moleculeSpawn;
    private string moleculeSelected;
    private string previousMoleculeSelected;
    public Dropdown dropDownMenuGame;

    private void Awake()
    {
        previousMoleculeSelected = premadeMolecules[0];
        moleculeSelected = premadeMolecules[0];
        PopulateList();
    }

    void Update () {
        if (ShouldSpawn())
        {
            Spawn();
        }
	}

    private void Spawn()
    {
        var moleculeTemp = Resources.Load("Molecules/"+moleculeSelected);
        moleculeSpawn = moleculeTemp as GameObject;
        Instantiate(moleculeSpawn, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        if (moleculeSelected != previousMoleculeSelected)
        {
            previousMoleculeSelected = moleculeSelected;
            return true;
        }
        return false;
    }

    private void PopulateList()
    {
        dropDownMenuGame.AddOptions(premadeMolecules);
    }

    public void Dropdown_IndexChanged(int index)
    {
        if (index != 0)
        {
            moleculeSelected = premadeMolecules[index];
        }
        DestroyMolecule();
    }

    private void DestroyMolecule()
    {
        GameObject destroyingObject = GameObject.FindGameObjectWithTag("Molecule");     
        DestroyImmediate(destroyingObject, true);
    }
}
