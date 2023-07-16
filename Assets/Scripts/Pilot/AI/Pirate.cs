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
	Thruster thruster;

    private void Start()
    {
        Target = GameObject.FindObjectOfType<Player>().gameObject;
		turning = this.GetComponent<Turning>();
		thruster = this.GetComponent<Thruster>();
    }

    private AI_State currentState;
    private void FixedUpdate()
    {
        //print(GetNextState());
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
				Patrol();
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
				if (Vector3.Distance(transform.transform.position, Target.transform.position) > 600)
				{
					currentState = AI_State.Patrol;
					return AI_State.Patrol;
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
		if (TargetPosition != null)
		{
			TargetPosition = null;
		}
		if (Target == null)
		{
			Target = GameObject.FindAnyObjectByType<Player>().gameObject;
		}
		if (turning.RotateTowards(transform.position - Target.transform.position)) { 
            thruster.Thrust(1f);
        }
	}
	private void Patrol() 
	{
		if (Target)
		{
			Target = null;
		}
		if (TargetPosition != null)
		{

		}	 
	}
}
