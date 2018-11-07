using System;
using UnityEngine;
using UnityEngine.UI;
 
public class GameController : MonoBehaviour
{

    //public Text angleText;

    void Start()
    {

    }

    void LateUpdate()
    {

    }

    /*
    private void ShowBondAngle()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject != null)
            {
                GameObject molecule = hit.collider.gameObject;
                if (molecule.tag == "Element")
                {
                    if (molecule.transform.GetChild(0).gameObject != null && molecule.transform.parent.transform.parent != null && molecule.transform.parent.transform.parent.transform.parent != null)
                    {
                        GameObject bond = molecule.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        angleText.text = Convert.ToString(bond.transform.localEulerAngles.z);
                    }
                }
            }
        }
        else
        {
            angleText.text = "";
        }
    }*/
}
