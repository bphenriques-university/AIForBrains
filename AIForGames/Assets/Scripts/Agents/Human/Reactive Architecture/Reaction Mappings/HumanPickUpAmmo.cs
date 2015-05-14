using System;
using UnityEngine;

public class HumanPickUpAmmo : ReactiveBehaviour
{
	
	Human humanState;
	HumanShooting playerShooting;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.Sensors.IsTouchingAmmo ();
	}
	
	protected override void Execute ()
	{
        humanState.Actuators.GrabAmmo(humanState.Sensors.GetTouchingAmmo().GetComponent<Ammo>());
	}
}


