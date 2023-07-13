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
		Destroyed,
		Idle
	}
	Turning turning;
    private void Start()
    {
        Target = GameObject.FindObjectOfType<Player>().gameObject;
		turning = this.GetComponent<Turning>();
    }

    private AI_State currentState;
    private void FixedUpdate()
    {
        print(GetNextState());
        switch (GetNextState())
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

	private AI_State GetNextState() 
	{
		switch (currentState)
		{
			case AI_State.Attack:
				if (IsDisabled())
				{
					currentState = AI_State.Disabled;
                    return AI_State.Disabled;
				}
				return AI_State.Attack;

				
			case AI_State.Roam:
				return AI_State.Roam;

			case AI_State.Patrol:
				return AI_State.Patrol;

			case AI_State.Disabled:
				return AI_State.Disabled;

			case AI_State.Destroyed:
				return AI_State.Destroyed;

			default:
				return AI_State.Idle;
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
        turning.RotateTowards((Target.transform.position).normalized);
		
	}
}
