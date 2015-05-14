using System;
using UnityEngine;

public class HumanFetchFood : ReactiveBehaviour
{

	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}

	protected override bool IsInSituation ()
	{
		return !human.Sensors.IsGrabbed () && human.Sensors.SawFood ();
	}

	protected override void Execute ()
	{
		GameObject gameObject = human.Sensors.GetClosestFoodSeen();

        if (gameObject == null)
        {
			return;
		}

		Vector3 foodPosition = gameObject.transform.position;
		human.Actuators.ChangeDestination (foodPosition);
		human.Actuators.Walk ();
	}
}


