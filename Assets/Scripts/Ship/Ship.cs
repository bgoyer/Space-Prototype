using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEditor.PackageManager;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable
{
    public Ship(string name, string spriteName, string hullType, int mass, int shields, int hull, int neededCrew, int crew, int bunks, int heatDissipation, int heatCappacity, int heat, int fuelCapacity, int fuel, int engeryCapacity, int engery, int cargoCapacity, int currentCargoSpace, List<Item> cargo)
    {
        Name = name;
        SpriteName = spriteName;
        HullType = hullType;
        Mass = mass;
        Shields = shields;
        Hull = hull;
        NeededCrew = neededCrew;
        Crew = crew;
        Bunks = bunks;
        HeatDissipation = heatDissipation;
        HeatCappacity = heatCappacity;
        Heat = heat;
        FuelCapacity = fuelCapacity;
        Fuel = fuel;
        EngeryCapacity = engeryCapacity;
        Engery = engery;
        CargoCapacity = cargoCapacity;
        CurrentCargoSpace = currentCargoSpace;
        Cargo = cargo;
    }

    public string Name { get; set; }
    public string SpriteName { get; set; }
    public string HullType { get; set; }
    public int Mass { get; set; }
    public int Shields { get; set; }
    public int Hull { get; set; }
    public int NeededCrew { get; set; }
    public int Crew { get; set; }
    public int Bunks { get; set; }
    public int HeatDissipation { get; set; }
    public int HeatCappacity { get; set; }
    public int Heat { get; set; }
    public int FuelCapacity { get; set; }
    public int Fuel { get; set; }
    public int EngeryCapacity { get; set; }
    public int Engery { get; set; }
    public int CargoCapacity { get; set; }
    public int CurrentCargoSpace { get; set; }
    public List<Item> Cargo { get; set; }

    public void Accelerate(float modifier)
    {
        if (transform.GetComponent<Thruster>() != null)
        {
            transform.GetComponent<Thruster>().Thrust(modifier);
            print(transform.GetComponent<Thruster>());
        }else Debug.LogWarning("No Engine Eqiuiped");
    }
    public void Rotate(float modifier)
    {
        if (transform.GetComponent<Turning>() != null)
        {
            transform.GetComponent<Turning>().Rotate(modifier);
            print(transform.GetComponent<Turning>());
        }
        else Debug.LogWarning("No Turning Eqiuiped");
    }
    public void AddInventory<T>() where T : Item
    {
        GameObject inventory = transform.Find("Inventory").gameObject;
        GameObject newItem = new GameObject();
        newItem.transform.parent = inventory.transform;
        newItem.AddComponent<T>();
        newItem.name = newItem.GetComponent<T>().Name;
        transform.GetComponent<Ship>().Cargo.Add(newItem.GetComponent<T>());
    }

    public void Damage(int amt)
    {
        if (Shields - amt > 0)
        {
            Shields -= amt;
        }
        else
        {
            Shields = 0;
            amt -= Shields;
            Hull -= amt;
        }
    }






    public static void CreateShip(string name,string shipTypeName, Vector2 position, bool isPlayer = false)
    {
        Type shipType = Type.GetType(shipTypeName);
        if (shipType != null && shipType.IsSubclassOf(typeof(Ship)))
        {
            GameObject ShipGO = new GameObject(name);
            ShipGO.AddComponent(shipType);
            ShipGO.transform.localScale = new Vector3(.1f,.1f,1f);
            ShipGO.transform.position = position;

            GameObject InventoryGO = new GameObject("Inventory");

            Ship ship = (Ship)ShipGO.GetComponent(shipType);
            ship.Name= name;

            ShipGO.AddComponent<BasicThruster>();
            ShipGO.AddComponent<BasicTurning>();
            ShipGO.AddComponent<SpriteRenderer>();
            ShipGO.AddComponent<Rigidbody2D>();
            

            Rigidbody2D rigidbody2D = ShipGO.GetComponent<Rigidbody2D>();
            rigidbody2D.mass = ship.Mass;
            rigidbody2D.angularDrag = 5;
            rigidbody2D.drag = 0;
            rigidbody2D.gravityScale = 0;


            Sprite sprite = Resources.Load<Sprite>("Images/Sprites/Ships/" + ship.SpriteName);
            if (!sprite)
            {
                Debug.LogError("Sprite not found at path: " + "Images/Sprites/Ships/" + ship.SpriteName);
            }
            else
            {
                ShipGO.GetComponent<SpriteRenderer>().sprite = sprite;
            }
            
            if (isPlayer) 
            { 
                ShipGO.AddComponent<Player>();
                CinemachineVirtualCamera CMVC = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
                CMVC.Follow = ShipGO.transform;
                CMVC.LookAt = ShipGO.transform;
                
            } else ShipGO.AddComponent<AI>();
           
        }
        else
        {
            Debug.LogError("Invalid Type: " + shipTypeName);
        }
    }
}
