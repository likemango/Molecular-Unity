using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementSelector : MonoBehaviour {

    [SerializeField]
    private Text elementName;
    [SerializeField]
    private InputField elementAngleInput;
    [SerializeField]
    private Text elementAngle;
    private GameObject elementSelected;


    private void Start()
    {
    }


    private void Update()
    {
        GetSelectedElement();
    }

    private void LateUpdate()
    {
        if (elementSelected != null)
        {
            UpdateTextbox();
            UpdateUISelectedElement();
        }
    }

    //can be anywhere will put on gamecontroller
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
                }
            }
        }
    }

    private void UpdateUISelectedElement()
    {
        elementName.text = elementSelected.name;
        //elementAngle.text = elementSelected.transform.localRotation.x.ToString();
    }

    private void UpdateTextbox()
    {
        if (elementSelected.tag == "Element")
        {
            //  elementAngleInput.enabled = false;
            elementAngleInput.DeactivateInputField();
        }
        Debug.Log(elementAngleInput.isActiveAndEnabled);
    }



}
