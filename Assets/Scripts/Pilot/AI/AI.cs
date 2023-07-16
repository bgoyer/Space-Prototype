using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AI : Pilot
{
    public AI(string name, Personality[] personalities) : base(name)
    {
        Personalities = personalities;
    }

    public Personality[] Personalities { get; set; }
    public GameObject Target { get; set; }
    public Vector3? TargetPosition { get; set; }
    public enum Personality
    {
        Agressive
    } 

    

}
