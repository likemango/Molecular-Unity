using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentConnector : MonoBehaviour {

    public Button componentButtonAdder;
    private GameObject elementSelected;
    public Dropdown addComponentDropdown;
    private List<string> bondList = new List<string>(){"Add Bond", "Single Bond", "Double Bond", "Triple Bond", "Quadruple Bond"};
    private List<string> bondListReal = new List<string>() { "Add Bond", "SingleBondStart", "DoubleBondStart", "TripleBondStart", "QuadrupleBondStart" };
    private List<string> elementList = new List<string>() {"Add Element", "Bromine", "Carbon", "Chlorine", "Fluorine", "Hydrogen", "Iodine", "Nitrogen", "Oxygen", "Phosphorus", "Silicon", "Sulfur"};

    private void Start()
    {
        PopulateList(elementList);
    }
    
    void Update()
    {
        GetSelectedElement();
    }

    private void SpawnElement(Vector3 spawnLocation, string itemToSpawn)
    {
        var spawnTemp = Resources.Load("Elements/"+ itemToSpawn);
        GameObject spawnGameObject = Instantiate(spawnTemp, spawnLocation, transform.rotation) as GameObject;
        spawnGameObject.transform.parent = elementSelected.transform.GetChild(0).transform;
    }

    private void SpawnBond(Vector3 spawnLocation, string itemToSpawn)
    {
        var spawnTemp = Resources.Load("Bonds/" + itemToSpawn);
        GameObject spawnGameObject = Instantiate(spawnTemp, spawnLocation, transform.rotation) as GameObject;
        spawnGameObject.transform.parent = elementSelected.transform;
    }

    private void SpawnInitialElement(Vector3 spawnLocation, string itemToSpawn)
    {
        var spawnTemp = Resources.Load("Elements/" + itemToSpawn);
        GameObject spawnGameObject = Instantiate(spawnTemp, spawnLocation, transform.rotation) as GameObject;
    }


    private void GetSelectedElement()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    elementSelected = hit.transform.gameObject; 
                    ChangeDropdown(); // changes dropdown based on object
                }
            }
        }
    }

    private void ChangeDropdown()
    {
        if (elementSelected != null)
        {
            if (elementSelected.tag == "Bond")
            {
                addComponentDropdown.ClearOptions();
                PopulateList(elementList);
            }
            else if (elementSelected.tag == "Element")
            {
                addComponentDropdown.ClearOptions();
                PopulateList(bondList);
            }
            else
            {
                addComponentDropdown.ClearOptions();
            }
        }
        else
        {
            addComponentDropdown.ClearOptions();
            PopulateList(elementList);
        }
    }

    private void PopulateList(List<string> listToAdd)
    {
        addComponentDropdown.AddOptions(listToAdd);
    }

    public void Dropdown_IndexChanged(int index)
    {
        
    }

    public void ButtonClicked(int buttonNo)
    {
        if (buttonNo == 0)
        {
            AddComponent();
        }
        else
        {
            DeleteComponent();
        }
    }

    private void AddComponent()
    {
        if (addComponentDropdown.value != 0)
        {
            if (elementSelected != null)
            {
                if (elementSelected.tag == "Bond")
                {
                    string itemToSpawn = elementList[addComponentDropdown.value];
                    Vector3 endPosition = elementSelected.transform.GetChild(0).position;
                    SpawnElement(endPosition, itemToSpawn);
                }
                else if (elementSelected.tag == "Element")
                {
                    string itemToSpawn = bondListReal[addComponentDropdown.value];
                    Vector3 endPosition = elementSelected.transform.position;
                    SpawnBond(endPosition, itemToSpawn);
                }
            }
            else
            {
                string itemToSpawn = elementList[addComponentDropdown.value];
                Vector3 initalPosition = new Vector3(0, 0, 0);
                SpawnInitialElement(initalPosition, itemToSpawn);
            }
        }
    }

    private void DeleteComponent()
    {
        GameObject destroyingObject;
        if (elementSelected != null)
        {
            if (elementSelected.tag == "Bond")
            {
                destroyingObject = elementSelected.transform.parent.gameObject;
            }
            else
            {
                destroyingObject = elementSelected;
            }
            DestroyImmediate(destroyingObject, true);
            elementSelected = null;
            ChangeDropdown();
        }
    }

}
