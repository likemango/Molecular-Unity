using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Updates UI temp
 
public class GameController : MonoBehaviour
{
    public Text m_MyText;

    void Start()
    {
        m_MyText.text = gameObject.GetComponent<Molecule>().MolecularFormula;
    }

    void LateUpdate()
    {
        m_MyText.text = gameObject.GetComponent<Molecule>().MolecularFormula;
    }
}
