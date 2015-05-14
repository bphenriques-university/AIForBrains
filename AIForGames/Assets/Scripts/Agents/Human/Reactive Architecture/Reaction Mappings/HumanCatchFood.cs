using UnityEngine;
using System;

public class HumanCatchFood : ReactiveBehaviour
{
	
	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.IsTouchingFood ();
	}
	
	protected override void Execute ()
	{

		GameObject foodObject = human.Sensors.GetTouchingFood();
		//Due to non-deterministic environment
		if (foodObject == null) {
			return;
		}

		Food food = foodObject.GetComponent<Food> ();
		human.Actuators.CatchFood (food.catchFood ());
	}
}
