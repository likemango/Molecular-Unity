using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    private void Update()
    {
        GetSelectedElement();
    }

    private void LateUpdate()
    {
        if (elementSelected != null)
        {
            UpdateTextboxVisablility();
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
    }

    private void UpdateTextboxVisablility()
    {
        if (elementSelected.tag == "Element")
        {
            //  elementAngleInput.enabled = false;
            elementAngleInput.DeactivateInputField();
        }
        else if (elementSelected.tag == "Bond")
        {
            elementAngleInput.ActivateInputField();
            UpdateTextboxAngle();
        }
        //Debug.Log(elementAngleInput.isActiveAndEnabled);
    }

    private void UpdateTextboxAngle()
    {
        elementAngle.text = elementSelected.transform.parent.transform.localEulerAngles.z.ToString();
    }

    public void OnChangeEvent()
    {
        try
        {
            if (elementSelected.tag == "Bond" && elementAngle)
            {
                Vector3 userAngles = new Vector3(0, 0, (float)double.Parse(elementAngleInput.text, CultureInfo.InvariantCulture.NumberFormat));
                elementSelected.transform.parent.transform.localEulerAngles = userAngles;
            }
        }
        catch(Exception)
        {

        }
    }
}
