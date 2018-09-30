using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{ 
    [SerializeField]
    private string elementName;
    [SerializeField]
    private string symbol;
    [SerializeField]
    private double atomicMass;
    [SerializeField]
    private double atomicNumber;

    public Element(string elementName, double atomicMass, double atomicNumber, string symbol)
    {
        ElementName = elementName;
        AtomicMass = atomicMass;
        AtomicNumber = atomicNumber;
        Symbol = symbol;
    }   

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

    public string Symbol
    {
        get
        {
            return symbol;
        }

        set
        {
            symbol = value;
        }
    }

}
