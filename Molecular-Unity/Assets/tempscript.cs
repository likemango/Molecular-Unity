using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempscript : MonoBehaviour {
    /*
    public Text elementName;
    public Text elementAngle;

    GameObject elementSelected;
    // Use this for initialization

    private void Update()
    {
        //SetElementPosition();
        GetMouseGameObject();
        UpdateUISelectedElement();
    }

    /*
    void OnTriggerEnter(Collider other) //only a trigger and a colider or a colider and a colider
    {
        open = true;
    }

    private void OnTriggerStay(Collider other)
    {
        open = true;
    }
    
    private void SetElementPosition()
    {
        if (open)
        {
            molecule.transform.position = bondEnd.transform.position;
            open = false;
        }
    }
    

    //can be anywhere will put on gamecontroller
    private void GetMouseGameObject()
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
                }
            }
        }
    }

    private void UpdateUISelectedElement()
    {
        if (elementSelected != null)
        {
            elementName.text = elementSelected.name;
            elementAngle.text = elementSelected.transform.localRotation.x.ToString();
        }
    }*/
}
