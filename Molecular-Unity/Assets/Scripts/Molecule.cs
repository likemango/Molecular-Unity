using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Molecule : MonoBehaviour {

    private List<GameObject> elements = new List<GameObject>();
    private List<GameObject> bonds = new List<GameObject>();
    private int numberElements = 0;
    private string molecularFormula = "";
    private bool changeInFormula;

    void LateUpdate()
    {
        UpdateElementsOnMolecule(GameObject.FindGameObjectWithTag("Camera Pivot").transform.position, CameraController.MaxCameraDistance);
        //UpdateMolecularFormula();
        /* 
        foreach (GameObject element in elements)
            {
               print(element.GetComponent<Element>().ElementName);
            }*/

        print(molecularFormula);


    }

    public void UpdateElementsOnMolecule(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        if (hitColliders.Length < numberElements)
        {
            elements.Clear();
        }
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Element" && !elements.Contains(hitColliders[i].gameObject))
            {
                elements.Add(hitColliders[i].gameObject);
                UpdateMolecularFormula();
            }
            //if (!elements.Contains(hitColliders[i].gameObject))
        }
        numberElements = hitColliders.Length;
    }

    public void UpdateMolecularFormula()
    {
        int H = 0;
        elements.Sort();
        foreach (GameObject e in elements)
        {
            switch (e.GetComponent<Element>().Symbol)
            {
                case "H":
                    H++;
                break;

            }

        }
    }


    public List<GameObject> Elements
    {
        get
        {
            return elements;
        }

        set
        {
            elements = value;
        }
    }

    public List<GameObject> Bonds
    {
        get
        {
            return bonds;
        }

        set
        {
            bonds = value;
        }
    }
}

