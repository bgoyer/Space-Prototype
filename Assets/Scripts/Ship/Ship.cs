using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string Name;
    public int Shields;
    public int Hull;
    public int NeededCrew;
    public int Crew;
    public int Bunks;
    public int HeatDissipation;
    public int HeatCappacity;
    public int Heat;
    public int FuelCapacity;
    public int Fuel;
    public int EngeryCapacity;
    public int Engery;
    public int CargoCapacity;
    public List<Item> Cargo;

    public void Accelerate()
    {
        if (transform.GetComponentInChildren<Engine>() == null)
        {
            return;
        }
        transform.GetComponentInChildren<Engine>().AccelerateShip();
        print(transform.GetComponentInChildren<Engine>());
    }


}
