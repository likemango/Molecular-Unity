using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    [SerializeField]
    private string elementName;
    [SerializeField]
    private double atomicMass;
    [SerializeField]
    private double atomicNumber;

    public string ElementName
    {
        get
        {
            return elementName;
        }

        set
        {
            elementName = value;
        }
    }

    public double AtomicMass
    {
        get
        {
            return atomicMass;
        }

        set
        {
            atomicMass = value;
        }
    }

    public double AtomicNumber
    {
        get
        {
            return atomicNumber;
        }

        set
        {
            atomicNumber = value;
        }
    }

    protected Element(string elementName, double atomicMass, double atomicNumber)
    {
        ElementName = elementName;
        AtomicMass = atomicMass;
        AtomicNumber = atomicNumber;
    }
}
