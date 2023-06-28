using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEngine
{
    public int Force { get; set; }
    public void AccelerateShip() { }
    public void DecelerateShip() { }

}
