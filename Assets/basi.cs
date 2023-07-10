using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Ship.Create("SS Normandy", "Hawk", new Vector2(-6, 0), true);
        
    }
}
