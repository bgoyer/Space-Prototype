using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseThruster : Thruster
{
    public ReverseThruster(string name, string descritpion, int quantity, int force) : base(name, descritpion, quantity, force) { }

    public void Thrust()
    {
        transform.GetComponent<Rigidbody2D>().AddForce((this.transform.GetComponent<Rigidbody2D>().velocity).normalized * Force * -1 * Time.deltaTime, ForceMode2D.Impulse);
    }
}
