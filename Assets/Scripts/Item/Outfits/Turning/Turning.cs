using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turning : Outfit
{
    public Turning(string name, string descritpion, int quantity, int force) : base(name, descritpion, quantity)
    {
        Force = force;
    }

    public int Force { get; set; }

    /// <summary>
    /// -1f is counter clockwise (left); 1f is clockwise (right)
    /// </summary>
    /// <param name="modifier"></param>
    public void Rotate(float modifier)
    {
        modifier = modifier > 0f ? Mathf.Min(modifier, 1f) : Mathf.Max(modifier, -1f);
        transform.GetComponent<Rigidbody2D>().AddTorque(Force * -modifier * 100 * Time.deltaTime, ForceMode2D.Impulse);
    }
}
