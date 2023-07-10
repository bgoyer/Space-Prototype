using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Pirate : AI
{
    public Pirate() : base("Name", new Personality[]{Personality.Agressive}) { }
	private enum AI_State
	{
		Attack,
		Roam,
		Patrol,
		Disabled,
		Destroyed
	}


	private AI_State currentState;
    private void FixedUpdate()
    {
		GetNextState();

		switch (currentState)
		{
			case AI_State.Attack:
				if (Personalities.Contains(Personality.Agressive))
				{
					Attack_Agressive();
				}
				break;
			case AI_State.Roam:
				break;
			case AI_State.Patrol:
				break;
			case AI_State.Disabled:
				break;
			case AI_State.Destroyed:
				break;
			default:
				break;
		}
	}

	private void GetNextState() 
	{
		switch (currentState)
		{
			case AI_State.Attack:
				if (IsDisabled())
				{
					currentState = AI_State.Disabled;
					break;
				}

				break;
			case AI_State.Roam:
				break;
			case AI_State.Patrol:
				break;
			case AI_State.Disabled:
				break;
			case AI_State.Destroyed:
				break;
			default:
				break;
		}

	}
	private bool IsDisabled()
	{
		if (this.transform.GetComponent<Ship>().Hull > this.transform.GetComponent<Ship>().Hull * 0.2)
		{
			return false;
		}
		return true;
	}
	private void Attack_Agressive()
	{

	}
}
