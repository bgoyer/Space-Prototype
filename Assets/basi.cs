using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE1006 // Naming Styles
public class basi : MonoBehaviour
#pragma warning restore IDE1006 // Naming Styles
{
    // Start is called before the first frame update
    void Start()
    {
        Ship.Create("SS Normandy", "Hawk", new Vector2(-6, 0), true);
        //Ship.Create("SS KMS", "Hawk", new Vector2(-7, 0), false, "Pirate");

    }
}
