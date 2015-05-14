using System;
using UnityEngine;

public class HumanCatchAmmo : ReactiveBehaviour
{
	Human humanState;
	
	void Awake(){
		humanState = transform.root.GetComponent <Human> ();
	}
	
	protected override bool IsInSituation ()
	{
		return !humanState.IsGrabbed () && humanState.IsSeeingAmmo ();
	}
	
	protected override void Execute ()
	{
		GameObject gameObject = humanState.ammoSeen.gameObject;
		
		if (humanState.ammoSeen == null) {
			humanState.sawAmmo = false;
			return;
		}
		
		Vector3 ammoPosition = gameObject.transform.position;
		humanState.Actuators.ChangeDestination (ammoPosition);
		humanState.Actuators.Walk ();
	}
}




