using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public abstract class Thruster : Outfit
{
    public Thruster(string name, string descritpion, int quantity, int force) : base(name, descritpion, quantity)
    {
        Force = force;
    }

    public int Force { get; set; }
    
    /// <summary>
    /// 1f is foreward; -1f is reverse.
    /// </summary>
    /// <param name="modifier"></param>
    public void Thrust(float modifier)
    {
        modifier = modifier > 0f ? Mathf.Min(modifier, 1f) : Mathf.Max(modifier, -1f);
        
        transform.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * Force * modifier * Time.deltaTime, ForceMode2D.Impulse);
    }
}
