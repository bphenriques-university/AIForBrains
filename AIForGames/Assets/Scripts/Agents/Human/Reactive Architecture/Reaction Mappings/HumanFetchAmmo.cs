using System;
using UnityEngine;

public class HumanFetchAmmo : ReactiveBehaviour
{
	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.Sensors.SawAmmo ();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = humanState.Sensors.GetClosestAmmoSeen();

        if (gameObject == null)
        {
			return;
		}
		
		Vector3 ammoPosition = gameObject.transform.position;
		humanState.Actuators.ChangeDestination (ammoPosition);
		humanState.Actuators.Walk ();
	}
}




