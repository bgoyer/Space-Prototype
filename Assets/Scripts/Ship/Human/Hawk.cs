using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hawk : Ship
{
    public Hawk() : base("", "hawk", "Hawk", 1500, 100, 100, 1, 1, 2, 1, 15, 0, 300, 300, 0, 0, 50, 50, new Dictionary<Vector2, bool> { [new Vector2(-0.248f, -0.154f)] = false, [new Vector2(0.248f, -0.154f)] = false}, new Dictionary<string, int> { ["BasicTurning"] = 1, ["BasicThruster"] = 1, ["BasicCannon"] = 3 })
    { }
}
