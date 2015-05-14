using UnityEngine;
using System;

public class HumanCatchFood : ReactiveBehaviour
{
	
	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.Sensors.IsTouchingFood ();
	}
	
	protected override void Execute ()
	{

		GameObject foodObject = humanState.Sensors.GetTouchingFood();
		//Due to non-deterministic environment
		if (foodObject == null) {
			return;
		}

		Food food = foodObject.GetComponent<Food> ();
		humanState.Actuators.CatchFood (food.catchFood ());
	}
}
