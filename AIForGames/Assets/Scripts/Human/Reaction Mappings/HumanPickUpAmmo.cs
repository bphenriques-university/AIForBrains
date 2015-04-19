using System;
using UnityEngine;

public class HumanPickUpAmmo : ReactiveBehaviour
{
	
	HumanState humanState;
	HumanShooting playerShooting;
	
	void Awake(){
		humanState = transform.root.GetComponent <HumanState> ();
	}
	
	protected override bool IsInSituation ()
	{
		return humanState.IsOnAmmo ();
	}
	
	protected override void Execute ()
	{
		humanState.grabAmmo ();
	}
}


