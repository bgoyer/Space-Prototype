using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : AI
{
    public Pirate() : base("Name") { }
	private enum AI_State
	{
		Attack,
		Disabled,
		Destroyed
	}

	private AI_State currentState;
    private void Update()
    {
		
    }
}
