using UnityEngine;
using System.Collections;

public class GiveFoodPlanComponent  : PlanComponent
{
	Human destination;
	Food food;
	public GiveFoodPlanComponent(Human human, Food food)
		: base(human)
	{
		destination = human;
		this.food = food;
	}
	
	
	public override bool TryExecuteAction()
	{
		human.Actuators.GiveFood(destination, food);

		return true;
	}
}

