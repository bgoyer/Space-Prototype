using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public Pilot(string name)
    {
        Name = name;
    }

   public string Name { get; set; }
   public Ship CurrentShip { get; set; }
   
}
