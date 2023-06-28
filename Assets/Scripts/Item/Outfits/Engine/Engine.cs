using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Engine : Outfits, IEngine
{
    public Engine(string name, string descritpion, int quantity, int force) : base(name, descritpion, quantity)
    {
        Force = force;
    }

    public int Force { get; set; }

    public void AccelerateShip()
    {
        transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Force * Time.deltaTime);
    }
    public void DecelerateShip() 
    {
        transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * -Force * Time.deltaTime);
    }
}
