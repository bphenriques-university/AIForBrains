using UnityEngine;
using System;

public class HumanEatFood : ReactiveBehaviour
{
	public readonly float minHungerToEat = 30f;

	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.HungerLevel() < minHungerToEat && humanState.Sensors.FoodCarried () > 0;
	}
	
	protected override void Execute ()
	{

		humanState.Actuators.EatFood ();
	}
}
