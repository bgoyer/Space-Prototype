using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public string Name;
    public int Shields;
    public int Hull;
    public int NeededCrew;
    public int Crew;
    public int Bunks;
    public int HeatDissipation;
    public int Heat;
    public int FuelCapacity;
    public int Fuel;
    public int EngeryCapacity;
    public int Engery;
    public int CargoCapacity;
    public List<Item> Cargo;
    
    void Bla()
    {
        Cargo.Add(new Item("Bla", "Bla", 5));
    }
}
