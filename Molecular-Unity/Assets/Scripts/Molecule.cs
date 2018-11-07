using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Molecule : MonoBehaviour
{

    private List<GameObject> elements = new List<GameObject>();
    //private List<GameObject> bonds = new List<GameObject>();
    //private string[,] elementData = new string[11, 3];
    private int numberElements = 0;
    private string molecularFormula = "";
    //private bool changeInFormula;
    [SerializeField]
    private Text moleculeInfoText;

    void LateUpdate()
    {
        UpdateElementsOnMolecule(GameObject.FindGameObjectWithTag("Camera Pivot").transform.position, CameraController.MaxCameraDistance);
        UpdateMoleculeUIText();
    }

    /// <summary>
    /// Updates the elements on molecule.
    /// </summary>
    /// <param name="center">The center.</param>
    /// <param name="radius">The radius.</param>
    public void UpdateElementsOnMolecule(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        if (hitColliders.Length != numberElements)
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
        }
        numberElements = hitColliders.Length;
    }

    /// <summary>
    /// Updates the molecular formula.
    /// </summary>
    public void UpdateMolecularFormula()
    {
        molecularFormula = "";
        int[] moleculeCount = new int[11];
        string[] moleculeSymbol = new string[11] { "Br", "C", "Cl", "F", "H", "I", "N", "O", "P", "Si", "S" };
        if (elements != null)
        {
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
    }

    private void UpdateMoleculeUIText()
    {
        moleculeInfoText.text = MolecularFormula;
    }

    /// <summary>
    /// Gets the molecular formula.
    /// </summary>
    /// <value>
    /// The molecular formula.
    /// </value>
    public string MolecularFormula
    {
        get
        {
            return molecularFormula;
        }
    }
}

