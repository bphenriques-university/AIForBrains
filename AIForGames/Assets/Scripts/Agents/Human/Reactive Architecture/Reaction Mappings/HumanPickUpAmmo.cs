using System;
using UnityEngine;

public class HumanPickUpAmmo : ReactiveBehaviour
{
	
	Human human;
	
	void Awake(){
		human = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return human.Sensors.IsTouchingAmmo ();
	}
	
	protected override void Execute ()
	{
        human.Actuators.GrabAmmo(human.Sensors.GetTouchingAmmo().GetComponent<Ammo>());
	}
}


