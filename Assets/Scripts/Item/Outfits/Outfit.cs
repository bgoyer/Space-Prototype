using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Outfit : Item
{
    public Outfit(string name, string descritpion, int quantity) : base(name, descritpion, quantity)
    {
    }
}
