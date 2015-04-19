using UnityEngine;
using System;

public class HumanEatFood : ReactiveBehaviour
{
	
	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.IsOnFood ();
	}
	
	protected override void Execute ()
	{

		GameObject foodObject = humanState.foodSeen;
		//Debug.Log ("On food!");
		//Due to non-deterministic environment
		if (foodObject == null) {
			humanState.onFood = false;
			humanState.sawFood = false;
			return;
		}

		Food food = foodObject.GetComponent<Food> ();
		HumanHunger hunger = transform.root.GetComponent<HumanHunger>();
		hunger.addFood(food.eat());

		humanState.onFood = false;
		humanState.sawFood = false;

	}
}
