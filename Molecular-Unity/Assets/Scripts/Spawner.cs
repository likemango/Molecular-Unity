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
        PopulateList();
    }

    void Update ()
    {
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
        if (moleculeSelected != previousMoleculeSelected && moleculeSelected != premadeMolecules[0])
        {
            previousMoleculeSelected = moleculeSelected;
            return true;
        }
        if (moleculeSelected == premadeMolecules[0])
        {
            previousMoleculeSelected = moleculeSelected;
            return false;
        }
        return false;
    }

    private void PopulateList()
    {
        dropDownMenuGame.AddOptions(premadeMolecules);
    }

    public void Dropdown_IndexChanged(int index)
    {
        moleculeSelected = premadeMolecules[index];
        DestroyMolecule();
    }

    private void DestroyMolecule()
    {
        GameObject destroyingObject = GameObject.FindGameObjectWithTag("Molecule");     
        DestroyImmediate(destroyingObject, true);
    }
}
