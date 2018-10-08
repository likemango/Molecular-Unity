using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Molecule : MonoBehaviour {

    private List<GameObject> elements = new List<GameObject>();
    private List<GameObject> bonds = new List<GameObject>();
    private string[,] elementData = new string[11,3];
    private int numberElements = 0;
    private string molecularFormula = "";
    private bool changeInFormula;

    void LateUpdate()
    {
        UpdateElementsOnMolecule(GameObject.FindGameObjectWithTag("Camera Pivot").transform.position, CameraController.MaxCameraDistance);
        //print(molecularFormula);
    }

    // Updates the hidden molecule counter
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
               // UpdateMolecularFormula();
            }
        }
        numberElements = hitColliders.Length;
    }

    // Primitive string builder for the molecular formula. 
    public void UpdateMolecularFormula()
    {
   
            molecularFormula = "";
            int[] moleculeCount = new int[11];
            string[] moleculeSymbol = new string[11] { "Br", "C", "Cl", "F", "H", "I", "N", "O", "P", "Si", "S" };
            foreach (GameObject e in elements)
            {
                switch (e.GetComponent<Element>().Symbol)
                {
                    case "Br":
                        moleculeCount[0]++;
                        break;
                    case "C":
                        moleculeCount[1]++;
                        break;
                    case "Cl":
                        moleculeCount[2]++;
                        break;
                    case "F":
                        moleculeCount[3]++;
                        break;
                    case "H":
                        moleculeCount[4]++;
                        break;
                    case "I":
                        moleculeCount[5]++;
                        break;
                    case "N":
                        moleculeCount[6]++;
                        break;
                    case "O":
                        moleculeCount[7]++;
                        break;
                    case "P":
                        moleculeCount[8]++;
                        break;
                    case "Si":
                        moleculeCount[9]++;
                        break;
                    case "S":
                        moleculeCount[10]++;
                        break;
                }
            }

            for (int i = 0; i < moleculeCount.Length; i++)
            {
                if (moleculeCount[i] != 0)
                {
                    molecularFormula += moleculeSymbol[i] + moleculeCount[i];
                }
           
        }
    }

    public void sortingthelist()
    {
        elements.Sort();

    }

    public string MolecularFormula
    {
        get
        {
            return molecularFormula;
        }
    }
}

