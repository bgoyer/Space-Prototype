using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ItemBase
{
    public Item(string name, string descritpion, int quantity)
    {
        Name = name;
        Description = descritpion;
        Quantity = quantity;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}
