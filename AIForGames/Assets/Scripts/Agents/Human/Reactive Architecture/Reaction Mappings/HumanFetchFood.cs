using System;
using UnityEngine;

public class HumanFetchFood : ReactiveBehaviour
{

	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}

	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.Sensors.SawFood ();
	}

	protected override void Execute ()
	{
		GameObject gameObject = humanState.Sensors.GetClosestFoodSeen();

        if (gameObject == null)
        {
			return;
		}

		Vector3 foodPosition = gameObject.transform.position;
		humanState.Actuators.ChangeDestination (foodPosition);
		humanState.Actuators.Walk ();
	}
}


