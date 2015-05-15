using UnityEngine;
using System.Collections;

public class GiveFoodPlanComponent  : PlanComponent
{
	Human me;
	Human destination;
	Food food;
	public GiveFoodPlanComponent(Human me, Human human, Food food)
		: base(human)
	{
		this.me = me;
		destination = human;
		this.food = food;
	}
	
	
	public override bool TryExecuteAction()
	{
		human.Actuators.GiveFood(destination, me, food);

		return true;
	}
}

