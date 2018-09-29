using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen : Element
{
    protected Hydrogen(string elementName, double atomicMass, double atomicNumber) : base(elementName, atomicMass, atomicNumber)
    {
        this.AtomicNumber = 1;
        elementName = "Hydrogen";
    }

}
