using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hawk : Ship
{
    public Hawk(string name, string spriteName, string hullType, int mass, int shields, int hull, int neededCrew, int crew, int bunks, int heatDissipation, int heatCappacity, int heat, int fuelCapacity, int fuel, int engeryCapacity, int engery, int cargoCapacity, int currentCargoSpace, List<Item> cargo) : base(name, spriteName, hullType, mass, shields, hull, neededCrew, crew, bunks, heatDissipation, heatCappacity, heat, fuelCapacity, fuel, engeryCapacity, engery, cargoCapacity, currentCargoSpace, cargo)
    {
    }

    private void Awake()
    {
        this.SpriteName = "hawk";
        this.HullType = "Hawk";
        this.Shields = 100;
        this.Hull = 100;
        this.Mass = 1500;
        this.NeededCrew = 1;
        this.Crew = 1;
        this.Bunks = 2;
        this.HeatDissipation = 1;
        this.HeatCappacity = 15;
        this.Heat = 0;
        this.FuelCapacity = 300;
        this.Fuel = 300;
        this.EngeryCapacity = 0;
        this.Engery = 0;
        this.CargoCapacity = 50;
        this.CurrentCargoSpace = 50;
        this.Cargo = new List<Item>();
    }


}
