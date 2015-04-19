using UnityEngine;
using System;

public class HumanEatFood : ReactiveBehaviour
{
	public readonly float minHungerToEat = 30f;

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.HungerLevel() < minHungerToEat && humanState.FoodCarried () > 0;
	}
	
	protected override void Execute ()
	{

		humanState.EatFood ();
	}
}
