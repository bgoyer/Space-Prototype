using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable
{
    public Ship(string name, string spriteName, string hullType, int mass, int shields, int hull, int neededCrew, int crew, int bunks, int heatDissipation, int heatCappacity, int heat, int fuelCapacity, int fuel, int engeryCapacity, int engery, int cargoCapacity, int currentCargoSpace, Dictionary<Vector2, bool> weaponSlots)
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
        WeaponSlots = weaponSlots;
    }

    public string Name { get; set; }
    public string SpriteName { get; }
    public string HullType { get; }
    public int Mass { get; }
    public int Shields { get; set; }
    public int Hull { get; set; }
    public int NeededCrew { get; }
    public int Crew { get; set; }
    public int Bunks { get; set; }
    public int HeatDissipation { get; }
    public int HeatCappacity { get; set; }
    public int Heat { get; set; }
    public int FuelCapacity { get; set; }
    public int Fuel { get; set; }
    public int EngeryCapacity { get; set; }
    public int Engery { get; set; }
    public int CargoCapacity { get; set; }
    public int CurrentCargoSpace { get; set; }
    public Dictionary<Vector2, bool> WeaponSlots { get; set; }

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






    public static void Create(string name,string shipTypeName, Vector3? position = null, bool isPlayer = false)
    {
        Type shipType = Type.GetType(shipTypeName);
        if (shipType != null && shipType.IsSubclassOf(typeof(Ship)))
        {
            GameObject ShipGO = new GameObject(name);
            ShipGO.AddComponent(shipType);
            ShipGO.transform.localScale = new Vector3(.1f,.1f,1f);
            if (position.HasValue)
            {
                ShipGO.transform.position = position.Value;
            }
            else
            {
                if (!isPlayer)
                {
                    System.Random _random = new System.Random();
                    Player player = GameObject.FindAnyObjectByType<Player>();
                    ShipGO.transform.position = _random.Next(-1, 1) * player.transform.parent.position + new Vector3(_random.Next(-100, 100), _random.Next(-100, 100));
                }
                else
                {
                    ShipGO.transform.position = new Vector3(0, 0, 0);
                }
            }



            GameObject inventoryGO = new GameObject("Inventory");
            inventoryGO.transform.parent = ShipGO.transform;

            Ship ship = (Ship)ShipGO.GetComponent(shipType);
            ship.Name = name;

            ShipGO.AddComponent<BasicThruster>();
            ShipGO.AddComponent<BasicTurning>();
            ShipGO.AddComponent<SpriteRenderer>();
            ShipGO.AddComponent<Rigidbody2D>();
            

            Rigidbody2D rigidbody2D = ShipGO.GetComponent<Rigidbody2D>();
            rigidbody2D.mass = ship.Mass;
            rigidbody2D.angularDrag = 500;
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
