using UnityEngine;
using System;

public class HumanEatFood : ReactiveBehaviour
{
	public readonly float minHungerToEat = 30f;

	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.HungerLevel() < minHungerToEat && human.Sensors.FoodCarried () > 0;
	}
	
	protected override void Execute ()
	{

		human.Actuators.EatFood ();
	}
}
