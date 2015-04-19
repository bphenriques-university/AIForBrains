using System;
using UnityEngine;

public class HumanCatchFood : ReactiveBehaviour
{

	HumanState humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}

	protected override bool IsInSituation ()
	{
		return humanState.IsSeeingFood ();
	}

	protected override void Execute ()
	{
		GameObject gameObject = humanState.foodSeen;

		if (humanState.foodSeen == null) {
			humanState.sawFood = false;
			return;
		}
		//Debug.Log ("going for food!");
		Vector3 foodPosition = gameObject.transform.position;
		humanState.ChangeDestination (foodPosition);
		humanState.Walk ();
	}
}


