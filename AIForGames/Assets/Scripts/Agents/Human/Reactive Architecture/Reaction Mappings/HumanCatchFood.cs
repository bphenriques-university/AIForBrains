using UnityEngine;
using System;

public class HumanCatchFood : ReactiveBehaviour
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
		//Due to non-deterministic environment
		if (foodObject == null) {
			humanState.onFood = false;
			humanState.sawFood = false;
			return;
		}

		Food food = foodObject.GetComponent<Food> ();
		humanState.actuator.CatchFood (food.catchFood ());

		humanState.onFood = false;
		humanState.sawFood = false;

	}
}
