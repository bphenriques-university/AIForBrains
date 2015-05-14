using System;
using UnityEngine;

public class HumanFetchAmmo : ReactiveBehaviour
{
	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return !human.Sensors.IsGrabbed () && human.Sensors.SawAmmo ();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = human.Sensors.GetClosestAmmoSeen();

        if (gameObject == null)
        {
			return;
		}
		
		Vector3 ammoPosition = gameObject.transform.position;
		human.Actuators.ChangeDestination (ammoPosition);
		human.Actuators.Walk ();
	}
}




