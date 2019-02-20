/* Molecular Unity - Element
 * Mark Halle 
 * Element structure for building the molecules
 * Consists of different properties in an element and a Icomparable
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Element:Consists of a name, symbol, atomicMass, and atomicNumber
/// </summary>
public class Element : MonoBehaviour, IComparable
{ 
    [SerializeField]
    private string elementName;
    [SerializeField]
    private string symbol;
    [SerializeField]
    private double atomicMass;
    [SerializeField]
    private double atomicNumber;

    /// <summary></summary>
    /// <param name="elementName"></param>
    /// <param name="atomicMass"></param>
    /// <param name="atomicNumber"></param>
    /// <param name="symbol"></param>
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


    //testing IComparable
    /// <summary></summary>
    /// <param name="obj"></param>
    public int CompareTo(object obj)
    {
        return AtomicNumber.CompareTo(obj);
    }
}
